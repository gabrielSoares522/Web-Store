using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetUserByLoginPassword
{
    public class GetUserByLoginPasswordQueryHandler : IRequestHandler<GetUserByLoginPasswordQuery, GetUserByLoginPasswordViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByLoginPasswordQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<GetUserByLoginPasswordViewModel> Handle(GetUserByLoginPasswordQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            var getUserByLoginPasswordViewModel = users
                .Select(s => new GetUserByLoginPasswordViewModel(s.Id, s.FirstName, s.LastName, s.Email, s.Password, s.DateBirth, s.Document, s.AccountTypeId,s.CreatedAt,s.UpdateAt))
                .FirstOrDefault(s => (s.Email == request.Login || s.NickName == request.Login) && s.Password == request.Password);

            return Task.FromResult(getUserByLoginPasswordViewModel);
        }
    }
}