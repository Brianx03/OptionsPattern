using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionsPattern;

IConfigurationRoot configurationRoot =null;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();

        IHostEnvironment env = hostingContext.HostingEnvironment;

        configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        configurationRoot = configuration.Build();
    })
    .ConfigureServices((builder, services) =>
    {
        services
        .ConfigureWritable<DbConnectionConfiguration>(configurationRoot, builder.Configuration.GetSection(nameof(DbConnectionConfiguration)));
        services
        .AddSingleton<DbSettings>();
    })
    .Build();


DbSettings db = host.Services.GetRequiredService<DbSettings>();
db.ChangeOptions();

