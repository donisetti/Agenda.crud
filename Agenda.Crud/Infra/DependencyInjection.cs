using Agenda.Crud.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace Agenda.Crud.Infra;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {

        string connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

        if (connectionString != null)
        {
            services.AddDbContext<ScheduleDataContext>(options =>
      options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ScheduleDataContext).Assembly.FullName)));

        }
        else
        {
            services.AddDbContext<ScheduleDataContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ScheduleDataContext).Assembly.FullName)));
        }

       

        return services;
    }
}
