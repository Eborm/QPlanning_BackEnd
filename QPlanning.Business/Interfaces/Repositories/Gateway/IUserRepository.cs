using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Response.Gateway;
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Response.Gateway;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Response.Gateway;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Response.Gateway;

namespace QPlanning.Business.Interfaces.Repositories.Gateway
{
	public interface IUserRepository
	{
		Task<CreateUserResponse> CreateUser(DomainModelUser domainModelUser, string password);

		Task<UpdateUserResponse> UpdateUser(DomainModelUser domainModelUser);
		Task<BaseResponse> DeleteUser(string email);
		Task<BaseResponse> ResetPassword(string email, string newPassword);
		Task<DomainModelUser> FindByEmail(string email);

		Task<IList<DomainModelUser>> GetAllUsers();
		Task<bool> CheckPassword(DomainModelUser domainModelUser, string password);
		Task<IList<string>> GetAllRolesForUser(string email);
		Task<CreateRoleResponse> CreateClaimRole(string email, string role);
		Task<DeleteRoleResponse> DeleteClaimRole(string email, string role);
	}
}
