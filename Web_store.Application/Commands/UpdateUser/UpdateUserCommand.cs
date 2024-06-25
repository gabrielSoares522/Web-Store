using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
        public string Document { get; set; }
        public int AccountTypeId { get; set; }

        public UpdateUserCommand(int id, string firstName, string lastName, string nickName, string email, string password, DateTime dateBirth, string document, int accountTypeId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Email = email;
            Password = password;
            DateBirth = dateBirth;
            Document = document;
            AccountTypeId = accountTypeId;
        }
    }
}
