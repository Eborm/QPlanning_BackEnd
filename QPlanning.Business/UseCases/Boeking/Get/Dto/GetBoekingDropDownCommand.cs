using MediatR;

namespace QPlanning.Business.UseCases.Boeking.Get.Dto
{
    public class GetBoekingDropDownCommand : IRequest<BoekingDropDownResponse>
    {
        private string _email;

        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}