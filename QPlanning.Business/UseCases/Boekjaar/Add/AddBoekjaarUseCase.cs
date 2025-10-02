using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Boekjaar.Add.Dto.Command;

namespace QPlanning.Business.UseCases.Boekjaar.Add
{
    public class AddBoekjaarUseCase : IRequestHandler<AddBoekjaarCommand, BaseResponse>
    {
        private readonly IBoekjaarService _boekjaarService;

        public AddBoekjaarUseCase(IBoekjaarService boekjaarService)
        {
            _boekjaarService = boekjaarService;
        }
        public async Task<BaseResponse> Handle(AddBoekjaarCommand request, CancellationToken cancellationToken)
        {
            var result = await _boekjaarService.AddBoekjarenRawSql(request.Boekjaar, request.Bedrag);
            return result;
        }
    }
}