﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_store.Domain.Entities;

namespace Web_store.Domain.Interfaces
{
    public interface ISessionRepository
    {

        Session Add(Session session);
        List<Session> GetAll();
        Session GetById(int id);
        bool removeById(int id);
        Session Update(Session session);
    }
}