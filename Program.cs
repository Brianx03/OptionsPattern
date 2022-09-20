using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionsPattern;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
        services
        .ConfigureWritable<DbConnectionConfiguration>(builder.Configuration.GetSection(nameof(DbConnectionConfiguration)));
        services
        .AddSingleton<DbSettings>();
    })
    .Build();


DbSettings db = host.Services.GetRequiredService<DbSettings>();
db.ChangeOptions();

