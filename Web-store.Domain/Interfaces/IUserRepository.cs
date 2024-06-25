using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        List<User> GetAll();
        User GetById(int id);
        bool removeById(int id);
        User Update(User user);
    }
}
