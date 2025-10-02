using System.Collections.Generic;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.Dto.Base.UseCaseResponses
{
	public class BaseResponse : UseCaseResponseMessage
	{
		public BaseResponse(IEnumerable<string> errors, bool success = false, string message = null) : base (success, message)
		{
			Errors = errors;
		}

		public BaseResponse(string id, bool success = false, string message = null) : base(success, message)
		{
			Id = id;
		}

		public string Id { get; }
		public IEnumerable<string> Errors { get; }
	}
}
