using System.Threading.Tasks;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Services
{
    public class BoekjaarService : IBoekjaarService
    {
        private readonly IBoekjaarRepository _boekjaarRepository;

        public BoekjaarService(IBoekjaarRepository boekjaarRepository)
        {
            _boekjaarRepository = boekjaarRepository;
        }
        
        public async Task<BaseResponse> AddBoekjarenRawSql(int jaar, int bedrag)
        {
            var result = await _boekjaarRepository.AddBoekjarenRawSql(jaar, bedrag);
            return new BaseResponse (result.Id, result.Success, $"Het toevoegen van de nieuwe boekjaren met jaartal: {jaar} en een bedrag van: {bedrag} is gelukt.");
        }
    }
}