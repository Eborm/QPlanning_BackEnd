using System;

namespace QPlanning.Business.Domain.Entities
{
	public class DomainModelUser
	{
		public int Id { get; set; }
		public string Voornaam { get; set; }
		public string Achternaam { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		
	}
}
