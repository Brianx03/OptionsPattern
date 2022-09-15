using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionsPattern;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
        services
        .Configure<DbConnectionConfiguration>(builder.Configuration.GetSection(nameof(DbConnectionConfiguration)))
        .AddSingleton<DbSettings>();
    })
    .Build();

DbSettings db = host.Services.GetService<DbSettings>();
db.DoSomething();







