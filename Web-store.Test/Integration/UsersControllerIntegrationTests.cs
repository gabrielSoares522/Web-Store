using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Commands.AddUser;
using Web_store.Application.Commands.UpdateUser;
using Web_store.Domain.Entities;
using Web_store.Test.Mock;
using System.Reflection.Metadata;

namespace Web_store.Test.Integration
{
    internal class UsersControllerIntegrationTests
    {


        private const string UrlUserController = "api/Users";

        [Test]
        public async Task GetUsers()
        {
            await using var application = new Web_StoreAPIApplication();

            await UserMockData.CreateUsers(application, true);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlUserController);

            var users = await client.GetFromJsonAsync<List<User>>(UrlUserController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count == 6);
        }

        [Test]
        public async Task GetUsersEmpty()
        {
            await using var application = new Web_StoreAPIApplication();

            await UserMockData.CreateUsers(application, false);

            var client = application.CreateClient();

            var result = await client.GetAsync(UrlUserController);

            var users = await client.GetFromJsonAsync<List<User>>(UrlUserController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count == 0);
        }

        [Test]
        public async Task PostCreateUser()
        {
            int idUser = 1;
            int idProduct = 1;

            await using var application = new Web_StoreAPIApplication();

            await UserMockData.CreateUsers(application, false);

            var client = application.CreateClient();


            var newUser = new AddUserInputModel
            {
                FirstName = "Gabriel",
                LastName = "Soares",
                Email = "gabriel.soares@gmail.com",
                NickName = "gabriel",
                Password = "12345",
                DateBirth = new DateTime(1999, 4, 15),
                Document = "67416709806",
                AccountTypeId = 1
        };

            var result = await client.PostAsJsonAsync<AddUserInputModel>(UrlUserController, newUser);

            var user = await client.GetFromJsonAsync<User>($"{UrlUserController}/{idUser}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(user);
            Assert.That(user.Id, Is.EqualTo(idUser));
            Assert.That(user.FirstName, Is.EqualTo(newUser.FirstName));
            Assert.That(user.LastName, Is.EqualTo(newUser.LastName));
            Assert.That(user.Email, Is.EqualTo(newUser.Email));
            Assert.That(user.Password, Is.EqualTo(newUser.Password));
            Assert.That(user.DateBirth, Is.EqualTo(newUser.DateBirth));
            Assert.That(user.Document, Is.EqualTo(newUser.Document));
            Assert.That(user.AccountTypeId, Is.EqualTo(newUser.AccountTypeId));
        }

        [Test]
        public async Task PutUpdateUser()
        {
            int idUser = 1;
            int idProduct = 1;
            await using var application = new Web_StoreAPIApplication();

            await UserMockData.CreateUsers(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var newUser = new UpdateUserInputModel
            {
                Id = idUser,
                FirstName = "Gabriel",
                LastName = "Soares",
                NickName = "gabriel",
                Email = "gabriel.soares@gmail.com",
                Password = "12345",
                DateBirth = new DateTime(1999, 4, 15),
                Document = "67416709806",
                AccountTypeId = 1
            };

            var result = await client.PutAsJsonAsync(UrlUserController, newUser);

            var user = await client.GetFromJsonAsync<User>($"{UrlUserController}/{idUser}");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(user);
            Assert.That(user.Id, Is.EqualTo(newUser.Id));
            Assert.That(user.FirstName, Is.EqualTo(newUser.FirstName));
            Assert.That(user.LastName, Is.EqualTo(newUser.LastName));
            Assert.That(user.Email, Is.EqualTo(newUser.Email));
            Assert.That(user.Password, Is.EqualTo(newUser.Password));
            Assert.That(user.DateBirth, Is.EqualTo(newUser.DateBirth));
            Assert.That(user.Document, Is.EqualTo(newUser.Document));
            Assert.That(user.AccountTypeId, Is.EqualTo(newUser.AccountTypeId));
        }

        [Test]
        public async Task DeleteRemoveUser()
        {
            int idUser = 1;

            await using var application = new Web_StoreAPIApplication();

            await UserMockData.CreateUsers(application, true);

            var client = application.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.DeleteAsync($"{UrlUserController}/{idUser}");

            var users = await client.GetFromJsonAsync<List<User>>(UrlUserController);

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsNotNull(users);
            Assert.IsNull(users.FirstOrDefault(p => p.Id == idUser));
        }
    }
}
