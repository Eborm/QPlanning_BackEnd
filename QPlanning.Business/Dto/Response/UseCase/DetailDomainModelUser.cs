namespace QPlanning.Business.Dto.Response.UseCase
{
    public class DetailDomainModelUser
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string PasswordHash { get; set; }
    }
}