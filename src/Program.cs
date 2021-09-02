using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UI.Models;

namespace UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            ApiConfig config = new ApiConfig();
                
            builder.Configuration.Bind(nameof(ApiConfig), config);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(config.ApiUri) });

            await builder.Build().RunAsync();
        }
    }
}
