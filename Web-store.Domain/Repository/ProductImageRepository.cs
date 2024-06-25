using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Domain.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private DataContext _dataContext;

        public ProductImageRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ProductImage Add(ProductImage productImage)
        {
            _dataContext.ProductImages.Add(productImage);

            _dataContext.SaveChanges();
            return productImage;
        }

        public List<ProductImage> GetAll()
        {
            return _dataContext.ProductImages.ToList();
        }

        public ProductImage GetById(int id)
        {
            return _dataContext.ProductImages.FirstOrDefault(x => x.Id == id);
        }

        public ProductImage Update(ProductImage productImage)
        {
            ProductImage productImageDB = GetById(productImage.Id);

            if (productImageDB == null)
            {
                throw new Exception("Houve um erro na atualização do productImage!");
            }

            productImageDB.ProductId = productImage.ProductId;
            productImageDB.ImageName = productImage.ImageName;
            productImageDB.BytesImage = productImage.BytesImage;
            productImageDB.UpdateAt = DateTime.Now;

            _dataContext.ProductImages.Update(productImageDB);
            _dataContext.SaveChanges();

            return productImageDB;
        }

        public bool removeById(int id)
        {
            ProductImage productImage = GetById(id);

            if (productImage == null)
            {
                throw new Exception("Houve um erro ao deletar o prouct!");
            }
            _dataContext.Remove(productImage);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
