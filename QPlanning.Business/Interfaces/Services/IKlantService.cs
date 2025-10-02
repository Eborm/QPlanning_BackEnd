using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IKlantService
    {
        Task<BaseResponse> AddKlant(DomainModelKlant klant);
        Task<BaseResponse> EditKlant(DomainModelKlant klant);
        Task<List<DomainModelKlant>> GetKlantenForTeam(int? teamId);

        List<int> GetBoekjarenVoorKlant(int klantId);
        
        Task<DomainModelKlant> GetKlant(int klantId);


    }
}