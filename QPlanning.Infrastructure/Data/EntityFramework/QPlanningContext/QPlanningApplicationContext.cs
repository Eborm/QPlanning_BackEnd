using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QPlanning.Infrastructure.Data.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext.Entities.Logging;

namespace QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext
{
	public class QPlanningApplicationContext : IdentityDbContext<AppUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		public QPlanningApplicationContext(DbContextOptions<QPlanningApplicationContext> options) : base(options)
		{
		}

		public DbSet<ExceptionLog> ExceptionLog { get; set; }
		public DbSet<CustomLog> CustomLog { get; set; }
		public DbSet<Medewerker> Medewerker { get; set; }
		public DbSet<MedewerkerFunctie> MedewerkerFunctie { get; set; }
		public DbSet<Opdracht> Opdracht { get; set; }
		public DbSet<Klant> Klant { get; set; }
		public DbSet<Team> Team { get; set; }
		public DbSet<IndirecteUren> IndirecteUren { get; set; }
		public DbSet<Boeking> Boeking { get; set; }

		public DbSet<Boekjaar> Boekjaar { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			SeedDatabaseDefaultUsers(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(QPlanningApplicationContext).Assembly);
		}

		

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await base.SaveChangesAsync();
		}

		#region Seed the data for the default users

		private void SeedDatabaseDefaultUsers(ModelBuilder modelBuilder)
		{
			
		}

		#endregion
	}
}
