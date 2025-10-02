using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
    public interface IBoekingRepository
    {
        Task<List<DomainModelBoeking>> GetBoekingenWithinPeriod(DateTime start, DateTime end, int? teamId, List<int> klantIds, List<int> medewerkerId);

        Task<List<DomainModelBoeking>> GetBoekingenWithinPeriodForKlant(DateTime start, DateTime end, int? teamId,
            List<int> klantIds, List<int> medewerkerIds);
        Task<List<DomainModelBoeking>> GetBoekingenWithinPeriodForMedewerker(DateTime start, DateTime end, int medewerkerId);
        Task<BaseResponse> AddBoeking(DomainModelBoeking domainModelBoeking);
        Task<BaseResponse> UpdateBoeking(DomainModelBoeking domainModelBoeking);

        Task<BaseResponse> DeleteBoeking(int id);
    }
}