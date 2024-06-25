using Microsoft.EntityFrameworkCore;
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
    public class BatchRepository : IBatchRepository
    {
        private DataContext _dataContext;

        public BatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Batch Add(Batch patch)
        {
            _dataContext.Batchs.Add(patch);

            _dataContext.SaveChanges();

            return patch;
        }

        public List<Batch> GetAll()
        {
            return _dataContext.Batchs.ToList();
        }

        public Batch GetById(int id)
        {
            return _dataContext.Batchs.FirstOrDefault(x => x.Id == id);
        }
        public Batch Update(Batch patch)
        {

            Batch batchDB = GetById(patch.Id);

            if (batchDB == null)
            {
                throw new Exception("Houve um erro na atualização do Patch!");
            }

            batchDB.ProductId = patch.ProductId;
            batchDB.Quantity = patch.Quantity;
            batchDB.UpdateAt = DateTime.Now;

            _dataContext.Batchs.Update(batchDB);
            _dataContext.SaveChanges();

            return batchDB;
        }
        public bool removeById(int id)
        {
            Batch patch = GetById(id);

            if (patch == null)
            {
                throw new Exception("Houve um erro ao deletar o patch!");
            }

            _dataContext.Remove(patch);

            _dataContext.SaveChanges();

            return true;
        }
    }
}
