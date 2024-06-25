using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Queries.GetUserById
{
    public class GetUserByIdViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Document { get; set; }
        public int AccountTypeId { get; set; }

        public GetUserByIdViewModel(int id, string firstName, string lastName, string email, string password, DateTime dateBirth, string document, int accountTypeId,DateTime createAt,DateTime updateAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateBirth = dateBirth;
            CreatedAt = createAt;
            UpdateAt = updateAt;
            Document = document;
            AccountTypeId = accountTypeId;
        }
    }
}
