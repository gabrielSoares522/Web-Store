using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetUserById;

namespace Web_store.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
    {
        public GetUserByIdQuery(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; set; }
    }
}
