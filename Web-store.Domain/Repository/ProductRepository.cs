using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Product Add(Product product)
        {
            _dataContext.Products.Add(product);

            _dataContext.SaveChanges();
            return product;
        }

        public List<Product> GetAll()
        {
            return _dataContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dataContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product Update(Product product)
        {

            Product productDB = GetById(product.Id);

            if (productDB == null)
            {
                throw new Exception("Houve um erro na atualização do product!");
            }

            productDB.Name = product.Name;
            productDB.Description = product.Description;
            productDB.Quantity = product.Quantity;
            productDB.Value = product.Value;
            productDB.IsAvailable = product.IsAvailable;
            productDB.StoreId = product.StoreId;
            productDB.UpdateAt = DateTime.Now;

            _dataContext.Products.Update(productDB);
            _dataContext.SaveChanges();

            return productDB;
        }

        public bool removeById(int id)
        {
            Product product = GetById(id);

            if (product == null)
            {
                throw new Exception("Houve um erro ao deletar o prouct!");
            }
            _dataContext.Remove(product);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
