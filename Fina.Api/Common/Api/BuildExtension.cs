using Fina.Api.Data;
using Fina.Api.Handlers;
using Fina.Core;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Fina.Api.Common.Api;

public static class BuildExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder
           .Configuration
           .GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        Configuration.FrontendReact = builder.Configuration.GetValue<string>("FrontendReact") ?? string.Empty;
        //Configuration.LocalUrl = builder.Configuration.GetValue<string>("LocalUrl") ?? string.Empty;
        //Configuration.Local= builder.Configuration.GetValue<string>("LocalUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }
    
    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<AppDbContext>(
                x =>
                {
                    //x.UseSqlite("DataSource=Fina.db;Cache=Shared");
                    x.UseSqlServer(ApiConfiguration.ConnectionString);
                });
        
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                    policy => policy
                    .WithOrigins([
                         Configuration.BackendUrl,
                         Configuration.FrontendUrl,
                         Configuration.FrontendReact,
                    //     //Configuration.LocalUrl,
                     ])
                    //.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
            ));
    }
    
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddTransient<ICategoryHandler, CategoryHandler>();

        builder
            .Services
            .AddTransient<ITransactionHandler, TransactionHandler>();

        builder
           .Services
           .AddTransient<IReportHandler, ReportHandler>();
    }
}