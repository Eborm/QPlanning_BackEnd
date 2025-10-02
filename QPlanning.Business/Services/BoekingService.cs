using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OfficeOpenXml;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.Helpers.Extensions;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Boeking.Dto;
using QPlanning.Business.UseCases.Boeking.Get.Models;

namespace QPlanning.Business.Services
{
    public class BoekingService : IBoekingService
    {
        private readonly IBoekingRepository _boekingRepository;
        private readonly IMedewerkerRepository _medewerkerRepository;

        public BoekingService(IBoekingRepository boekingRepository, IMedewerkerRepository medewerkerRepository)
        {
            _boekingRepository = boekingRepository;
            _medewerkerRepository = medewerkerRepository;
        }
        
        public async Task<BoekingPeriodResponse> GetPersonalBoekingenWithinPeriod(DateTime start, DateTime end, string email)
        {
            var currentMedewerker = _medewerkerRepository.GetDomainModelMedewerker(email);
            
            var domainBoekingList = await _boekingRepository.GetBoekingenWithinPeriodForMedewerker(start, end, currentMedewerker.Id);
            var currentUserEmail = email.ToLower();

            var planningTableViewModel = new PlanningTableViewModel
            {
                Years = new List<YearModel>(),
                TopRows = new List<TopRowModel>()
            };

            var currentUserBoekingen = domainBoekingList.Where(x => x.Medewerker?.Email?.ToLower() == currentUserEmail && x.Uren > 0).OrderBy(x => x.Jaar).ThenBy(x => x.Weeknummer).ThenBy(x => x.Klant?.Naam).ThenBy(x => x.IndirecteUren?.Omschrijving).ToList();
            var klantNamen = currentUserBoekingen.Where(x => x.Klant != null).Select(x => x.Klant.Naam).Distinct();
            var indirecteUrenNamen = currentUserBoekingen.Where(x => x.IndirecteUren != null)
                .Select(x => x.IndirecteUren.Omschrijving).Distinct();

            var totaalKlantModel = new TopRowModel
            {
                Naam =  "Totaal",
                Planning = new List<UrenModel>()
            };
            planningTableViewModel.TopRows.Add(totaalKlantModel);
            
            InitializeTopRow(klantNamen, currentUserBoekingen, planningTableViewModel);
            InitializeIndirectUren(indirecteUrenNamen, planningTableViewModel);
            var amountOfWeeks = 0;
            Dictionary<int, int> indexPerYear = null;
            var uniqueYears = currentUserBoekingen.Select(x => x.Jaar.Value).Distinct().OrderBy(x => x).ToList();
            uniqueYears.ForEach(year =>
            {
                indexPerYear ??= new Dictionary<int, int>() {{year - 1, 0}};
                var weken = currentUserBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                indexPerYear.Add(year, weken.Count);
                amountOfWeeks += weken.Count();
            });

            uniqueYears.ForEach(year =>
            {
                var yearModel = new YearModel { Year = year, Weeks = new List<WeekModel>() };
                var weken = currentUserBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                weken.ForEach(week =>
                {
                        var weekModel = new WeekModel { Weeknumber = week, StartOfWeekDay = $"({DateTimeExtensions.FirstDateOfWeekISO8601(year, week).ToString("dd-MM")})"};
                        
                        var currentUserHoursForThisWeek = currentUserBoekingen.Where(x => x.Weeknummer == week && x.Jaar == year).ToList();
                        var hoursForThisWeekGroupedByEmail = 
                            domainBoekingList.Where(x => x.Jaar == year && x.Weeknummer == week && x.Uren >= 0 && x.Medewerker?.Email?.ToLower() != currentUserEmail).GroupBy(x => x.Medewerker.Email).ToList();
                        planningTableViewModel.TopRows.First().Planning.Add( new UrenModel{ Uren = currentUserHoursForThisWeek.Select(x => x.Uren).Sum()});
                        
                        foreach (var klantModel in planningTableViewModel.TopRows.Skip(1))
                        {
                            var totalHoursForCustomer = currentUserHoursForThisWeek
                                .Where(x => x.Klant?.Naam == klantModel.Naam || x.IndirecteUren?.Omschrijving == klantModel.Naam).Sum(x => x.Uren);
                           
                            klantModel.Planning.Add(new UrenModel {Uren = totalHoursForCustomer > 0 ? totalHoursForCustomer : (int?)null});

                            foreach (var hoursForThisWeek in hoursForThisWeekGroupedByEmail)
                            {
                                var totaalDirecteUrenMedeMedewerker = hoursForThisWeek
                                    .Where(x => x.Medewerker?.Email?.ToLower() ==
                                        hoursForThisWeek.Key.ToLower() && x.Klant?.Naam == klantModel.Naam)
                                    .Sum(x => x.Uren);

                                if (totaalDirecteUrenMedeMedewerker == 0) continue;
                                
                                var medewerker = hoursForThisWeek
                                    .Where(x => x.Medewerker.Email == hoursForThisWeek.Key)
                                    .Select(x => x.Medewerker).FirstOrDefault();

                                var medewerkerNaam =
                                    $"{medewerker.Voornaam} {medewerker.TussenVoegsel} {medewerker.Achternaam}";

                                if (!klantModel.DetailRows.Exists(x => x.Naam == medewerkerNaam))
                                    klantModel.DetailRows.Add(new DetailRowModel
                                        {Naam = medewerkerNaam, Planning = new List<UrenModel>()});
                                
                                var medeMedewerker =
                                    klantModel.DetailRows.FirstOrDefault(x => x.Naam == medewerkerNaam);
                                if (medeMedewerker == null) continue;
                                
                                //Initialize planning for every week.
                                if (medeMedewerker.Planning.Count == 0 )
                                {
                                    for (int i = 0; i < amountOfWeeks; i++)
                                    {
                                        medeMedewerker.Planning.Add(new UrenModel {Uren = null});
                                    }
                                }
                                
                                var weekIndex = weken.FindIndex(x => x == week);
                                medeMedewerker.Planning[indexPerYear[year-1] + weekIndex].Uren = totaalDirecteUrenMedeMedewerker;
                            }
                        }

                        yearModel.Weeks.Add(weekModel);
                    });
                planningTableViewModel.Years.Add(yearModel);
                planningTableViewModel.TotalAmountOfWeeks = planningTableViewModel.Years.SelectMany(x => x.Weeks).Count();
            });
            return new BoekingPeriodResponse{ PersonalPlanningViewModel = planningTableViewModel};
        }

        private List<int> InitializeWeken(int currentYear ,List<int> uniqueYears, List<int> weken)
        {
            if (uniqueYears.Count == 1)
            {
                return Enumerable.Range(weken.Min(), (weken.Max() + 1 - weken.Min())).Select(n => n).ToList();
            }
            else if (uniqueYears.Any(year => year == currentYear - 1) &&
                     uniqueYears.Any(year => year == currentYear + 1))
            {
                return Enumerable.Range(1, 53).ToList();
            }
            else if (uniqueYears.Any(year => year == currentYear - 1))
            {
                return Enumerable.Range(1, weken.Max()).ToList();
            }
            else if (uniqueYears.Any(year => year == currentYear + 1))
            {
                return Enumerable.Range(weken.Min(),  (53 + 1 - weken.Min())).ToList();
            }

            return null;
        }


        private void InitializeTopRow(IEnumerable<string> topRowNamen, List<DomainModelBoeking> currentBoekingen,
            PlanningTableViewModel planningTableViewModel)
        {
            foreach (var topRowNaam in topRowNamen)
            {
                var klantModel = new TopRowModel
                {
                    Naam = topRowNaam,
                    Opdrachtleider = currentBoekingen.Where(x => x.Klant?.Naam == topRowNaam).Select(x =>
                    {
                        return $"{x.Klant?.Partner?.Voornaam} {x.Klant?.Partner?.Achternaam}";
                    }).FirstOrDefault(),
                    Total = currentBoekingen.Where(x => x.Klant?.Naam == topRowNaam ||  $"{x.Medewerker?.Voornaam} {x.Medewerker?.TussenVoegsel} {x.Medewerker?.Achternaam}" == topRowNaam).Sum(x => x.Uren).ToString(),
                    Planning = new List<UrenModel>(),
                    DetailRows = new List<DetailRowModel>()
                };

                var currentBoeking = currentBoekingen.FirstOrDefault(x =>
                    $"{x.Medewerker?.Voornaam} {x.Medewerker?.TussenVoegsel} {x.Medewerker?.Achternaam}" == topRowNaam);
                if (currentBoeking != null)
                {
                    klantModel.Functie = currentBoeking.Medewerker.MedewerkerFunctie.DisplayName;
                }

                planningTableViewModel.TopRows.Add(klantModel);
            }
        }

        public async Task<BoekingPeriodResponse> GetKlantBoekingenWithinPeriod(DateTime start, DateTime end, string email, int? teamId, List<int> klantIds)
        { 
            if (teamId == null)
            {
                teamId = _medewerkerRepository.GetDomainModelMedewerker(email).TeamId;
            }

            var domainBoekingList = await _boekingRepository.GetBoekingenWithinPeriodForKlant(start, end, teamId, klantIds, null);

            var planningTableViewModel = new PlanningTableViewModel
            {
                Years = new List<YearModel>(),
                TopRows = new List<TopRowModel>()
            };

            var currentBoekingen = domainBoekingList.OrderBy(x => x.Jaar).ThenBy(x => x.Weeknummer).ThenBy(x => x.Klant?.Naam).ThenBy(x => x.IndirecteUren?.Omschrijving).ToList();
            var klantNamen = currentBoekingen.Where(x => x.Klant != null).Select(x => x.Klant.Naam).Distinct();
            var indirecteUrenNamen = currentBoekingen.Where(x => x.IndirecteUren != null)
                .Select(x => x.IndirecteUren.Omschrijving).Distinct();

            InitializeTopRow(klantNamen, currentBoekingen, planningTableViewModel);
            InitializeIndirectUren(indirecteUrenNamen, planningTableViewModel);

            var amountOfWeeks = 0;
            Dictionary<int, int> indexPerYear = null;
            var uniqueYears = currentBoekingen.Select(x => x.Jaar.Value).Distinct().OrderBy(x => x).ToList();
            uniqueYears.ForEach(year =>
            {
                indexPerYear ??= new Dictionary<int, int>() {{year - 1, 0}};
                var weken = currentBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                indexPerYear.Add(year, weken.Count);
                amountOfWeeks += weken.Count();
            });

            uniqueYears.ForEach(year =>
            {
                var yearModel = new YearModel { Year = year, Weeks = new List<WeekModel>() };
                var weken = currentBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                weken.ForEach(week =>
                    {
                        var weekModel = new WeekModel { Weeknumber = week, StartOfWeekDay = $"({DateTimeExtensions.FirstDateOfWeekISO8601(year, week).ToString("dd-MM")})"};
                        
                        var currentUserHoursForThisWeek = currentBoekingen.Where(x => x.Weeknummer == week && x.Jaar == year).ToList();
                        var hoursForThisWeekGroupedByEmail = 
                            domainBoekingList.Where(x => x.Jaar == year && x.Weeknummer == week).GroupBy(x => x.Medewerker.Email).ToList();
                        
                        foreach (var klantModel in planningTableViewModel.TopRows)
                        {
                            var totalHoursForCustomer = currentUserHoursForThisWeek
                                .Where(x => x.Klant?.Naam == klantModel.Naam || x.IndirecteUren?.Omschrijving == klantModel.Naam).Sum(x => x.Uren);
                           
                            klantModel.Planning.Add(new UrenModel {Uren = totalHoursForCustomer > 0 ? totalHoursForCustomer : (int?)null});

                            foreach (var hoursForThisWeek in hoursForThisWeekGroupedByEmail)
                            {
                                var totaalDirecteUrenMedeMedewerker = hoursForThisWeek
                                    .Where(x => x.Medewerker?.Email?.ToLower() ==
                                        hoursForThisWeek.Key.ToLower() && x.Klant?.Naam == klantModel.Naam ||  x.IndirecteUren?.Omschrijving == klantModel.Naam)
                                    .Sum(x => x.Uren);

                                if (totaalDirecteUrenMedeMedewerker == 0) continue;
                                
                                var medewerker = hoursForThisWeek
                                    .Where(x =>  x.Medewerker?.Email?.ToLower() == hoursForThisWeek.Key.ToLower())
                                    .Select(x => x.Medewerker).FirstOrDefault();

                                var medewerkerNaam =
                                    $"{medewerker.Voornaam} {medewerker.TussenVoegsel} {medewerker.Achternaam}";

                                if (!klantModel.DetailRows.Exists(x => x.Naam == medewerkerNaam))
                                    klantModel.DetailRows.Add(new DetailRowModel
                                        {Naam = medewerkerNaam, Planning = new List<UrenModel>()});
                                
                                var medeMedewerker =
                                    klantModel.DetailRows.FirstOrDefault(x => x.Naam == medewerkerNaam);
                                if (medeMedewerker == null) continue;

                                //Initialize planning for every week.
                                if (medeMedewerker.Planning.Count == 0)
                                {
                                    for (int i = 0; i < amountOfWeeks; i++)
                                    {
                                        medeMedewerker.Planning.Add(new UrenModel {Uren = null});
                                    }
                                }
                                var weekIndex = weken.FindIndex(x => x == week);
                                medeMedewerker.Planning[indexPerYear[year -1] + weekIndex].Uren = totaalDirecteUrenMedeMedewerker;
                                
                            }
                        }

                        yearModel.Weeks.Add(weekModel);
                    });
                planningTableViewModel.Years.Add(yearModel);
                planningTableViewModel.TotalAmountOfWeeks = planningTableViewModel.Years.SelectMany(x => x.Weeks).Count();
            });
            return new BoekingPeriodResponse{ PersonalPlanningViewModel = planningTableViewModel};
        }

        public async Task<BoekingPeriodResponse> GetMedewerkerBoekingenWithinPeriod(DateTime start, DateTime end, string email, int? teamId, List<int> medewerkerIds)
        {
            if (teamId == null)
            {
                teamId = _medewerkerRepository.GetDomainModelMedewerker(email).TeamId;
            }

            var domainBoekingList = await _boekingRepository.GetBoekingenWithinPeriod(start, end, teamId, null, medewerkerIds);

            var planningTableViewModel = new PlanningTableViewModel
            {
                Years = new List<YearModel>(),
                TopRows = new List<TopRowModel>()
            };

            var currentBoekingen = domainBoekingList.OrderBy(x => x.Jaar).ThenBy(x => x.Weeknummer).ThenBy(x => x.Klant?.Naam).ThenBy(x => x.IndirecteUren?.Omschrijving).ToList();
            var medewerkerNamen = currentBoekingen.Where(x => x.Medewerker != null).Select(x => $"{x.Medewerker?.Voornaam} {x.Medewerker?.TussenVoegsel} {x.Medewerker?.Achternaam}").Distinct();

            InitializeTopRow(medewerkerNamen, currentBoekingen, planningTableViewModel);
            
            var amountOfWeeks = 0;
            Dictionary<int, int> indexPerYear = null;
            var uniqueYears = currentBoekingen.Select(x => x.Jaar.Value).Distinct().OrderBy(x => x).ToList();
            uniqueYears.ForEach(year =>
            {
                indexPerYear ??= new Dictionary<int, int>() {{year - 1, 0}};
                var weken = currentBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                indexPerYear.Add(year, weken.Count);
                amountOfWeeks += weken.Count();
            });

            uniqueYears.ForEach(year =>
            {
                var yearModel = new YearModel { Year = year, Weeks = new List<WeekModel>() };
                var weken = currentBoekingen.Where(x => x.Jaar.Value == year).Select(x => x.Weeknummer.Value).Distinct().ToList();
                weken = InitializeWeken(year, uniqueYears, weken);
                weken.ForEach(week =>
                    {
                        var weekModel = new WeekModel { Weeknumber = week, StartOfWeekDay = $"({DateTimeExtensions.FirstDateOfWeekISO8601(year, week).ToString("dd-MM")})"};
                        var currentBoekingenForWeek = currentBoekingen.Where(x => x.Weeknummer == week && x.Jaar == year).ToList();
                        
                        foreach (var medewerkerTopRow in planningTableViewModel.TopRows)
                        {
                            var medewerkerBoekingenForWeek = currentBoekingenForWeek.Where(x =>
                                $"{x.Medewerker?.Voornaam} {x.Medewerker?.TussenVoegsel} {x.Medewerker?.Achternaam}" ==
                                medewerkerTopRow.Naam).ToList();

                            var totalMedewerkerHours = medewerkerBoekingenForWeek.Sum(x => x.Uren);
                            medewerkerTopRow.Planning.Add(new UrenModel {Uren = totalMedewerkerHours > 0 ? totalMedewerkerHours : (int?)null});

                            foreach (var boeking in medewerkerBoekingenForWeek)
                            {
                                if (boeking.Uren == 0) continue;
                                if (boeking.Klant == null && boeking.IndirecteUren == null) continue;
                                var boekingNaam = boeking.Klant == null ? boeking.IndirecteUren.Omschrijving : boeking.Klant.Naam;

                                if (!medewerkerTopRow.DetailRows.Exists(x => x.Naam == boekingNaam))
                                    medewerkerTopRow.DetailRows.Add(new DetailRowModel
                                        {Naam = boekingNaam, Planning = new List<UrenModel>()});
                                
                                var klantRow = medewerkerTopRow.DetailRows.FirstOrDefault(x => x.Naam == boekingNaam);
                                if (klantRow == null) continue;

                                //Initialize planning for every week.
                                if (klantRow.Planning.Count == 0)
                                {
                                    for (int i = 0; i < amountOfWeeks; i++)
                                    {
                                        klantRow.Planning.Add(new UrenModel {Uren = null});
                                    }
                                }
                                var weekIndex = weken.FindIndex(x => x == week);
                                klantRow.Planning[indexPerYear[year-1] + weekIndex].Uren = boeking.Uren;
                            }

                            medewerkerTopRow.DetailRows = medewerkerTopRow.DetailRows.OrderBy(x => x.Naam).ToList();
                        }
                        yearModel.Weeks.Add(weekModel);
                    });
                planningTableViewModel.Years.Add(yearModel);
                planningTableViewModel.TotalAmountOfWeeks = planningTableViewModel.Years.SelectMany(x => x.Weeks).Count();
                planningTableViewModel.TopRows = planningTableViewModel.TopRows.OrderBy(x => x.Naam).ToList();
            });
            return new BoekingPeriodResponse{ PersonalPlanningViewModel = planningTableViewModel};
        }

        private void InitializeIndirectUren(IEnumerable<string> indirecteUrenNamen, PlanningTableViewModel planningTableViewModel)
        {
            foreach (var indirectUrenNaam in indirecteUrenNamen)
            {
                var klantModel = new TopRowModel
                {
                    Naam = indirectUrenNaam,
                    Planning = new List<UrenModel>(),
                    DetailRows = new List<DetailRowModel>()
                };
                planningTableViewModel.TopRows.Add(klantModel);
            }
        }

        public async Task<BookingDetailResponse> GetDetailBoekingenWithingPeriod(DateTime start, DateTime end, string email, int? teamId)
        {
            var medewerkerTeamId = _medewerkerRepository.GetDomainModelMedewerker(email).TeamId;
 
            var domainBoekingList = await _boekingRepository.GetBoekingenWithinPeriod(start, end, teamId, null, null);

            var bookingsDetail = new List<BookingDetailViewModel>();
            foreach (var domainBoeking in domainBoekingList)
            {
                var canBeEdited = domainBoeking.Klant?.VerantwoordelijkTeam.Id == medewerkerTeamId || domainBoeking.IsIndirect && domainBoeking.Medewerker.TeamId == medewerkerTeamId;
                if (!canBeEdited)
                {
                    var customerShouldBeEditableByThisTeam =
                        domainBoeking.Klant?.PlanbaarDoorTeams?.Any(x => x.TeamId == medewerkerTeamId);
                    var medewerkerShouldBePlannableByThisTeam = 
                                                      domainBoeking.Medewerker?.PlanbaarDoorTeams?.Any(mpb => mpb.TeamId == medewerkerTeamId);
                    if (customerShouldBeEditableByThisTeam.HasValue)
                    {
                        canBeEdited = customerShouldBeEditableByThisTeam.Value;
                    }
                    if (medewerkerShouldBePlannableByThisTeam.HasValue)
                    {
                        canBeEdited = medewerkerShouldBePlannableByThisTeam.Value || domainBoeking.Medewerker.TeamId == medewerkerTeamId;
                    }
                }
                bookingsDetail.Add(new BookingDetailViewModel()
                    {
                        Id = domainBoeking.Id,
                        MedewerkerId = domainBoeking.MedewerkerId,
                        KlantId = domainBoeking.KlantId,
                        OpdrachtId = domainBoeking.OpdrachtId,
                        IndirecteUrenId = domainBoeking.IndirecteUrenId,
                        Weeknummer = domainBoeking.Weeknummer,
                        Jaar = domainBoeking.Jaar,
                        Uren = domainBoeking.Uren,
                        KlantNaam = domainBoeking.Klant?.Naam,
                        CanBeEdited = canBeEdited,
                        PlannedDate = domainBoeking.Datum,
                        MedewerkerNaam = $"{domainBoeking.Medewerker?.Voornaam} {domainBoeking.Medewerker?.TussenVoegsel} {domainBoeking.Medewerker?.Achternaam}",
                        MedewerkerFunctie =  domainBoeking.Medewerker?.MedewerkerFunctie?.DisplayName,
                        OpdrachtNaam = domainBoeking.Opdracht?.Omschrijving,
                        IndirecteUrenNaam = domainBoeking.IndirecteUren?.Omschrijving,
                        Boekjaar = domainBoeking.Boekjaar,
                        GeboektOp = domainBoeking.IndirecteUren == null ? domainBoeking.Klant?.Naam : domainBoeking.IndirecteUren.Omschrijving,
                        TeamNaam = domainBoeking.Medewerker?.Team?.Naam
                    });
            }

            bookingsDetail = bookingsDetail.OrderBy(x => x.Jaar).ThenBy(x => x.Weeknummer).ThenBy(x => x.MedewerkerNaam).ThenBy(x => x.KlantNaam).ToList();
            return new BookingDetailResponse{  BookingsDetail = bookingsDetail};
        }

        public async Task<BoekingResponse> AddBoeking(DomainModelBoeking domainModelBoeking)
        {
            var typeBoeking = string.Empty;

            typeBoeking = EnhanceFrontEndBoekingData(domainModelBoeking, typeBoeking);

            var resultBaseResponse = await _boekingRepository.AddBoeking(domainModelBoeking);
            return new BoekingResponse (int.Parse(resultBaseResponse.Id), true, $"Het toevoegen van het de nieuwe boeking voor: {typeBoeking} in week: {domainModelBoeking.Weeknummer} en jaar: {domainModelBoeking.Jaar} is gelukt.");

        }

        public async Task<BoekingResponse> AddBoekingen(List<DomainModelBoeking> domainModelBoekingen)
        {
            var boekingResultaten = new List<string>();
            foreach (var domainModelBoeking in domainModelBoekingen)
            {
                var typeBoeking = string.Empty;

                typeBoeking = EnhanceFrontEndBoekingData(domainModelBoeking, typeBoeking);

                await _boekingRepository.AddBoeking(domainModelBoeking);
                boekingResultaten.Add($"Het toevoegen van het de nieuwe boeking voor: {typeBoeking} in week: {domainModelBoeking.Weeknummer} en jaar: {domainModelBoeking.Jaar} is gelukt.");
            }

            return new BoekingResponse(1, true, string.Join(',', boekingResultaten));
        }

        private static string EnhanceFrontEndBoekingData(DomainModelBoeking domainModelBoeking, string typeBoeking)
        {
//Add additional required information.
            if (domainModelBoeking.Jaar.HasValue && domainModelBoeking.Weeknummer.HasValue)
            {
                var firstDateOfWeek = DateTimeExtensions.FirstDateOfWeekISO8601(domainModelBoeking.Jaar.Value,
                    domainModelBoeking.Weeknummer.Value);
                domainModelBoeking.Maand = firstDateOfWeek.Month;
                domainModelBoeking.EersteDagVanDeWeek = firstDateOfWeek.Day;
            }

            if (!domainModelBoeking.Jaar.HasValue && !domainModelBoeking.Weeknummer.HasValue)
                domainModelBoeking.MoetNogGeplandWorden = true;

            if (domainModelBoeking.KlantId.HasValue)
            {
                typeBoeking = "directe uren";
            }

            if (domainModelBoeking.IndirecteUrenId.HasValue)
            {
                typeBoeking = "indirecte uren";
                domainModelBoeking.IsIndirect = true;
            }

            return typeBoeking;
        }

        public async Task<ExcelExportResponse> ExportBoekingenToExcel(DateTime fromDate, DateTime tillDate, string email, int? teamId)
        {
            var boekingenWithinPeriod = await GetDetailBoekingenWithingPeriod(fromDate, tillDate, email, teamId);
            var exportBoekingModel = boekingenWithinPeriod.BookingsDetail.Select(boeking => 
                new
                {
                    boeking.Jaar, 
                    boeking.Weeknummer,
                    boeking.Uren, GeboektOp = string.IsNullOrEmpty(boeking.KlantNaam) ? boeking.IndirecteUrenNaam : boeking.KlantNaam, 
                    Opdracht = boeking.OpdrachtNaam,  
                    Medewerker = boeking.MedewerkerNaam, 
                    Functie = boeking.MedewerkerFunctie,
                    Team = boeking.TeamNaam
                });
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            var excelResponse = new ExcelExportResponse();
            excelResponse.FileInfo = new FileInfo(@"C:\Temp\BoekingExport.xlsx");
            using var excelPack = new ExcelPackage();
            var ws = excelPack.Workbook.Worksheets.Add("Boeking export");
            ws.Cells.LoadFromCollection(exportBoekingModel, true, OfficeOpenXml.Table.TableStyles.Light8);
            excelResponse.Bytes = excelPack.GetAsByteArray();

            return excelResponse;
        }

        public async Task<BoekingResponse> UpdateBoeking(DomainModelBoeking domainModelBoeking)
        {
            var typeBoeking = string.Empty;

            typeBoeking = EnhanceFrontEndBoekingData(domainModelBoeking, typeBoeking);

            var resultBaseResponse = await _boekingRepository.UpdateBoeking(domainModelBoeking);
            return new BoekingResponse (int.Parse(resultBaseResponse.Id), true, $"Het updaten van de boeking voor: {typeBoeking} in week: {domainModelBoeking.Weeknummer} en jaar: {domainModelBoeking.Jaar} is gelukt.");
        }

        public async Task<BoekingResponse> DeleteBoeking(int id)
        {
           await _boekingRepository.DeleteBoeking(id);
           return new BoekingResponse (id, true, $"Het verwijderen van de boeking is gelukt.");
        }
    }
}