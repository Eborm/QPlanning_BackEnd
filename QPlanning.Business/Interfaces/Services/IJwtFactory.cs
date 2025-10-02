using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Dto.Base;

namespace QPlanning.Business.Interfaces.Services
{
	public interface IJwtFactory
	{
		Task<Token> GenerateEncodedToken(int id, string userName, IList<string> roles);
	}
}
