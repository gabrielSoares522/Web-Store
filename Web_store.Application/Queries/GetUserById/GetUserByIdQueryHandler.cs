using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<GetUserByIdViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            var getUserByIdViewModel = users
                .Select(s => new GetUserByIdViewModel(s.Id, s.FirstName, s.LastName, s.Email, s.Password, s.DateBirth, s.Document, s.AccountTypeId,s.CreatedAt,s.UpdateAt))
                .FirstOrDefault(s => s.Id == request.IdUser);

            return Task.FromResult(getUserByIdViewModel);
        }
    }
}
