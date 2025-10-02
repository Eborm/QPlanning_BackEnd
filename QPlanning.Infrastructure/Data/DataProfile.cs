using AutoMapper;
using QPlanning.Business.Domain.Entities;
using QPlanning.Business.Domain.Entities.Logging;
using QPlanning.Infrastructure.Data.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging;
using CustomLog = QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging.CustomLog;

namespace QPlanning.Infrastructure.Data
{
	public class DataProfile : Profile
	{
		public DataProfile()
		{
			CreateMap<DomainModelUser, AppUser>().ConstructUsing(u => new AppUser { Id = u.Id, Voornaam = u.Voornaam, Achternaam = u.Achternaam, UserName = u.UserName, PasswordHash = u.PasswordHash });
			CreateMap<AppUser, DomainModelUser>().ConstructUsing(au => new DomainModelUser{ Voornaam = au.Voornaam,Achternaam = au.Achternaam,Email = au.Email, UserName = au.UserName,PasswordHash = au.PasswordHash});
			
			CreateMap<DomainModelExceptionLog, ExceptionLog>().ConstructUsing(u => new ExceptionLog());
			CreateMap<ExceptionLog, DomainModelExceptionLog>().ConstructUsing(au => new DomainModelExceptionLog());
			
			CreateMap<DomainModelCustomLog, CustomLog>().ConstructUsing(u => new CustomLog());
			CreateMap<CustomLog, DomainModelCustomLog>().ConstructUsing(au => new DomainModelCustomLog());
			
			CreateMap<DomainModelBoeking, Boeking>().ConstructUsing(u => new Boeking());
			CreateMap<Boeking, DomainModelBoeking>().ConstructUsing(au => new DomainModelBoeking());

			CreateMap<DomainModelKlant, Klant>().ConstructUsing(u => new Klant());
			CreateMap<Klant, DomainModelKlant>().ConstructUsing(au => new DomainModelKlant());
			
			CreateMap<DomainModelKlantPlanbaarDoorTeams, KlantPlanbaarDoorTeams>().ConstructUsing(u => new KlantPlanbaarDoorTeams());
			CreateMap<KlantPlanbaarDoorTeams, DomainModelKlantPlanbaarDoorTeams>().ConstructUsing(au => new DomainModelKlantPlanbaarDoorTeams());

			CreateMap<DomainModelMedewerkerPlanbaarDoorTeams, MedewerkerPlanbaarDoorTeams>()
				.ConstructUsing(u => new MedewerkerPlanbaarDoorTeams());
			CreateMap<MedewerkerPlanbaarDoorTeams, DomainModelMedewerkerPlanbaarDoorTeams>()
				.ConstructUsing(au => new DomainModelMedewerkerPlanbaarDoorTeams());
			
			CreateMap<DomainModelBoekjaar, Boekjaar>().ConstructUsing(u => new Boekjaar());
			CreateMap<Boekjaar, DomainModelBoekjaar>().ConstructUsing(au => new DomainModelBoekjaar());
			
			CreateMap<DomainModelMedewerker, Medewerker>().ConstructUsing(u => new Medewerker());
			CreateMap<Medewerker, DomainModelMedewerker>().ConstructUsing(au => new DomainModelMedewerker());
			
			CreateMap<DomainModelIndirecteUren, IndirecteUren>().ConstructUsing(u => new IndirecteUren());
			CreateMap<IndirecteUren, DomainModelIndirecteUren>().ConstructUsing(au => new DomainModelIndirecteUren());
			
			CreateMap<DomainModelOpdracht, Opdracht>().ConstructUsing(u => new Opdracht());
			CreateMap<Opdracht, DomainModelOpdracht>().ConstructUsing(au => new DomainModelOpdracht());
			
			CreateMap<DomainModelTeam, Team>().ConstructUsing(u => new Team());
			CreateMap<Team, DomainModelTeam>().ConstructUsing(au => new DomainModelTeam());
			
			CreateMap<DomainModelMedewerkerFunctie, MedewerkerFunctie>().ConstructUsing(u => new MedewerkerFunctie());
			CreateMap<MedewerkerFunctie, DomainModelMedewerkerFunctie>().ConstructUsing(au => new DomainModelMedewerkerFunctie());
		}
	}
}
