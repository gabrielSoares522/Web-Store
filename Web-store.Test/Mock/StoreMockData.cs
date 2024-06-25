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
    internal class StoreMockData
    {
        public static async Task CreateStores(Web_StoreAPIApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var DBContext = provider.GetRequiredService<DataContext>())
                {
                    await DBContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await DBContext.Stores.AddAsync(new Store(
                            1, "Amazon",
                            "Amazon é uma empresa multinacional de tecnologia norte-americana com sede em Seattle, Washington.",
                            "(13) 99442-2211", 
                            "rua clovis 2222",
                            "Seattle",
                            "Washington", 
                            "4444-222", 
                            "USA", 
                            5
                        ));

                        await DBContext.Stores.AddAsync(new Store(
                            2,
                            "HuanChengShiTong",
                            "HuanChengShiTong assume o compromisso de oferecer a cada cliente o mais alto nível de atendimento.",
                            "(51) 99113-5533",
                            "rua diego soua 3322",
                            "Tokyo",
                            "Tokyo",
                            "1112-333",
                            "Japão",
                            6
                        ));

                        await DBContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
