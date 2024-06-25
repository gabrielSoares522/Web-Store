using MediatR;
using Web_store.Application.Commands.AddUser;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_user.Application.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(0, request.FirstName, request.LastName, request.NickName, request.Email, request.Password, request.DateBirth, request.Document, request.AccountTypeId);

            _userRepository.Add(user);

            return Task.FromResult(Unit.Value);
        }
    }
}
