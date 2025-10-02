using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QPlanning.Api.Controllers.Base
{
	public class BaseControllerWithMediatR : ControllerBase
	{
		public IMediator Mediator { get; protected set; }

		public BaseControllerWithMediatR(IMediator mediator)
		{
			Mediator = mediator;
		}
	}
}
