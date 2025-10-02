using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class MedewerkerFunctieRepository : IMedewerkerFunctieRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public MedewerkerFunctieRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<List<DomainModelMedewerkerFunctie>> GetMedewerkerFuncties()
        {
            var medewerkerFuncties = await _qDbContext.MedewerkerFunctie.ToListAsync();
            return _mapper.Map<List<DomainModelMedewerkerFunctie>>(medewerkerFuncties);
        }
    }
}