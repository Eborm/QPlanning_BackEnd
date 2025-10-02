using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Dto.Base.UseCaseResponses;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories
{
    public class KlantRepository : IKlantRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public KlantRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<DomainModelKlant> GetKlant(int klantId)
        {
            var klant = await _qDbContext.Klant.FindAsync(klantId);
            _qDbContext.Entry(klant).Collection(p => p.PlanbaarDoorTeams).Load(); 
            return _mapper.Map<DomainModelKlant>(klant);
        }
        
        private async Task<Klant> FindKlant(int klantId)
        {
            var klant = await _qDbContext.Klant.FindAsync(klantId);
            _qDbContext.Entry(klant).Collection(p => p.PlanbaarDoorTeams).Load();
            return klant;
        }

        public async Task<BaseResponse> AddKlant(DomainModelKlant klant)
        {
            var databaseKlant = _mapper.Map<Klant>(klant);
            await _qDbContext.Klant.AddAsync(databaseKlant);
            await _qDbContext.SaveChangesAsync();
            return new BaseResponse(databaseKlant.Id.ToString(), true);
        }

        public async Task<BaseResponse> EditKlant(DomainModelKlant klant)
        {
            var databaseKlant = await FindKlant(klant.Id);
            databaseKlant.Naam = klant.Naam;
            databaseKlant.Startdatum = klant.Startdatum;
            databaseKlant.Einddatum = klant.Einddatum;
            databaseKlant.MedewerkerId = klant.MedewerkerId;
            databaseKlant.VerantwoordelijkTeamId = klant.VerantwoordelijkTeamId;
            databaseKlant.PlanbaarDoorTeams = _mapper.Map<List<KlantPlanbaarDoorTeams>>(klant.PlanbaarDoorTeams);
            _qDbContext.Klant.Update(databaseKlant);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true);
        }

        public async Task<List<DomainModelKlant>> GetKlantenForTeam(int? teamId)
        {
            return await Task.Run(() =>
            {
                var today = DateTime.Now;

                var klanten = _qDbContext.Klant
                     .Include(x => x.PlanbaarDoorTeams)
                     .ThenInclude(planbaardoorTeam => planbaardoorTeam.Team)
                    .Include(x => x.VerantwoordelijkTeam)
                    //.Include(x => x.Boekjaren)
                    .Include(x => x.Partner)
                    .Where(x => (x.Startdatum <= today || x.Startdatum == null)
                                && (x.Einddatum >= today || x.Einddatum == null))
                     .ToList();

                return  _mapper.Map<List<DomainModelKlant>>(klanten.ToList());
            });
        }

        public List<int> GetBoekjarenForKlant(int klantId)
        {
            var boekjaren = _qDbContext.Klant.Include(x => x.Boekjaren).Where(x => x.Id == klantId)
                .SelectMany(x => x.Boekjaren.Select(b => b.Jaar)).ToList();
            return boekjaren;
        }
    }
}