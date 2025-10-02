using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.UseCases.Boeking.Add.Dto;
using QPlanning.Business.UseCases.Boeking.Delete.Dto;
using QPlanning.Business.UseCases.Boeking.Get;
using QPlanning.Business.UseCases.Boeking.Get.Dto;
using QPlanning.Business.UseCases.Boeking.Update.Dto;

namespace QPlanning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoekingController : BaseControllerWithMediatR
    {
        public BoekingController(IMediator mediator) : base(mediator)
        {
        }
        
        //Post api/boeking/getBoekingWithinPeriod
        [HttpGet]
        [Route("getBookyears")]
        [Authorize(Policy = Policies.AtLeastMedewerker)]
        public async Task<ActionResult> getBookyears([FromQuery] GetBoekjarenCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Boekjaren != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/getBoekingWithinPeriod
        [HttpPost]
        [Route("getPersonalBoekingWithinPeriod")]
        [Authorize(Policy = Policies.AtLeastMedewerker)]
        public async Task<ActionResult> GetPersonalBoekingWithinPeriod(GetPersonalBoekingenCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.PersonalPlanningViewModel != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/getBoekingWithinPeriod
        [HttpPost]
        [Route("getKlantBoekingWithinPeriod")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetBoekingWithinPeriod(GetKlantBoekingenCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.PersonalPlanningViewModel != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/getBoekingWithinPeriod
        [HttpPost]
        [Route("getMedewerkerBoekingWithinPeriod")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetBoekingWithinPeriod(GetMedewerkerBoekingenCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.PersonalPlanningViewModel != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/getDetailBoekingWithinPeriod
        [HttpPost]
        [Route("getDetailBoekingWithinPeriod")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetDetailBoekingWithinPeriod(GetBookingDetailCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.BookingsDetail != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        [HttpGet]
        [Route("getDropDownValues")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> GetDropDownValues([FromQuery] GetBoekingDropDownCommand command)
        {
            command.Email = User.Identity.Name;
            var result = await Mediator.Send(command);
            return result.KlantDropDown != null ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/add
        [HttpPost]
        [Route("add")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Add(AddBoekingCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Put api/boeking/update
        [HttpPut]
        [Route("update")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Update(UpdateBoekingCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        //Post api/boeking/delete
        [HttpPost]
        [Route("delete")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<ActionResult> Delete(DeleteBoekingCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
        }
        
        [HttpGet]
        [Route("getBoekingExcelExport")]
        [Authorize(Policy = Policies.ElevatedRights)]
        public async Task<FileResult> GetBoekingExcelExport(DateTime startDate, DateTime endDate, int? teamId )
        {
            var command = new GetBoekingExportCommand { StartDate = startDate, EndDate = endDate, Email = User.Identity.Name, TeamId = teamId};
            var result = await Mediator.Send(command);

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            var fileContentResult = new FileContentResult(result.Bytes, contentType)
            {
                FileDownloadName = result.FileInfo.Name
            };

            return  fileContentResult;
        }

    }
}