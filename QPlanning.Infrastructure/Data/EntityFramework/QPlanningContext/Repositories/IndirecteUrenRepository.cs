using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Repositories.Gateway;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class IndirecteUrenRepository : IIndirecteUrenRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public IndirecteUrenRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<List<DomainModelIndirecteUren>> GetIndirecteUren()
        {
            var indirecteUren = await _qDbContext.IndirecteUren.ToListAsync();
            return _mapper.Map<List<DomainModelIndirecteUren>>(indirecteUren);
        }
    }
}