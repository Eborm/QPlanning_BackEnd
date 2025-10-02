using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.UseCases.Boeking.Dto;
using QPlanning.Business.UseCases.Boeking.Update.Dto;

namespace QPlanning.Business.UseCases.Boeking.Update
{
    public class UpdateBoekingUseCase : IRequestHandler<UpdateBoekingCommand, BoekingResponse>
    {
        private readonly IBoekingService _boekingService;

        public UpdateBoekingUseCase(IBoekingService boekingService)
        {
            _boekingService = boekingService;
        }
        
        public Task<BoekingResponse> Handle(UpdateBoekingCommand request, CancellationToken cancellationToken)
        {
            var domainModelBoeking = new DomainModelBoeking
            {
                Jaar = request.Jaar,
                Uren = request.Uren,
                Weeknummer = request.Weeknummer,
                Datum = request.PlannedDate,
                KlantId = request.KlantId,
                OpdrachtId = request.OpdrachtId,
                MedewerkerId = request.MedewerkerId,
                IndirecteUrenId = request.IndirecteUrenId,
                Boekjaar = request.Boekjaar
            };
            if (request.Id.HasValue) domainModelBoeking.Id = request.Id.Value;
            return _boekingService.UpdateBoeking(domainModelBoeking);
        }
    }
}