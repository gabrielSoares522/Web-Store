using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface IPaymentTypeRepository
    {
        PaymentType Add(PaymentType paymentType);
        List<PaymentType> GetAll();
        PaymentType GetById(int id);
        bool removeById(int id);
        PaymentType Update(PaymentType paymentType);
    }
}
