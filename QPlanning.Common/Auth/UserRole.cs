using System.Collections.Generic;
using System.Linq;

namespace QPlanning.Common.Auth
{
	public static class UserRole
	{
		public const string Admin = "Admin";
		public const string Manager = "Manager";
		public const string Planner = "Planner";
		public const string Medewerker = "Medewerker";

		public static readonly IEnumerable<string> AllRoles = new List<string>() { Admin, Manager, Planner, Medewerker};

		public static bool IsAllowedToRegisterRole(string role)
		{
			return AllRoles.Contains(role);
		}
	}
}
