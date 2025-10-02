using Autofac;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Infrastructure.Auth;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Repositories;

namespace QPlanning.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LogRepository>().As<ILogRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BoekingRepository>().As<IBoekingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BoekjaarRepository>().As<IBoekjaarRepository>().InstancePerLifetimeScope();
            builder.RegisterType<IndirecteUrenRepository>().As<IIndirecteUrenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<KlantRepository>().As<IKlantRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MedewerkerRepository>().As<IMedewerkerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MedewerkerFunctieRepository>().As<IMedewerkerFunctieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OpdrachtRepository>().As<IOpdrachtRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>().InstancePerLifetimeScope();
        }
    }
}