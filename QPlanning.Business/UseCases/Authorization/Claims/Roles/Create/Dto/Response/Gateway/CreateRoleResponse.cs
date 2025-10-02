using System.Collections.Generic;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.GatewayReponses;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Response.Gateway
{
	public class CreateRoleResponse : BaseGatewayResponse
	{
		public string Id { get; }
		public CreateRoleResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
		{
			Id = id;
		}
	}
}
