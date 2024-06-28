using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Data;
using Web_store.Domain.Entities;
using Web_store.Domain.Interfaces;

namespace Web_store.Domain.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private DataContext _dataContext;

        public SessionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Session Add(Session session)
        {
            _dataContext.Sessions.Add(session);

            _dataContext.SaveChanges();

            return session;
        }

        public List<Session> GetAll()
        {
            return _dataContext.Sessions.ToList();
        }

        public Session GetById(int id)
        {
            return _dataContext.Sessions.FirstOrDefault(x => x.Id == id);
        }
        public Session Update(Session session)
        {

            Session sessionDB = GetById(session.Id);

            if (sessionDB == null)
            {
                throw new Exception("Houve um erro na atualização do session!");
            }

            sessionDB.UserId = session.UserId;
            sessionDB.StatusId = session.StatusId;
            sessionDB.FinishedAt = session.FinishedAt;
            sessionDB.UpdateAt = DateTime.Now;

            _dataContext.Sessions.Update(sessionDB);
            _dataContext.SaveChanges();

            return sessionDB;
        }
        public bool removeById(int id)
        {
            Session session = GetById(id);

            if (session == null)
            {
                throw new Exception("Houve um erro ao deletar o session!");
            }

            _dataContext.Remove(session);

            _dataContext.SaveChanges();

            return true;
        }
    }
}
