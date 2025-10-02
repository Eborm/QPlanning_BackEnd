using MediatR;
using QPlanning.Business.UseCases.Boeking.Dto;

namespace QPlanning.Business.UseCases.Boeking.Delete.Dto
{
    public class DeleteBoekingCommand : IRequest<BoekingResponse>
    {
        public int Id { get; set; }
    }
}