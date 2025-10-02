using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
    public interface IMedewerkerRepository
    {
        Task<IList<DomainModelMedewerker>> GetMedewerkers();

        Task<BaseResponse> AddMedewerker(DomainModelMedewerker domainModelMedewerker);
        Task<BaseResponse> EditMewewerker(DomainModelMedewerker domainModelMedewerker);

        Task<BaseResponse> ToggleActiveMedwerker(int id, bool shouldBeActive);

        DomainModelMedewerker GetDomainModelMedewerker(string email);
    }
}