using System.Collections.Generic;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.GatewayReponses;

namespace QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Response.Gateway
{
    public class DeleteRoleResponse: BaseGatewayResponse
    {
        public string Id { get; }
        public DeleteRoleResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}