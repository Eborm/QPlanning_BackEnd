using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Commands;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Command;

namespace QPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KlantController : BaseControllerWithMediatR
    {
        public KlantController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [Route("getKlanten")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetKlanten([FromQuery] GetKlantenCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.Klanten != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        [HttpGet]
        [Route("getDropDownValues")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetDropDownValues([FromQuery] GetKlantDownDownCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.TeamDropDown != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/medewerker/add
        [HttpPost]
        [Route("add")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Add(AddKlantCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Put api/medewerker/update
        [HttpPut]
        [Route("update")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Update(EditKlantCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
    }
}