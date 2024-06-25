using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;

namespace Web_store.Test.Mock
{
    internal class BatchMockData
    {
        public static async Task CreateBatchs(Web_StoreAPIApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var DBContext = provider.GetRequiredService<DataContext>())
                {
                    await DBContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await DBContext.Batchs.AddAsync(new Batch(
                            1, 1, 50
                        ));

                        await DBContext.Batchs.AddAsync(new Batch(
                            2, 2, 79
                        ));

                        await DBContext.Batchs.AddAsync(new Batch(
                            3, 3, 44
                        ));

                        await DBContext.Batchs.AddAsync(new Batch(
                            4, 4, 455
                        ));

                        await DBContext.Batchs.AddAsync(new Batch(
                            5, 5, 342
                        ));

                        await DBContext.Batchs.AddAsync(new Batch(
                            6, 6, 120
                        ));

                        await DBContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
