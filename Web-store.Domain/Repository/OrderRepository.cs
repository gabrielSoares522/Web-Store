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
    public class OrderRepository : IOrderRepository
    {
        private DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Order Add(Order order)
        {
            _dataContext.Orders.Add(order);

            _dataContext.SaveChanges();
            return order;
        }

        public List<Order> GetAll()
        {
            return _dataContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dataContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public bool removeById(int id)
        {
            Order order = GetById(id);

            if (order == null)
            {
                throw new Exception("Houve um erro ao deletar o prouct!");
            }
            _dataContext.Remove(order);

            _dataContext.SaveChanges();
            return true;
        }
    }
}
