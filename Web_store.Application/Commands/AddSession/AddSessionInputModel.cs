using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_store.Application.Commands.AddSession
{
    public class AddSessionInputModel : IRequest<Unit>
    {
        public AddSessionInputModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
