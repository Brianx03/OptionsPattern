using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPattern
{
    public class DbSettings
    {
        private readonly DbConnectionConfiguration _options;
        private readonly DbConnectionConfiguration _optionsSnapshot;


        public DbSettings(IOptions<DbConnectionConfiguration> options,
            IOptionsSnapshot<DbConnectionConfiguration> optionsSnapshot)
        {
            _options = options.Value;
            _optionsSnapshot = optionsSnapshot.Value;
        }

        public void DoSomething()
        {

            var iOptions = $"Values at Application Start:\n" +
                   $"{_options.Server}\n" +
                   $"{_options.IpAddress}\n" +
                   $"{_options.User}\n" +
                   $"{_options.Password}";

            File.WriteAllText("WriteText.txt", iOptions);
        }
    }
}
