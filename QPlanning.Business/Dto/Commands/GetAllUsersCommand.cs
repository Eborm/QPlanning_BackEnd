using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Dto.Response.UseCase;

namespace QPlanning.Business.Dto.Commands
{
    public class GetAllUserCommand: IRequest<AllUserResponse>
    {
        
    }
}