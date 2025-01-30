using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure.Migrations;

public class DataBaseMigration
{
    // generate new migration command on terminal on src folder: 
    // dotnet ef migrations add <MigrationName> --project CashFlow.Infrastructure --startup-project CashFlow.Api
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
