using System.Collections.Generic;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.GatewayReponses;

namespace QPlanning.Business.Dto.Response.Gateway
{
	public class CreateUserResponse : BaseGatewayResponse
	{
		public string Id { get; }
		public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
		{
			Id = id;
		}
	}
}
