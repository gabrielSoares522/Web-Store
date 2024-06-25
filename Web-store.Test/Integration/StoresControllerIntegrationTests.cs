using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Commands.AddStore;
using Web_store.Application.Commands.UpdateStore;
using Web_store.Domain.Entities;
using Web_store.Test.Mock;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;

namespace Web_store.Test.Integration
{
    internal class StoresControllerIntegrationTests
    {

        private const string UrlStoreController = "api/Stores";

        [Test]
        public async Task GetStores()
        {
            await using var application = new Web_StoreAPIApplication();

            await StoreMockData.CreateStores(application, true);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlStoreController);

            var stores = await client.GetFromJsonAsync<List<Store>>(UrlStoreController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count == 2);
        }

        [Test]
        public async Task GetStoresEmpty()
        {
            await using var application = new Web_StoreAPIApplication();

            await StoreMockData.CreateStores(application, false);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlStoreController);

            var stores = await client.GetFromJsonAsync<List<Store>>(UrlStoreController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(stores);
            Assert.IsTrue(stores.Count == 0);
        }

        [Test]
        public async Task PostCreateStore()
        {
            int idStore = 1;

            await using var application = new Web_StoreAPIApplication();

            await StoreMockData.CreateStores(application, false);

            var client = application.CreateClient();


            var newStore = new AddStoreInputModel
            {
                Name = "Amazon.com.br",
                Description = "Amazon é uma empresa multinacional de tecnologia norte-americana com sede em Seattle, Washington.",
                Phone = "(13) 99442-2211",
                Address = "rua ednaldo 321",
                City = "Seattle",
                State = "Washington",
                PostalCode = "4444-333",
                Country = "USA",
                AdminId = 1
            };

            var result = await client.PostAsJsonAsync<AddStoreInputModel>(UrlStoreController, newStore);

            var store = await client.GetFromJsonAsync<Store>($"{UrlStoreController}/{idStore}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(store);
            Assert.That(store.Id, Is.EqualTo(idStore));
            Assert.That(store.Name, Is.EqualTo(newStore.Name));
            Assert.That(store.Description, Is.EqualTo(newStore.Description));
            Assert.That(store.Phone, Is.EqualTo(newStore.Phone));
            Assert.That(store.Address, Is.EqualTo(newStore.Address));
            Assert.That(store.City, Is.EqualTo(newStore.City));
            Assert.That(store.State, Is.EqualTo(newStore.State));
            Assert.That(store.PostalCode, Is.EqualTo(newStore.PostalCode));
            Assert.That(store.Country, Is.EqualTo(newStore.Country));
            Assert.That(store.AdminId, Is.EqualTo(newStore.AdminId));
        }

        [Test]
        public async Task PutUpdateStore()
        {
            int idStore = 1;

            await using var application = new Web_StoreAPIApplication();

            await StoreMockData.CreateStores(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var newStore = new UpdateStoreInputModel
            {
                Id = idStore,
                Name = "Amazon.com.br",
                Description = "Amazon é uma empresa multinacional de tecnologia norte-americana com sede em Seattle, Washington.",
                Phone = "(13) 99442-2211",
                Address = "rua ednaldo 321",
                City = "Seattle",
                State = "Washington",
                PostalCode = "4444-333",
                Country = "USA",
                AdminId = 1
            };

            var result = await client.PutAsJsonAsync(UrlStoreController, newStore);

            var store = await client.GetFromJsonAsync<Store>($"{UrlStoreController}/{idStore}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(store);
            Assert.That(store.Id, Is.EqualTo(newStore.Id));
            Assert.That(store.Name, Is.EqualTo(newStore.Name));
            Assert.That(store.Description, Is.EqualTo(newStore.Description));
            Assert.That(store.Phone, Is.EqualTo(newStore.Phone));
            Assert.That(store.Address, Is.EqualTo(newStore.Address));
            Assert.That(store.City, Is.EqualTo(newStore.City));
            Assert.That(store.State, Is.EqualTo(newStore.State));
            Assert.That(store.PostalCode, Is.EqualTo(newStore.PostalCode));
            Assert.That(store.Country, Is.EqualTo(newStore.Country));
            Assert.That(store.AdminId, Is.EqualTo(newStore.AdminId));
        }

        [Test]
        public async Task DeleteRemoveStore()
        {
            int idStore = 1;

            await using var application = new Web_StoreAPIApplication();

            await StoreMockData.CreateStores(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.DeleteAsync($"{UrlStoreController}/{idStore}");

            var stores = await client.GetFromJsonAsync<List<Store>>(UrlStoreController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(stores);
            Assert.IsNull(stores.FirstOrDefault(p => p.Id == idStore));
        }
    }
}
