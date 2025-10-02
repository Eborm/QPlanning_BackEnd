using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using QPlanning.Common.Auth;
using QPlanning.Api.Controllers.Base;
using MediatR;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business.Dto.Commands;
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Command;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Command;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Command;

namespace QPlanning.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : BaseControllerWithMediatR
	{

		public AccountController(IMediator mediator) : base(mediator) { }

		// POST api/account
		[HttpPost]
		[Authorize(Policy = Policies.AdminOnly)]
		[Route("add")]
		public async Task<ActionResult> Add([FromBody] CreateUserCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
		
		// PUT api/account
		[HttpPut]
		[Authorize(Policy = Policies.AdminOnly)]
		[Authorize(Policy = "ElevatedRights")]
		[Route("update")]
		public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
		
		// POST api/account
		[HttpPost]
		[Authorize(Policy = Policies.AdminOnly)]
		[Route("delete")]
		public async Task<ActionResult> Delete([FromBody] DeleteUserCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
		
		
		// POST api/account/resetPassword
		[HttpPost]
		[Authorize(Policy = Policies.AtLeastMedewerker)]
		[Route("resetPassword")]
		public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}

		// Get api/account/getAllRoles
		[HttpGet]
		[Route("getAllRoles")]
		[Authorize(Policy = Policies.AdminOnly)]
		public ActionResult GetAllRoles()
		{
			return Ok(UserRole.AllRoles);
		}
		
		// Get api/account/getAllRoles
		[HttpGet]
		[Route("getAllUsers")]
		[Authorize(Policy = Policies.AdminOnly)]
		public async Task<ActionResult> GetAllUsers()
		{
			var result = await Mediator.Send(new GetAllUserCommand());
			return result.Users.Any() ? Ok(result) : (ObjectResult)BadRequest(result);
		}

		// Post api/account/addClaimRoleToUser
		[HttpPost]
		[Authorize(Policy = Policies.AdminOnly)]
		[Route("addClaimRoleToUser")]
		public async Task<ActionResult> AddClaimRoleToUser([FromBody] CreateRoleCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
		
		// Post api/account/addClaimRoleToUser
		[HttpPost]
		[Authorize(Policy = Policies.AdminOnly)]
		[Route("deleteClaimRoleFromUser")]
		public async Task<ActionResult> RemoveClaimRoleToUser([FromBody] DeleteRoleCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
	}
}
