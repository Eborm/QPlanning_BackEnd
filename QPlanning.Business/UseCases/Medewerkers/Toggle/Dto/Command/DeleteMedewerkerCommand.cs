using MediatR;
using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.UseCases.Medewerkers.Toggle.Dto.Command
{
    public class DeleteMedewerkerCommand: IRequest<UseCaseResponseMessage>
    {
        public int Id { get; set; }
        public bool IsActief { get; set; }
    }
}