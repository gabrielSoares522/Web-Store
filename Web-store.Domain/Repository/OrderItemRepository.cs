using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web_store.Domain.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private DataContext _dataContext;

        public OrderItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public OrderItem Add(OrderItem orderItem)
        {
            _dataContext.OrderItens.Add(orderItem);

            _dataContext.SaveChanges();
            return orderItem;
        }

        public List<OrderItem> GetAll()
        {
            return _dataContext.OrderItens.ToList();
        }

        public OrderItem GetById(int id)
        {
            return _dataContext.OrderItens.FirstOrDefault(x => x.Id == id);
        }

        public bool removeById(int id)
        {
            OrderItem orderItem = GetById(id);

            if (orderItem == null)
            {
                throw new Exception("Houve um erro ao deletar o prouct!");
            }
            _dataContext.Remove(orderItem);

            _dataContext.SaveChanges();
            return true;
        }

        public OrderItem Update(OrderItem orderItem)
        {
            OrderItem orderItemDB = GetById(orderItem.Id);

            if (orderItemDB == null)
            {
                throw new Exception("Houve um erro na atualização do orderItem!");
            }

            orderItemDB.OrderId = orderItem.OrderId;
            orderItemDB.ProductId = orderItem.ProductId;
            orderItemDB.Quantity = orderItem.Quantity;
            orderItemDB.UpdateAt = DateTime.Now;

            _dataContext.OrderItens.Update(orderItemDB);
            _dataContext.SaveChanges();

            return orderItemDB;
        }
    }
}
