using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem Add(OrderItem orderItem);
        List<OrderItem> GetAll();
        OrderItem GetById(int id);
        bool removeById(int id);
        OrderItem Update(OrderItem orderItem);
    }
}
