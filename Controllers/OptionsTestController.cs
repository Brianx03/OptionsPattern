using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPatternNetCore.Models;

namespace OptionsPatternNetCore.Controllers
{
    public class OptionsTestController : Controller
    {
        private readonly DbConnectionConfiguration _options;
        private readonly DbConnectionConfiguration _optionsSapshot;
        private readonly DbConnectionConfiguration _optionsMonitor;
        public OptionsTestController(IOptions<DbConnectionConfiguration> options, 
            IOptionsSnapshot<DbConnectionConfiguration> optionsSnapshot,
            IOptionsMonitor<DbConnectionConfiguration> optionsMonitor)
        {
            _options = options.Value;
            _optionsSapshot = optionsSnapshot.Value;
            _optionsMonitor = optionsMonitor.CurrentValue;
        }

        [HttpGet("GetValue")]
        public IActionResult Index()
        {
            var iOptions = $"Values at Application Start:\n" +
                $"{_options.ToString()}\n" +
                $"{_options.IpAddress}\n" +
                $"{_options.User}\n" +
                $"{_options.Password}\n" +
                $"\n";

            var iOptionsSnapshot = $"Values at request:\n" +
                $"{_optionsSapshot.DbManager}\n" +
                $"{_optionsSapshot.IpAddress}\n" +
                $"{_optionsSapshot.User}\n" +
                $"{_optionsSapshot.Password}\n" +
                $"\n";

            Thread.Sleep(15000);

            var iOptionsMonitor = $"Current Values:\n" +
                $"{_optionsMonitor.DbManager}\n" +
                $"{_optionsMonitor.IpAddress}\n" +
                $"{_optionsMonitor.User}\n" +
                $"{_optionsMonitor.Password}\n" +
                $"\n";


            return Ok(iOptions + iOptionsSnapshot + iOptionsMonitor);
        }
    }
}
