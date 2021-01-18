using CursosEAD.Application.Services;
using CursosEAD.Application.Services.Interface;
using CursosEAD.Domain.Interfaces.Repositories;
using CursosEAD.Infrastructure.Context;
using CursosEAD.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CursosEAD.Configurations.CrossCutting
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<AppDbContext, AppDbContext>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
