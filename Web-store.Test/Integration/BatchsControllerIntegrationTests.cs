using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Commands.AddBatch;
using Web_store.Application.Commands.UpdateBatch;
using Web_store.Domain.Entities;
using Web_store.Test.Mock;

namespace Web_store.Test.Integration
{
    internal class BatchsControllerIntegrationTests
    {

        private const string UrlBatchController = "api/Batchs";

        [Test]
        public async Task GetBatchs()
        {
            await using var application = new Web_StoreAPIApplication();

            await BatchMockData.CreateBatchs(application, true);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlBatchController);

            var batchs = await client.GetFromJsonAsync<List<Batch>>(UrlBatchController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(batchs);
            Assert.IsTrue(batchs.Count == 6);
        }

        [Test]
        public async Task GetBatchsEmpty()
        {
            await using var application = new Web_StoreAPIApplication();

            await BatchMockData.CreateBatchs(application, false);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlBatchController);

            var batchs = await client.GetFromJsonAsync<List<Batch>>(UrlBatchController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(batchs);
            Assert.IsTrue(batchs.Count == 0);
        }

        [Test]
        public async Task PostCreateBatch()
        {
            int idBatch = 1;
            int idProduct = 1;

            await using var application = new Web_StoreAPIApplication();

            await BatchMockData.CreateBatchs(application, false);

            var client = application.CreateClient();


            var newBatch = new AddBatchInputModel
            {
                ProductId = idProduct,
                Quantity = 120
            };

            var result = await client.PostAsJsonAsync<AddBatchInputModel>(UrlBatchController, newBatch);

            var batch = await client.GetFromJsonAsync<Batch>($"{UrlBatchController}/{idBatch}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(batch);
            Assert.That(batch.Id, Is.EqualTo(idBatch));
        }

        [Test]
        public async Task PutUpdateBatch()
        {
            int idBatch = 1;
            int idProduct = 2;
            await using var application = new Web_StoreAPIApplication();

            await BatchMockData.CreateBatchs(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var newBatch = new UpdateBatchInputModel
            {
                Id = idBatch,
                ProductId = idProduct,
                Quantity = 120
            };

            var result = await client.PutAsJsonAsync(UrlBatchController, newBatch);

            var batch = await client.GetFromJsonAsync<Batch>($"{UrlBatchController}/{idBatch}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(batch);
            Assert.That(batch.Id, Is.EqualTo(newBatch.Id));
            Assert.That(batch.ProductId, Is.EqualTo(newBatch.ProductId));
            Assert.That(batch.Quantity, Is.EqualTo(newBatch.Quantity));
        }

        [Test]
        public async Task DeleteRemoveBatch()
        {
            int idBatch = 1;

            await using var application = new Web_StoreAPIApplication();

            await BatchMockData.CreateBatchs(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.DeleteAsync($"{UrlBatchController}/{idBatch}");

            var batchs = await client.GetFromJsonAsync<List<Batch>>(UrlBatchController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(batchs);
            Assert.IsNull(batchs.FirstOrDefault(p => p.Id == idBatch));
        }
    }
}
