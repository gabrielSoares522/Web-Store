using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IStoreRepository
    {
        Store Add(Store store);
        List<Store> GetAll();
        Store GetById(int id);
        bool removeById(int id);
        Store Update(Store store);

    }
}
