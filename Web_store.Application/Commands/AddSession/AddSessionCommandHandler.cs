using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Application.Queries.GetUserByLoginPassword;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Application.Commands.AddSession
{
    internal class AddSessionCommandHandler : IRequestHandler<AddSessionCommand, AddSessionViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        public AddSessionCommandHandler(IUserRepository userRepository,ISessionRepository sessionRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
        }
        public Task<AddSessionViewModel> Handle(AddSessionCommand request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            var loggedUser = users
                .FirstOrDefault(s => (s.Email == request.Login || s.NickName == request.Login) && s.Password == request.Password);
            
            if (loggedUser != null) {
                Session newSession = new Session(0, loggedUser.Id);
                var sessionId = _sessionRepository.Add(newSession);
                AddSessionViewModel result = new AddSessionViewModel()
                {
                    Id = loggedUser.Id,
                    FirstName = loggedUser.FirstName,
                    LastName = loggedUser.LastName,
                    NickName = loggedUser.NickName,
                    Email = loggedUser.Email,
                    DateBirth = loggedUser.DateBirth,
                    CreatedAt = loggedUser.CreatedAt,
                    UpdateAt = loggedUser.UpdateAt,
                    Document = loggedUser.Document,
                    AccountTypeId = loggedUser.AccountTypeId,
                    SessionId = sessionId.Id
                };
                return Task.FromResult(result);
            }
            else
            {
                return Task.FromResult(new AddSessionViewModel() { SessionId = -1 });
            }
        }
    }
}
