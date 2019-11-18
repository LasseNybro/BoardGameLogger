using BoardGameLogger.Services;
using BoardGameLogger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace BoardGameLogger.Controllers
{
    public class BoardGameController:Controller
    {
        private IBoardGameData _boardGameData;
        private ISessionData _sessionData;

        public BoardGameController(IBoardGameData boardGameData, ISessionData sessionData)
        {
            _boardGameData = boardGameData;
            _sessionData = sessionData;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            BoardGame model = _boardGameData.Get(id);
            return View("BoardGameDetails", model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("BoardGameCreate");
        }
        [HttpPost]
        public IActionResult Create(BoardGameEdit boardGameEdit)
        {
            BoardGame newBoardGame = new BoardGame
            {
                Name = boardGameEdit.Name,
                Genre = boardGameEdit.Genre,
                Description = boardGameEdit.Description,
                MinPlayers = boardGameEdit.MinPlayers,
                MaxPlayers = boardGameEdit.MaxPlayers,
            };
            newBoardGame = _boardGameData.CreateBoardGame(newBoardGame);

            return View("BoardGameDetails", newBoardGame);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            BoardGame model = _boardGameData.Get(id);
            return View("BoardGameEdit", model);
        }
        [HttpPost]
        public IActionResult Edit(BoardGame boardGame)
        {
            boardGame = _boardGameData.EditBoardGame(boardGame);

            return View("BoardGameDetails", boardGame);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            BoardGame model = _boardGameData.Get(id);
            _boardGameData.DeleteBoardGame(model);

            return View();
        }
        [HttpGet]
        public IActionResult GetSession(int id)
        {
            Session model = _sessionData.Get(id);
            return View("SessionDetails", model);
        }
        [HttpGet]
        public IActionResult CreateSession(int id)
        {
            ViewBag.BoardGameName = _boardGameData.Get(id).Name;
            ViewBag.BoardGameId = _boardGameData.Get(id).Id;
            return View("SessionCreate");
        }
        [HttpPost]
        public IActionResult CreateSession(Session session)
        {
            Session newSession = new Session();
            newSession.BoardGameId = session.BoardGameId;
            newSession.Date = session.Date;
            newSession.Description = session.Description;
            newSession = _sessionData.CreateSession(newSession);

            BoardGame model = _boardGameData.Get(session.BoardGameId);
            List<Session> newSessionList = model.Sessions.ToList();
            newSessionList.Add(newSession);
            model.Sessions=newSessionList.AsEnumerable();
            _boardGameData.EditBoardGame(model);

            return View("BoardGameDetails", model);
        }
    }
}
