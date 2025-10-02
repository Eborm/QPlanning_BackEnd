using System.Collections.Generic;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.GatewayReponses;

namespace QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Response.Gateway
{
    public class UpdateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public UpdateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}