using QPlanning.Business.Interfaces.Base;

namespace QPlanning.Business.UseCases.Boeking.Dto
{
    public class BoekingResponse: UseCaseResponseMessage
    {
        public BoekingResponse(int id, bool succes, string message) : base(succes, message)
        {
            Id = id;
        }
        public int Id { get; }
    }
}