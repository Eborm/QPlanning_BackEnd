using MediatR;
using QPlanning.Business.UseCases.Boeking.Get.Dto.Responses;

namespace QPlanning.Business.UseCases.Boeking.Get.Dto
{
    public class GetBoekjarenCommand : IRequest<GetBoekjarenResponse>
    {
        public int KlantId { get; set; }
    }
}