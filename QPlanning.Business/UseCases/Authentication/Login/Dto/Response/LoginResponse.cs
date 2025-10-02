using System.Collections.Generic;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.UseCases.Authentication.Login.Dto.Response
{
	public class LoginResponse : UseCaseResponseMessage
	{
		public DomainModelUser DomainModelUser { get; set; }
		public string HighestRole { get; set; }
		public string AuthToken { get; set; }
		public new bool Success { get; set; }
	}
}
