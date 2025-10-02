using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;

namespace QPlanning.Business.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        
        public async Task<List<DomainModelTeam>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }
    }
}