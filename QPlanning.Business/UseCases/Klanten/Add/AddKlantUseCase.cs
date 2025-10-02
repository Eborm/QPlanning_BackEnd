using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Klanten.Add.Dto.Commands;

namespace QPlanning.Business.UseCases.Klanten.Add
{
    public class AddKlantUseCase : IRequestHandler<AddKlantCommand, BaseResponse>
    {
        private readonly IKlantDomainService _klantDomainService;

        public AddKlantUseCase(IKlantDomainService klantDomainService)
        {
            _klantDomainService = klantDomainService;
        }
        public async Task<BaseResponse> Handle(AddKlantCommand request, CancellationToken cancellationToken)
        {
            var result = await _klantDomainService.AddKlant(request);
            return result;
        }
    }
}