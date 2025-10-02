using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.UseCases.Medewerkers.Add.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Edit.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Get.Dto.Command;
using QPlanning.Business.UseCases.Medewerkers.Toggle.Dto.Command;

namespace QPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedewerkerController : BaseControllerWithMediatR
    {
        public MedewerkerController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [Route("getMedewerkers")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetMedewerkers([FromQuery] GetMedewerkersCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Medewerkers != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        [HttpGet]
        [Route("getDropDownValues")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetDropDownValues([FromQuery] GetMedewerkerDropDownCommand command)
        {
            var result = await Mediator.Send(command);
            return result.MedewerkerFunctieDropDown != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/medewerker/add
        [HttpPost]
        [Route("add")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Add(AddMedewerkerCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Put api/medewerker/update
        [HttpPut]
        [Route("update")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Update(EditMedewerkerCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/medewerker/delete
        [HttpPost]
        [Route("delete")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Delete(DeleteMedewerkerCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
    }
}