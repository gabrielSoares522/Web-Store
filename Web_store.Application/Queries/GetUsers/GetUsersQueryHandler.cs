using MediatR;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersViewModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<List<GetUsersViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            if (request.Search == null)
            {
                var getUsersViewModelList = users
                    .Select(s => new GetUsersViewModel(s.Id, s.FirstName, s.LastName, s.NickName, s.Email, s.Password, s.DateBirth, s.Document, s.AccountTypeId))
                    .ToList();

                return Task.FromResult(getUsersViewModelList);
            }
            else
            {
                var getUsersViewModelList = users
                    .Select(s => new GetUsersViewModel(s.Id, s.FirstName, s.LastName, s.NickName, s.Email, s.Password, s.DateBirth, s.Document, s.AccountTypeId))
                    .Where(s => s.FirstName.ToUpper().Contains(request.Search.ToUpper()) || s.LastName.ToUpper().Contains(request.Search.ToUpper()))
                    .ToList();

                return Task.FromResult(getUsersViewModelList);

            }
        }
    }
}
