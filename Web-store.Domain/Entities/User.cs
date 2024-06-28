using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Web_store.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string Document { get; set; }
        public int AccountTypeId { get; set; }

        public List<Session> Sessions { get; set; }
        public User (int id, string firstName, string lastName,string nickName, string email,string password, DateTime dateBirth, string document, int accountTypeId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Email = email;
            Password = password;
            DateBirth = dateBirth;
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
            Document = document;
            AccountTypeId = accountTypeId;
        }
    }
}
