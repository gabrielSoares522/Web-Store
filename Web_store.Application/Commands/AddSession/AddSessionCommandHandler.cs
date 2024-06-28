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
    internal class AddSessionCommandHandler : IRequestHandler<AddSessionCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionRepository _sessionRepository;
        public AddSessionCommandHandler(IUserRepository userRepository,ISessionRepository sessionRepository)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
        }
        public Task<int> Handle(AddSessionCommand request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            var getUserByLoginPasswordViewModel = users
                .Select(s => new GetUserByLoginPasswordViewModel(s.Id, s.FirstName, s.LastName, s.Email, s.Password, s.DateBirth, s.Document, s.AccountTypeId, s.CreatedAt, s.UpdateAt))
                .FirstOrDefault(s => (s.Email == request.Login || s.NickName == request.Login) && s.Password == request.Password);
            if (getUserByLoginPasswordViewModel != null) {
                Session newSession = new Session(0, getUserByLoginPasswordViewModel.Id);
                var sessionId = _sessionRepository.Add(newSession);
                return Task.FromResult(sessionId.Id);
            }
            else
            {
                return Task.FromResult(-1);
            }
        }
    }
}
