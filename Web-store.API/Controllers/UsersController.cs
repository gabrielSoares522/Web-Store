using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web_store.Application.Commands.AddUser;
using Web_store.Application.Commands.RemoveUser;
using Web_store.Application.Commands.UpdateUser;
using Web_store.Application.Queries.GetUserById;
using Web_store.Application.Queries.GetUserByLoginPassword;
using Web_store.Application.Queries.GetUsers;

namespace Web_store.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(string search)
        {
            var query = new GetUsersQuery(search);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetUserById([FromRoute] int idUser)
        {
            var getUserByIdQuery = new GetUserByIdQuery(idUser);

            var result = await _mediator.Send(getUserByIdQuery);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserInputModel user)
        {
            var command = new AddUserCommand(user.FirstName, user.LastName,user.NickName, user.Email, user.Password, user.DateBirth, user.Document, user.AccountTypeId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserInputModel user)
        {
            var command = new UpdateUserCommand(user.Id, user.FirstName, user.LastName, user.NickName, user.Email, user.Password, user.DateBirth, user.Document, user.AccountTypeId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{idUser}")]
        public async Task<IActionResult> RemoveUser([FromRoute] int idUser)
        {
            var command = new RemoveUserCommand(idUser);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{login}/{password}")]
        public async Task<IActionResult> ValidateLogin([FromRoute] string login, [FromRoute] string password)
        {
            var query = new GetUserByLoginPasswordQuery(login,password);

            var result = await _mediator.Send(query);

            if(result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

    }
}
