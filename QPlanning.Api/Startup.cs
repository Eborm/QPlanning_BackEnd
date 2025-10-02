using Autofac;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QPlanning.Api.Extensions;
using QPlanning.Api.Extensions.ServiceCollection;
using QPlanning.Api.Helpers.Constants;
using QPlanning.Business;
using QPlanning.Business.Extensions;
using QPlanning.Business.Interfaces.Services;
using QPlanning.Business.Services;
using QPlanning.Business.UseCases.Authentication.Login.Dto.Command;
using QPlanning.Common.Auth;
using QPlanning.Infrastructure;
using QPlanning.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Claims;

namespace QPlanning.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            //Add framework service
            services.AddDataAccessServices(Configuration);

            //Add Mediator
            services.AddMediatRComponents();
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            //services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            //Add Jwt Tokens -- Infrastructure project
            var jwtAppSettingOptions = services.ConfigureJwtServices(Configuration);
            var tokenValidationParameters = services.ConfigureTokenParameters(jwtAppSettingOptions);
            services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(configureOptions =>
			{
				configureOptions.ClaimsIssuer = services.GetJwtIssuer(jwtAppSettingOptions);
				configureOptions.TokenValidationParameters = tokenValidationParameters;
				configureOptions.SaveToken = true;
			});

			//Add Authorization policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.AdminOnly, policy =>
                    policy.RequireClaim(ClaimTypes.Role,
                        new List<string> {UserRole.Admin}));
                
                options.AddPolicy(Policies.ElevatedRights, policy =>
                    policy.RequireClaim(ClaimTypes.Role,
                        new List<string> {UserRole.Manager, UserRole.Planner, UserRole.Admin}));
                
                options.AddPolicy(Policies.AtLeastMedewerker, policy =>
                    policy.RequireClaim(ClaimTypes.Role,
                        new List<string> {UserRole.Admin, UserRole.Manager, UserRole.Planner, UserRole.Medewerker}));
            });

            // add identity
            services.AddIdentityServices();

            //information on how to implement correctly: https://stackoverflow.com/questions/40275195/how-to-set-up-automapper-in-asp-net-core
            services.AddAutoMapper(typeof(Infrastructure.Data.DataProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "QPlanningApi", Version = "v1"});
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new[] {"Bearer", "JwtToken"}
                    }
                });
            });

			//In order to enable Autofac (new way of binding it)
            services.AddOptions();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //configure auto fac here
            var infrastructureModuleDll = Activator.CreateInstance(
                Assembly.LoadFrom(
                        Configuration.GetSection("Dependencies")
                            .GetSection("Infrastructure").Value
                            .Insert(0, (System.IO.Directory.GetParent(@"../").FullName)))
                    .GetType("QPlanning.Infrastructure.InfrastructureModule")
            );

            builder.RegisterModule(new BusinessModule());
            builder.RegisterModule(new InfrastructureModule());
            //builder.RegisterModule(infrastructureModuleDll as Autofac.Module);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    builder =>
                    {
                        builder.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                var error = context.Features.Get<IExceptionHandlerFeature>();
                                if (error != null)
                                {
                                    context.Response.AddApplicationError(error.Error.Message);
                                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                }
                            });
                    });
                app.UseExceptionPersistance();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();
            
            app.UseAuthentication(); 
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QPlanning API V1");
                c.RoutePrefix = string.Empty;
            });
           
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}