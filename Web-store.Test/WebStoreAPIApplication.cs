using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Web_store.Domain.Data;
using Web_store.API;

namespace Web_store.Test
{
    public class Web_StoreAPIApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<DataContext>));
                services.AddDbContext<DataContext>(options =>
                    options.UseInMemoryDatabase("WebStoreAPIDatabase", root));
            });

            return base.CreateHost(builder);
        }
    }
}