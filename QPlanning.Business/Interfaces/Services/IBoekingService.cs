using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.Dto.Response.UseCase;
using QPlanning.Business.UseCases.Boeking.Dto;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IBoekingService
    {
        Task<BoekingPeriodResponse> GetPersonalBoekingenWithinPeriod(DateTime start, DateTime end, string email);
        Task<BoekingPeriodResponse> GetKlantBoekingenWithinPeriod(DateTime start, DateTime end, string email, int? teamId, List<int> klantIds);
        
        Task<BoekingPeriodResponse> GetMedewerkerBoekingenWithinPeriod(DateTime start, DateTime end, string email, int? teamId, List<int> medewerkerIds);
        Task<BookingDetailResponse> GetDetailBoekingenWithingPeriod(DateTime start, DateTime end, string email, int? teamId);
        Task<BoekingResponse> AddBoeking(DomainModelBoeking domainModelBoeking);
        
        Task<BoekingResponse> AddBoekingen(List<DomainModelBoeking> domainModelBoeking);
        
        Task<BoekingResponse> UpdateBoeking(DomainModelBoeking domainModelBoeking);

        Task<BoekingResponse> DeleteBoeking(int id);
        Task<ExcelExportResponse> ExportBoekingenToExcel(DateTime start, DateTime end, string email, int? teamId);
    }
}