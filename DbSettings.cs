namespace OptionsPattern
{
    public class DbSettings
    {
        private readonly IWritableOptions<DbConnectionConfiguration> _options;

        public DbSettings(IWritableOptions<DbConnectionConfiguration> options)
        {
            _options = options;
        }

        public async void DoSomething()
        {

            var iOptions = $"Values at Application Start:\n" +
                   $"{_options.Value.Server}\n" +
                   $"{_options.Value.IpAddress}\n" +
                   $"{_options.Value.User}\n" +
                   $"{_options.Value.Password}\n";

            Console.WriteLine(iOptions);
            Console.WriteLine("Write DB:");
            var db = Console.ReadLine();
            Console.WriteLine("Write Ip:");
            var ip = Console.ReadLine();
            Console.WriteLine("Write User:");
            var user = Console.ReadLine();
            Console.WriteLine("Write Password:");
            var password = Console.ReadLine();

            await _options.Update(opt =>
            {
                opt.Server = db;
                opt.IpAddress = ip;
                opt.User = user;
                opt.Password = password;
            });

            iOptions = $"\nValues Updated:\n" +
                $"{_options.Value.Server}\n" +
                $"{_options.Value.IpAddress}\n" +
                $"{_options.Value.User}\n" +
                $"{_options.Value.Password}\n";

            Console.WriteLine(iOptions);


            Console.ReadLine();
        }
    }
}
