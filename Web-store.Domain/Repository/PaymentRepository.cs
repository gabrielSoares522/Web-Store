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
    public class PaymentRepository : IPaymentRepository
    {
        private DataContext _dataContext;

        public PaymentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Payment Add(Payment payment)
        {
            _dataContext.Payments.Add(payment);

            _dataContext.SaveChanges();
            return payment;
        }

        public List<Payment> GetAll()
        {
            return _dataContext.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return _dataContext.Payments.FirstOrDefault(x => x.Id == id);
        }

        public bool removeById(int id)
        {
            Payment payment = GetById(id);

            if (payment == null)
            {
                throw new Exception("Houve um erro ao deletar o Payment!");
            }
            _dataContext.Remove(payment);

            _dataContext.SaveChanges();
            return true;
        }

        public Payment Update(Payment payment)
        {
            Payment paymentDB = GetById(payment.Id);

            if (paymentDB == null)
            {
                throw new Exception("Houve um erro na atualização do Payment!");
            }

            paymentDB.Value = payment.Value;
            paymentDB.Installments = payment.Installments;
            paymentDB.StatusId = payment.StatusId;
            paymentDB.PaymentTypeId = payment.PaymentTypeId;
            paymentDB.OrderId = payment.OrderId;
            paymentDB.UpdateAt = DateTime.Now;

            _dataContext.Payments.Update(paymentDB);
            _dataContext.SaveChanges();

            return paymentDB;
        }
    }
}
