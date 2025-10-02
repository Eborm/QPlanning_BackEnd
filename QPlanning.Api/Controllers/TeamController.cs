using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.UseCases.Teams.Get.Dto.Command;

namespace QPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : BaseControllerWithMediatR
    {
        public TeamController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [Route("getDropDownValues")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetDropDownValues([FromQuery] GetTeamDropDownCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.TeamDropDown != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
    }
}