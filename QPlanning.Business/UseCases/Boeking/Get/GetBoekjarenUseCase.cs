using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Boeking.Get.Dto;
using QPlanning.Business.UseCases.Boeking.Get.Dto.Responses;

namespace QPlanning.Business.UseCases.Boeking.Get
{
    public class GetBoekjarenUseCase : IRequestHandler<GetBoekjarenCommand, GetBoekjarenResponse>
    {
        private readonly IKlantService _klantService;

        public GetBoekjarenUseCase(IKlantService klantService)
        {
            _klantService = klantService;
        }
        
        public async Task<GetBoekjarenResponse> Handle(GetBoekjarenCommand request, CancellationToken cancellationToken)
        {
           var boekjarenResponse =  await Task.Run(() =>
            {
                var boekjaren = _klantService.GetBoekjarenVoorKlant(request.KlantId);
                var boekjarenResponse = new GetBoekjarenResponse
                {
                    Boekjaren = boekjaren
                };
                return boekjarenResponse;
            });

           return boekjarenResponse;
        }
    }
}