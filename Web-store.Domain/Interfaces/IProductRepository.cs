using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IProductRepository
    {
        Product Add(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        bool removeById(int id);
        Product Update(Product product);
    }
}
