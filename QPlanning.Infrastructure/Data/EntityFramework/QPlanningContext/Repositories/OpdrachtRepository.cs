using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Repositories.Gateway;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class OpdrachtRepository : IOpdrachtRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public OpdrachtRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<List<DomainModelOpdracht>> GetOpdrachten()
        {
            var opdrachten = await _qDbContext.Opdracht.ToListAsync();
            return _mapper.Map<List<DomainModelOpdracht>>(opdrachten);
        }
    }
}