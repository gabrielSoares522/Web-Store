using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Domain.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private DataContext _dataContext;

        public StoreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Store Add(Store store)
        {
            _dataContext.Stores.Add(store);

            _dataContext.SaveChanges();

            return store;
        }

        public List<Store> GetAll()
        {
            return _dataContext.Stores.ToList();
        }

        public Store GetById(int id)
        {
            return _dataContext.Stores.FirstOrDefault(x => x.Id == id);
        }

        public Store Update(Store store)
        {

            Store storeDB = GetById(store.Id);

            if (storeDB == null)
            {
                throw new System.Exception("Houve um erro na atualização do store!");
            }

            storeDB.Name = store.Name;
            storeDB.Description = store.Description;
            storeDB.Phone = store.Phone;
            storeDB.Address = store.Address;
            storeDB.City = store.City;
            storeDB.State = store.State;
            storeDB.PostalCode = store.PostalCode;
            storeDB.Country = store.Country;
            storeDB.UpdateAt = DateTime.Now;
            storeDB.AdminId = store.AdminId;

            _dataContext.Stores.Update(storeDB);
            _dataContext.SaveChanges();

            return storeDB;
        }

        public bool removeById(int id)
        {
            Store store = GetById(id);

            if (store == null)
            {
                throw new Exception("Houve um erro ao deletar o store!");
            }
            _dataContext.Remove(store);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
