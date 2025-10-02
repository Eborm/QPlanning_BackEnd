using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Dto.Commands
{
    public class DeleteUserCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
    }
}