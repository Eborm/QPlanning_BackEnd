using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QPlanning.Api.Controllers.Base;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Command;

namespace QPlanning.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : BaseControllerWithMediatR
	{

		public AuthController(IMediator mediator) : base(mediator) { }
		
		//POST api/auth/login
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] LoginCommand command)
		{
			var result = await Mediator.Send(command);
			return result.Success ? Ok(result) : (ObjectResult)BadRequest(result);
		}
	}
}