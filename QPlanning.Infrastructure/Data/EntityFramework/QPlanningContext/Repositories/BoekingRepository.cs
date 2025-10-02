using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using QPlanning.Infrastructure.Helpers;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class BoekingRepository : IBoekingRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public BoekingRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<List<DomainModelBoeking>> GetBoekingenWithinPeriodForMedewerker(DateTime start, DateTime end, int medewerkerId)
        {
            var klanten =
               await _qDbContext.Boeking.Where(x => x.Datum >= start && x.Datum <= end && x.MedewerkerId == medewerkerId).Select(x => x.KlantId).ToListAsync();
            
            var  bookingsWithinPeriod =  _qDbContext.Boeking.AsNoTracking()
                .Include(x => x.Medewerker)
                    .ThenInclude(x => x.Team)
                .Include(x => x.Medewerker)
                    .ThenInclude(x => x.MedewerkerFunctie)
                .Include(x => x.Opdracht)
                .Include(x => x.IndirecteUren)
                .Include(x => x.Klant)
                    .ThenInclude(x => x.VerantwoordelijkTeam)
                .Include(x => x.Klant)
                    .ThenInclude(x => x.Partner)
                .Where(x => x.Datum >= start && x.Datum <= end && klanten.Contains(x.KlantId)).AsQueryable();
            
            var boekingenWithinPeriod = await bookingsWithinPeriod.ToListAsync();
            return _mapper.Map<List<DomainModelBoeking>>(boekingenWithinPeriod);
        }
        
        public async Task<List<DomainModelBoeking>> GetBoekingenWithinPeriodForKlant(DateTime start, DateTime end, int? teamId, List<int> klantIds, List<int> medewerkerIds)
        {
            var klanten = _qDbContext.Klant
                .Include(x => x.VerantwoordelijkTeam)
                .Include(x => x.PlanbaarDoorTeams)
                .ThenInclude(x => x.Team)
                .Select(klant => klant.Id)
                .AsQueryable();
            
            if (teamId.HasValue)
            {
                klanten = _qDbContext.Klant
                    .Include(x => x.VerantwoordelijkTeam)
                    .Include(x => x.PlanbaarDoorTeams)
                    .ThenInclude(x => x.Team)
                    .Where(x => x.VerantwoordelijkTeam.Id == teamId.Value ||
                                x.PlanbaarDoorTeams.Any(x => x.TeamId == teamId.Value))
                    .Select(klant => klant.Id)
                    .AsQueryable();
            }

            var currentKlantIds = klanten.ToList();
            
            var  bookingsWithinPeriod =  _qDbContext.Boeking.AsNoTracking()
                .Include(x => x.Medewerker)
                .ThenInclude(x => x.Team)
                .Include(x => x.Medewerker)
                .ThenInclude(x => x.MedewerkerFunctie)
                .Include(x => x.Medewerker.PlanbaarDoorTeams)
                .ThenInclude(mwpt => mwpt.Team)
                .Include(x => x.Opdracht)
                .Include(x => x.IndirecteUren)
                .Include(x => x.Klant)
                .ThenInclude(kl => kl.VerantwoordelijkTeam)
                .Include(x => x.Klant.PlanbaarDoorTeams)
                .ThenInclude(pt => pt.Team)
                .Where(x => x.Datum >= start && x.Datum <= end && currentKlantIds.Contains(x.KlantId.Value)).AsQueryable();

            if (klantIds != null)
            { 
                bookingsWithinPeriod = bookingsWithinPeriod.Where(x => klantIds.Contains(x.KlantId.Value)); 
            }
            
            if (medewerkerIds != null)
            {
                bookingsWithinPeriod = bookingsWithinPeriod.Where(x => medewerkerIds.Contains(x.MedewerkerId));
            }

            var boekingenWithinPeriod = await bookingsWithinPeriod.ToListAsync();
            return _mapper.Map<List<DomainModelBoeking>>(boekingenWithinPeriod);
        }

        public async Task<List<DomainModelBoeking>> GetBoekingenWithinPeriod(DateTime start, DateTime end, int? teamId, List<int> klantIds, List<int> medewerkerIds)
        {
            var  bookingsWithinPeriod =  _qDbContext.Boeking.AsNoTracking()
                .Include(x => x.Medewerker)
                    .ThenInclude(x => x.Team)
                .Include(x => x.Medewerker)
                    .ThenInclude(x => x.MedewerkerFunctie)
                .Include(x => x.Medewerker.PlanbaarDoorTeams)
                    .ThenInclude(mwpt => mwpt.Team)
                .Include(x => x.Opdracht)
                .Include(x => x.IndirecteUren)
                .Include(x => x.Klant)
                    .ThenInclude(kl => kl.VerantwoordelijkTeam)
                .Include(x => x.Klant.PlanbaarDoorTeams)
                    .ThenInclude(pt => pt.Team)
                .Where(x => x.Datum >= start && x.Datum <= end).AsQueryable();

            if (teamId.HasValue)
            {
                if (teamId.Value != 0)
                {
                    bookingsWithinPeriod = bookingsWithinPeriod.Where(x => x.Medewerker.TeamId == teamId.Value);
                }
                // Haal alle teams op.
            }

            if (klantIds != null)
            { 
                bookingsWithinPeriod = bookingsWithinPeriod.Where(x => klantIds.Contains(x.KlantId.Value)); 
            }
            
            if (medewerkerIds != null)
            {
                bookingsWithinPeriod = bookingsWithinPeriod.Where(x => medewerkerIds.Contains(x.MedewerkerId));
            }

            var boekingenWithinPeriod = await bookingsWithinPeriod.ToListAsync();
            return _mapper.Map<List<DomainModelBoeking>>(boekingenWithinPeriod);
        }

        public async Task<BaseResponse> AddBoeking(DomainModelBoeking domainModelBoeking)
        {
            var boeking = _mapper.Map<Boeking>(domainModelBoeking);
            await _qDbContext.Boeking.AddAsync(boeking);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true, null);
        }
        
        public async Task<BaseResponse> UpdateBoeking(DomainModelBoeking domainModelBoeking)
        {
            var boeking = _mapper.Map<Boeking>(domainModelBoeking);
            _qDbContext.Boeking.Update(boeking);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true, null);
        }

        public async Task<BaseResponse> DeleteBoeking(int id)
        {
            var boeking = GetBoeking(id);
            _qDbContext.Boeking.Remove(boeking);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true, null);
        }

        private Boeking GetBoeking(int id)
        {
           return  _qDbContext.Boeking.FirstOrDefault(b => b.Id == id);
        }
    }
}