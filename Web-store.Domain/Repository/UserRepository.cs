using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User Add(User user)
        {
            _dataContext.Users.Add(user);

            _dataContext.SaveChanges();
            return user;
        }

        public List<User> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User user)
        {

            User userDB = GetById(user.Id);

            if (userDB == null)
            {
                throw new Exception("Houve um erro na atualização do user!");
            }

            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            userDB.Email = user.Email;
            userDB.Password = user.Password;
            userDB.DateBirth = user.DateBirth;
            userDB.UpdateAt = DateTime.Now;
            userDB.Document = user.Document;
            userDB.AccountTypeId = user.AccountTypeId;

            _dataContext.Users.Update(userDB);
            _dataContext.SaveChanges();

            return userDB;
        }

        public bool removeById(int id)
        {
            User user = GetById(id);
            if (user == null)
            {
                throw new System.Exception("Houve um erro ao deletar o user!");
            }
            _dataContext.Remove(user);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
