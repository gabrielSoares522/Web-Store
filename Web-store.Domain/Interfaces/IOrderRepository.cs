using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        List<Order> GetAll();
        Order GetById(int id);
        bool removeById(int id);
    }
}
