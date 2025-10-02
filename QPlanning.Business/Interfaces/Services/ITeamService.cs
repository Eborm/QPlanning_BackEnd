using System.Collections.Generic;
using System.Threading.Tasks;
using QPlanning.Business.Domain.Entities;

namespace QPlanning.Business.Interfaces.Services
{
    public interface ITeamService
    {
        Task<List<DomainModelTeam>> GetTeams();
    }
}