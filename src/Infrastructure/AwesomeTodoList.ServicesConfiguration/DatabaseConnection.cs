using AwesomeToDoList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.ServicesConfiguration
{
    public static class DatabaseConnection
    {
        public static void ConfigureDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AwesomeToDoListContext>(x => {
                x.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"),
                    sqlServer => {
                    sqlServer.EnableRetryOnFailure();
                    sqlServer.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    sqlServer.MigrationsAssembly(typeof(AwesomeToDoListContext).Assembly.FullName);
                });
                x.EnableDetailedErrors(true);
                x.EnableSensitiveDataLogging();
                x.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });
        }
    }
}
