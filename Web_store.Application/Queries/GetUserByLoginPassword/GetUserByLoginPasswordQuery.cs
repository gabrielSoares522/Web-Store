using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetUserById;

namespace Web_store.Application.Queries.GetUserByLoginPassword
{
    public class GetUserByLoginPasswordQuery : IRequest<GetUserByLoginPasswordViewModel>
    {
        public GetUserByLoginPasswordQuery(string login,string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
