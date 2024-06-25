using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IProductImageRepository
    {

        ProductImage Add(ProductImage productImage);
        List<ProductImage> GetAll();
        ProductImage GetById(int id);
        bool removeById(int id);
        ProductImage Update(ProductImage productImage);
    }
}
