using BoardGameLogger.Data;
using BoardGameLogger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameLogger.Controllers
{
    public class BoardGameController:Controller
    {
        private IBoardGameData _boardGameData;

        public BoardGameController(IBoardGameData boardGameData)
        {
            _boardGameData = boardGameData;
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            BoardGame model = _boardGameData.get(id);
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
            BoardGame newBoardGame = new BoardGame();
            newBoardGame.Name = boardGameEdit.Name;
            newBoardGame.Genre = boardGameEdit.Genre;
            newBoardGame.Description = boardGameEdit.Description;
            newBoardGame.MinPlayers = boardGameEdit.MinPlayers;
            newBoardGame.MaxPlayers = boardGameEdit.MaxPlayers;
            newBoardGame = _boardGameData.addBoardGame(newBoardGame);

            return View("BoardGameDetails", newBoardGame);
        }
    }
}
