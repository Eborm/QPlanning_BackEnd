using System.Collections.Generic;

namespace QPlanning.Business.Dto.Base.GatewayReponses
{
	public class BaseGatewayResponse
	{
		protected BaseGatewayResponse(bool success = false, IEnumerable<Error> errors = null)
		{
			Success = success;
			Errors = errors;
		}

		public bool Success { get; }
		public IEnumerable<Error> Errors { get; }

		
	}
}
