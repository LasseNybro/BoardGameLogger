using BoardGameLogger.Models;
using System.Collections.Generic;

namespace BoardGameLogger.Services
{
    public interface ISessionData
    {
        Session Get(int id);
        IEnumerable<Session> GetAllGameId(int gameId);
        IEnumerable<Session> GetAllUserId(int userId);
        Session CreateSession(Session session);
        Session EditBoardGame(Session session);
    }
}
