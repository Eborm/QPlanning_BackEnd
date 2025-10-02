using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Models;

namespace QPlanning.Business.Interfaces.Services
{
    public interface IMedewerkerService
    {
        Task<IList<MedewerkerViewModel>> GetMedewerkers();

        Task<BaseResponse> AddMedewerker(AddMedewerkerCommand addMedewerkerCommand);
        Task<BaseResponse> EditMewerker(EditMedewerkerCommand editMedewerkerCommand);
        Task<BaseResponse> ToggleActiveMedwerker(int Id, bool shouldBeActive);
    }
}