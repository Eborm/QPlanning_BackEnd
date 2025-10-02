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
    public class MedewerkerRepository : IMedewerkerRepository
    {
        private readonly IMapper _mapper;
        private readonly QPlanningApplicationContext _qDbContext;

        public MedewerkerRepository(IMapper mapper, QPlanningApplicationContext qDbContext)
        {
            _mapper = mapper;
            _qDbContext = qDbContext;
        }

        public async Task<IList<DomainModelMedewerker>> GetMedewerkers()
        {
            var medewerkers = await _qDbContext.Medewerker
                .Include(x => x.Team)
                .Include( x => x.PlanbaarDoorTeams)
                    .ThenInclude( x => x.Team)
                .Include(x => x.MedewerkerFunctie)
                .ToListAsync();
            return _mapper.Map<List<DomainModelMedewerker>>(medewerkers);
        }

        public async Task<BaseResponse> AddMedewerker(DomainModelMedewerker domainModelMedewerker)
        {
            var medewerker = _mapper.Map<Medewerker>(domainModelMedewerker);
            await _qDbContext.Medewerker.AddAsync(medewerker);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true);
        }

        public async Task<BaseResponse> EditMewewerker(DomainModelMedewerker domainModelMedewerker)
        {
            var databaseMedewerker = await FindMedewerker(domainModelMedewerker.Id);

            databaseMedewerker.Achternaam = domainModelMedewerker.Achternaam;
            databaseMedewerker.Email = domainModelMedewerker.Email;
            databaseMedewerker.Tarief = domainModelMedewerker.Tarief;
            databaseMedewerker.Voornaam = domainModelMedewerker.Voornaam;
            databaseMedewerker.InternTarief = domainModelMedewerker.InternTarief;
            databaseMedewerker.IsActief = true;
            databaseMedewerker.TeamId = domainModelMedewerker.TeamId;
            databaseMedewerker.TussenVoegsel = domainModelMedewerker.TussenVoegsel;
            databaseMedewerker.MedewerkerFunctieId = domainModelMedewerker.MedewerkerFunctieId;
            databaseMedewerker.PlanbaarDoorTeams =  _mapper.Map<List<MedewerkerPlanbaarDoorTeams>>(domainModelMedewerker.PlanbaarDoorTeams);
            
            _qDbContext.Medewerker.Update(databaseMedewerker);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true);
        }

        public async Task<BaseResponse> ToggleActiveMedwerker(int id, bool shouldBeActive)
        {
            var medewerker = GetMedewerker(id);
            medewerker.IsActief = shouldBeActive;
            _qDbContext.Medewerker.Update(medewerker);
            var result = await _qDbContext.SaveChangesAsync();
            return new BaseResponse(result.ToString(), true);
        }

        private async Task<Medewerker> FindMedewerker(int medewerkerId)
        {
            var medewerker = await _qDbContext.Medewerker.FindAsync(medewerkerId);
            await _qDbContext.Entry(medewerker).Collection(m => m.PlanbaarDoorTeams).LoadAsync();
            return medewerker;
        }
        
        public DomainModelMedewerker GetDomainModelMedewerker(string email)
        {
            var medewerker =  _qDbContext.Medewerker.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()) && x.IsActief);
            var domainModelMedewerker = _mapper.Map<DomainModelMedewerker>(medewerker);
            return domainModelMedewerker;
        }
        
        private Medewerker GetMedewerker(int id)
        {
            return _qDbContext.Medewerker.FirstOrDefault(x => x.Id == id);
        }
    }
}