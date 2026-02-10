


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AdvancedDevSample.Domain.Interfaces.Products;

namespace AdvancedDevSample.Test.API.Integration
{
    public class CustomerApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //supprimer le vrai repository si necessaire
                services.RemoveAll(typeof(IProductRepositoryAsync));

                //Ajouter un repository InMemory
                services.AddSingleton<IProductRepositoryAsync, InMemoryProductRepositoryAsync>();
            });
        }


    }
}
