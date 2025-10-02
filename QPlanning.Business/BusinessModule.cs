using Autofac;
using QPlanning.Business.Interfaces.Repositories.Gateway;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.Interfaces.Services.Domain;
using QPlanning.Business.Services;
using QPlanning.Business.Services.Domain;

namespace QPlanning.Business
{
    public class BusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        //    builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        //    builder.RegisterType<AuthorizationService>().As<IAuthorizationService>().InstancePerLifetimeScope();
            //builder.RegisterType<LoggerService>().As<ILoggerService>().InstancePerLifetimeScope();
            //builder.RegisterType<BoekingService>().As<IBoekingService>().InstancePerLifetimeScope();
            //builder.RegisterType<BoekjaarService>().As<IBoekjaarService>().InstancePerLifetimeScope();
            //builder.RegisterType<MedewerkerService>().As<IMedewerkerService>().InstancePerLifetimeScope();
            //builder.RegisterType<KlantService>().As<IKlantService>().InstancePerLifetimeScope();
            //builder.RegisterType<TeamService>().As<ITeamService>().InstancePerLifetimeScope();
            //builder.RegisterType<QPlanningDomainService>().As<IQPlanningDomainService>().InstancePerLifetimeScope();
            //builder.RegisterType<KlantDomainService>().As<IKlantDomainService>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AuthenticationService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AuthorizationService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(LoggerService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(BoekingService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(BoekjaarService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(MedewerkerService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(KlantService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(TeamService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(QPlanningDomainService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(KlantDomainService).Assembly).AsImplementedInterfaces();
        }
    }
}