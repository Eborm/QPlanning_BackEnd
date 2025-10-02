using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Services
{
    public class KlantService : IKlantService
    {
        private readonly IKlantRepository _klantRepository;

        public KlantService(IKlantRepository klantRepository)
        {
            _klantRepository = klantRepository;
        }
        
        public async Task<BaseResponse> AddKlant(DomainModelKlant klant)
        {
            var result = await _klantRepository.AddKlant(klant);
            return result;
        }

        public async Task<BaseResponse> EditKlant(DomainModelKlant klant)
        {
            var result = await _klantRepository.EditKlant(klant);
            return result;
        }

        public async Task<List<DomainModelKlant>> GetKlantenForTeam(int? teamId)
        {
            var klanten = await _klantRepository.GetKlantenForTeam(teamId);

            if (teamId == null) return klanten;
            
            var filteredKlanten = klanten
                .Where(x => x.VerantwoordelijkTeamId == teamId 
                            || x.PlanbaarDoorTeams.Any(y => y.TeamId == teamId))
                .ToList();

            return filteredKlanten;
        }

        public List<int> GetBoekjarenVoorKlant(int klantId)
        {
            var boekjaren = _klantRepository.GetBoekjarenForKlant(klantId);
            return boekjaren;
        }

        public Task<DomainModelKlant> GetKlant(int klantId)
        {
            return _klantRepository.GetKlant(klantId);
        }
    }
}