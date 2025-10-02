using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Repositories.Gateway;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public TeamRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<List<DomainModelTeam>> GetTeams()
        {
            var teams = await _qDbContext.Team.ToListAsync();
            return _mapper.Map<List<DomainModelTeam>>(teams);
        }
    }
}