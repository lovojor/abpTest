using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Serilog;
using Serilog.Events;

namespace OD.BookStore;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting OD.BookStore.AuthServer.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<BookStoreAuthServerModule>();
            string connectionString = builder.Configuration.GetConnectionString("https://od-app-configuration.azconfig.io");
            var credential = new DefaultAzureCredential(true);

            builder.Configuration.AddAzureAppConfiguration(options =>
            {
                options.Connect("Endpoint=https://od-app-configuration.azconfig.io;Id=i9Tr-l0-s0:gX9xLdnfHzDjL/MFk4Iv;Secret=W7M303LOKet2iMYlKAjmNnKpoWN6iEiWK91GHtdPvsI=").ConfigureRefresh(refreshOption
                    => refreshOption.Register("book:count", refreshAll: true).SetCacheExpiration(TimeSpan.FromSeconds(5)));
            });
            const string CORS_POLICY = "CorsPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY,
                                  corsPolicyBuilder =>
                                  {
                                      corsPolicyBuilder.AllowAnyMethod();
                                      corsPolicyBuilder.AllowAnyHeader();
                                      corsPolicyBuilder.AllowAnyOrigin();
                                  });
            });
            builder.Services.Configure<BookConfiguration>(builder.Configuration.GetSection("book"));
            builder.Services.AddAzureAppConfiguration();
            builder.Services.AddFeatureManagement();
            var app = builder.Build();
            app.UseCors(CORS_POLICY);
            app.UseAzureAppConfiguration();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "OD.BookStore.AuthServer terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
