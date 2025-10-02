using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.UseCases.Boekjaar.Add.Dto.Command;

namespace QPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoekjaarController: BaseControllerWithMediatR
    {
        public BoekjaarController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpPost]
        [Route("add")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> AddBoekjaren([FromBody] AddBoekjaarCommand command)
        {
            var result = await Mediator.Send(command);
            return result != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
    }
}