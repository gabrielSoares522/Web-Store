using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Domain.Entities
{
    public class Store
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public User Admin { get; set; }

        public List<Product> Products { get; set; }
        public Store(int id, string name, string description, string phone, string address, string city,string state, string postalCode, string country, int adminId)
        {
            Id = id;
            Name = name;
            Description = description;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            AdminId = adminId;
        }
    }
}
