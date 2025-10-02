using MediatR;
using QPlanning.Business.Dto.Base.UseCaseResponses;

namespace QPlanning.Business.UseCases.Boekjaar.Add.Dto.Command
{
    public class AddBoekjaarCommand: IRequest<BaseResponse>
    {
        public int Boekjaar { get; set; }
        public int Bedrag { get; set; }
    }
}