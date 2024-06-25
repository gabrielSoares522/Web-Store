using System.ComponentModel.DataAnnotations;

namespace Web_store.Domain.Entities
{
    public class PaymentType
    {
        public PaymentType(int id,string name) {
            Id = id;
            Name = name;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public List<Payment> Payments { get; set; }

    }
}
