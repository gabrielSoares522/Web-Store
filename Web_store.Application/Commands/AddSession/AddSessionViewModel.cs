using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.AddSession
{
    public class AddSessionViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Document { get; set; }
        public int AccountTypeId { get; set; }
        public int SessionId { get; set; }
    }
}
