using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.UseCases.Authentication.Account.Update.Dto.Command
{
    public class UpdateUserCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}