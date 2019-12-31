using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JSONMicroservice
{
    public class winesController : Controller
    {
        [HttpGet("/wines")]
        public ActionResult Index()
        {
            return Ok(new [] {new {name = "Brouilly"}, new {name = "Chateau St-Jean"}});
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplicationHost.CreateDefaultBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}