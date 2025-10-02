using Microsoft.AspNetCore.Identity;

namespace QPlanning.Infrastructure.Data.Entities
{
	public class AppUser : IdentityUser<int> 
	{
		// Extended Properties
		public string Voornaam { get; set; }
		public string Achternaam { get; set; }
	}
}
