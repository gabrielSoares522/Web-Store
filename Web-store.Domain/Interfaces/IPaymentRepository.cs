using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IPaymentRepository
    {
        Payment Add(Payment payment);
        List<Payment> GetAll();
        Payment GetById(int id);
        bool removeById(int id);
        Payment Update(Payment payment);
    }
}
