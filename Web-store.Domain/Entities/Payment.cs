using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_store.Domain.Entities
{
    public class Payment
    {
        public Payment(int id,double value,int installments, int paymentTypeId, int orderId) {
            Id = id;
            Value = value;
            Installments = installments;
            PaymentTypeId = paymentTypeId;
            OrderId = orderId;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public double Value {  get; set; }
        public int StatusId { get; set; }
        public int Installments { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
