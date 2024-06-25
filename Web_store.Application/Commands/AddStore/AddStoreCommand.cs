using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Application.Commands.AddStore
{
    public class AddStoreCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int AdminId { get; set; }

        public AddStoreCommand(string name, string description, string phone, string address, string city, string state, string postalCode, string country, int adminId)
        {
            Name = name;
            Description = description;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            AdminId = adminId;
        }
    }
}
