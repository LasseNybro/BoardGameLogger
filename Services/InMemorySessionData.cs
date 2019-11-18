using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameLogger.Models;

namespace BoardGameLogger.Services
{
    public class InMemorySessionData : ISessionData
    {
        private List<Session> _sessionStorage;

        public InMemorySessionData()
        {
            List<Session> SessionStorage = new List<Session>()
            {
                new Session
                {
                    Id=1,
                    BoardGameId=1,
                    Date=DateTime.Now,
                    Description="We played a game of Dixit, we had a lot of fun, Thomas won."
                },
                new Session
                {
                    Id=2,
                    BoardGameId=2,
                    Date=DateTime.Now,
                    Description="We played a game of Carcassonne, John built all the towns, but Thomas won."
                }
            };
            _sessionStorage = SessionStorage;
        }

        public Session CreateSession(Session session)
        {
            int id = _sessionStorage.Max(b => b.Id) + 1;
            session.Id = id;
            _sessionStorage.Add(session);
            return session;
        }

        public Session EditBoardGame(Session session)
        {
            throw new NotImplementedException();
        }

        public Session Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetAllGameId(int gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Session> GetAllUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
