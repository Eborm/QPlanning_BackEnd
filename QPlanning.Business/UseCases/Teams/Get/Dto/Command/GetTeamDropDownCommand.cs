using MediatR;
using QPlanning.Business.UseCases.Teams.Get.Dto.Response;

namespace QPlanning.Business.UseCases.Teams.Get.Dto.Command
{
    public class GetTeamDropDownCommand: IRequest<TeamDropDownResponse>
    {
        public string Email { get; set; }
    }
}