using MediatR;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Id, request.FirstName, request.LastName, request.NickName, request.Email, request.Password, request.DateBirth, request.Document, request.AccountTypeId);

            _userRepository.Update(user);

            return Task.FromResult(Unit.Value);
        }
    }
}
