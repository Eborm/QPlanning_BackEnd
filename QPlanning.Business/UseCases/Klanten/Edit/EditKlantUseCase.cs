using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.UseCases.Klanten.Edit.Dto.Commands;

namespace QPlanning.Business.UseCases.Klanten.Edit
{
    public class EditKlantUseCase: IRequestHandler<EditKlantCommand, BaseResponse>
    {
        private readonly IKlantDomainService _klantDomainService;

        public EditKlantUseCase(IKlantDomainService klantDomainService)
        {
            _klantDomainService = klantDomainService;
        }
        public async Task<BaseResponse> Handle(EditKlantCommand request, CancellationToken cancellationToken)
        {
            var result = await _klantDomainService.EditKlant(request);
            return result;
        }
    }
}