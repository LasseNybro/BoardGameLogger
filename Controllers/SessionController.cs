using BoardGameLogger.Models;
using BoardGameLogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameLogger.Controllers
{
    public class SessionController:Controller
    {
        private ISessionData _sessionData;

        public SessionController(ISessionData sessionData)
        {
            _sessionData = sessionData;
        }
        
    }
}
