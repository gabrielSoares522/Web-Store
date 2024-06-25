using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Queries.GetStores
{
    public class GetStoresViewModel
    {
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

        public GetStoresViewModel(int id, string name, string description, string phone, string address, string city, string state, string postalCode, string country, int adminId)
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
