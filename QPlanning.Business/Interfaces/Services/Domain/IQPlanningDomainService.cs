using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.UseCases.Boeking.Get.Dto;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Response;
using QPlanning.Business.UseCases.Teams.Get.Dto.Response;

namespace QPlanning.Business.Interfaces.Services.Domain
{
    public interface IQPlanningDomainService
    {
        Task<BoekingDropDownResponse> GetBoekingDropDownValues(string email);
        
        Task<TeamDropDownResponse> GetTeamDropDownValues(string email);
        Task<MedewerkerDropDownResponse> GetMedewerkerDropDownValues();

        Task<GetKlantDropDownResponse> GetKlantDropDownValues(string email);
        
        Task<GetKlantenResponse> GetKlantenForTeam(string email);
    }
}