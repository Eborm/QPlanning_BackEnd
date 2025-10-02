using MediatR;
using QPlanning.Business.UseCases.Klanten.Get.Dto.Responses;

namespace QPlanning.Business.UseCases.Klanten.Get.Dto.Commands
{
    public class GetKlantDownDownCommand : IRequest<GetKlantDropDownResponse>
    {
        public string Email { get; set; }
    }
}