using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.Dto.Commands
{
    public class ResetPasswordCommand: IRequest<BaseResponse>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}