using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Test.Mock;
using Web_store.Domain.Entities;
using Web_store.Application.Commands.AddProduct;
using Web_store.Application.Commands.UpdateProduct;

namespace Web_store.Test.Integration
{
    public class ProductsControllerIntegrationTests
    {
        private const string UrlProductController = "api/Products";

        [Test]
        public async Task GetProducts() {
            await using var application = new Web_StoreAPIApplication();
            
            await ProductMockData.CreateProducts(application, true);
            
            var client = application.CreateClient();

            var result = await client.GetAsync(UrlProductController);

            var products = await client.GetFromJsonAsync<List<Product>>(UrlProductController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count == 6);
        }

        [Test]
        public async Task GetProductsEmpty() {
            await using var application = new Web_StoreAPIApplication();

            await ProductMockData.CreateProducts(application, false);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlProductController);

            var products = await client.GetFromJsonAsync<List<Product>>(UrlProductController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count == 0);
        }

        [Test]
        public async Task PostCreateProduct() {
            int idProduct = 1;

            await using var application = new Web_StoreAPIApplication();

            await ProductMockData.CreateProducts(application, false);

            var client = application.CreateClient();


            var newProduct = new AddProductInputModel {
                Name="Water Cooler Gamer Fan Ventoinha 120mm Rgb Pc Processador CPU Master Intel AMD",
                Description="Dimensões do produto\t12C x 12L x 2,5A centímetros\r\nMarca\tRevenger\r\nTipo de conector de energia\t4 pinos\r\nTensão\t12 Volts\r\nMétodo de refrigeração\tÁgua",
                Value=222.29,
                Quantity=120,
                IsAvailable=true
            };

            var result = await client.PostAsJsonAsync<AddProductInputModel>(UrlProductController, newProduct);

            var product = await client.GetFromJsonAsync<Product>($"{UrlProductController}/{idProduct}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo(idProduct));
        }

        [Test]
        public async Task PutUpdateProduct() {
            int idProduct = 1;

            await using var application = new Web_StoreAPIApplication();

            await ProductMockData.CreateProducts(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var newProduct = new UpdateProductInputModel {
                Id = idProduct,
                Name = "Water Cooler Gamer Fan Ventoinha 120mm Rgb Pc Processador CPU Master Intel AMD",
                Description = "Dimensões do produto\t12C x 12L x 2,5A centímetros\r\nMarca\tRevenger\r\nTipo de conector de energia\t4 pinos\r\nTensão\t12 Volts\r\nMétodo de refrigeração\tÁgua",
                Value = 222.29,
                Quantity = 120,
                IsAvailable = true,
                StoreId = 1
            };

            var result = await client.PutAsJsonAsync(UrlProductController, newProduct);

            var product = await client.GetFromJsonAsync<Product>($"{UrlProductController}/{idProduct}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(product);
            Assert.That(product.Id, Is.EqualTo(newProduct.Id));
            Assert.That(product.Name, Is.EqualTo(newProduct.Name));
            Assert.That(product.Description, Is.EqualTo(newProduct.Description));
            Assert.That(product.Value, Is.EqualTo(newProduct.Value));
            Assert.That(product.Quantity, Is.EqualTo(newProduct.Quantity));
            Assert.That(product.IsAvailable, Is.EqualTo(newProduct.IsAvailable));
            Assert.That(product.StoreId, Is.EqualTo(newProduct.StoreId));
        }

        [Test]
        public async Task DeleteRemoveProduct() {
            int idProduct = 1;

            await using var application = new Web_StoreAPIApplication();

            await ProductMockData.CreateProducts(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.DeleteAsync($"{UrlProductController}/{idProduct}");

            var products = await client.GetFromJsonAsync<List<Product>>(UrlProductController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(products);
            Assert.IsNull(products.FirstOrDefault(p => p.Id == idProduct));
        }
    }
}
