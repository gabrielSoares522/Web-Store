using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.removeById(request.Id);

            return Task.FromResult(Unit.Value);
        }
    }
}
