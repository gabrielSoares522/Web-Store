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
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private DataContext _dataContext;

        public PaymentTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public PaymentType Add(PaymentType paymentType)
        {
            _dataContext.PaymentTypes.Add(paymentType);

            _dataContext.SaveChanges();
            return paymentType;
        }

        public List<PaymentType> GetAll()
        {
            return _dataContext.PaymentTypes.ToList();
        }

        public PaymentType GetById(int id)
        {
            return _dataContext.PaymentTypes.FirstOrDefault(x => x.Id == id);
        }

        public bool removeById(int id)
        {
            PaymentType paymentType = GetById(id);

            if (paymentType == null)
            {
                throw new Exception("Houve um erro ao deletar o prouct!");
            }
            _dataContext.Remove(paymentType);

            _dataContext.SaveChanges();
            return true;
        }

        public PaymentType Update(PaymentType paymentType)
        {
            PaymentType paymentTypeDB = GetById(paymentType.Id);

            if (paymentTypeDB == null)
            {
                throw new Exception("Houve um erro na atualização do paymentType!");
            }

            paymentTypeDB.Name = paymentType.Name;
            paymentTypeDB.UpdateAt = DateTime.Now;
            _dataContext.PaymentTypes.Update(paymentTypeDB);
            _dataContext.SaveChanges();

            return paymentTypeDB;
        }
    }
}
