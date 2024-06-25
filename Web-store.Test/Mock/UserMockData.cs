using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;

namespace Web_store.Test.Mock
{
    internal class UserMockData
    {
        public static async Task CreateUsers(Web_StoreAPIApplication application, bool criar)
        {
            using (var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                using (var DBContext = provider.GetRequiredService<DataContext>())
                {
                    await DBContext.Database.EnsureCreatedAsync();

                    if (criar)
                    {
                        await DBContext.Users.AddAsync(new User(
                            1, "Gabriel", "Soares","gabriel", "gabriel.soares@gmail.com", "12345", new DateTime(1999,4,15), "67416709806", 1
                        ));

                        await DBContext.Users.AddAsync(new User(
                            2, "Eduardo", "Carvalho","eduardo", "eduardo.carvalho@gmail.com", "12345", new DateTime(1999, 4, 15), "14880275603", 1
                        ));

                        await DBContext.Users.AddAsync(new User(
                            3, "Carlos", "Gonzaga","carlos", "carlos.gonzaga@gmail.com", "12345", new DateTime(1999, 4, 15), "19277164549", 1
                        ));

                        await DBContext.Users.AddAsync(new User(
                            4, "Diego", "Castro", "diego", "diego.castro@gmail.com", "12345", new DateTime(1999, 4, 15), "59166522595", 1
                        ));

                        await DBContext.Users.AddAsync(new User(
                            5, "Camila", "Santana", "camila", "camila.santana@gmail.com", "12345", new DateTime(1999, 4, 15), "27948554335", 2
                        ));

                        await DBContext.Users.AddAsync(new User(
                            6,"Katarina","Santos", "katarina", "katarina.santos@gmail.com", "12345", new DateTime(1999, 4, 15), "82223733239", 2
                        ));

                        await DBContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
