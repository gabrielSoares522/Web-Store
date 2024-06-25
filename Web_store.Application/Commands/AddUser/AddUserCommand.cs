using MediatR;

namespace Web_store.Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateBirth { get; set; }
        public string Document { get; set; }
        public int AccountTypeId { get; set; }

        public AddUserCommand(string firstName, string lastName, string nickName, string email, string password, DateTime dateBirth, string document, int accountTypeId)
        {
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
