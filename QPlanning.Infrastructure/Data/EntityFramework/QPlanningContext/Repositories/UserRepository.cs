using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Response.Gateway;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Response.Gateway;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Create.Dto.Response.Gateway;
using QPlanning.Business.UseCases.Authorization.Claims.Roles.Delete.Dto.Response.Gateway;
using QPlanning.Infrastructure.Data.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
	internal sealed class UserRepository : IUserRepository
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<CreateUserResponse> CreateUser(DomainModelUser domainModelUser, string password)
		{
			var appUser = _mapper.Map<AppUser>(domainModelUser);			
			var identityResult = await _userManager.CreateAsync(appUser, password);			
			return new CreateUserResponse(appUser.Id.ToString(), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
		}

		public async Task<UpdateUserResponse> UpdateUser(DomainModelUser domainModelUser)
		{
			var appUser = await FindById(domainModelUser.Id.ToString());
			appUser.Achternaam = domainModelUser.Achternaam;
			appUser.Voornaam = domainModelUser.Voornaam;
			appUser.Email = domainModelUser.Email;
			appUser.UserName = domainModelUser.UserName;
			var identityResult = await _userManager.UpdateAsync(appUser);			
			return new UpdateUserResponse(appUser.Id.ToString(), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
		}

		public async Task<BaseResponse> DeleteUser(string email)
		{
			var user = await FindDatabaseUserByEmail(email);
			var claims = await GetAllClaims(email);
			await _userManager.RemoveClaimsAsync(user, claims);
			var result = await _userManager.DeleteAsync(user);
			return new BaseResponse(new List<string> { "1" },result.Succeeded);
		}

		public async Task<BaseResponse> ResetPassword(string email, string newPassword)
		{
			var appUser = await FindDatabaseUserByEmail(email);
			await _userManager.RemovePasswordAsync(appUser);
			var result = await  _userManager.AddPasswordAsync(appUser, newPassword);
			return new BaseResponse(new List<string> { "1" }, result.Succeeded);
		}

		public async Task<DomainModelUser> FindByEmail(string email)
		{
			return _mapper.Map<DomainModelUser>(await FindDatabaseUserByEmail(email));
		}
		
		private async Task<AppUser> FindById(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<IList<DomainModelUser>> GetAllUsers()
		{
			var users = await _userManager.Users.ToListAsync();
			return _mapper.Map<IList<DomainModelUser>>(users);
		}

		public async Task<bool> CheckPassword(DomainModelUser domainModelUser, string password)
		{
			return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(domainModelUser), password);
		}

		public async Task<IList<string>> GetAllRolesForUser(string email)
		{
			var user = await FindDatabaseUserByEmail(email);			
			var claims = await _userManager.GetClaimsAsync(user);
			var roles = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c?.Value).ToList();
			return roles;
		}
		
		private async Task<IList<Claim>> GetAllClaims(string email)
		{
			var user = await FindDatabaseUserByEmail(email);			
			return await _userManager.GetClaimsAsync(user);
		}

		public async Task<CreateRoleResponse> CreateClaimRole(string email, string role)
		{
			var user = await FindDatabaseUserByEmail(email);
			var identityResult = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
			return new CreateRoleResponse(user.Id.ToString(), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
		}
		
		public async Task<DeleteRoleResponse> DeleteClaimRole(string email, string role)
		{
			var user = await FindDatabaseUserByEmail(email);
			var identityResult = await _userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, role));
			return new DeleteRoleResponse(user.Id.ToString(), identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
		}

		private async Task<AppUser> FindDatabaseUserByEmail(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}


	}
}
