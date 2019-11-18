using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameLogger.Data;
using BoardGameLogger.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameLogger.Services
{
    public class SqlBoardGameData : IBoardGameData
    {
        private ApplicationDbContext _applicationDbContext;

        public SqlBoardGameData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public BoardGame CreateBoardGame(BoardGame boardGame)
        {
            _applicationDbContext.BoardGames.Add(boardGame);
            _applicationDbContext.SaveChanges();
            return boardGame;
        }

        public void DeleteBoardGame(BoardGame boardGame)
        {
            _applicationDbContext.Attach(boardGame).State = EntityState.Deleted;
            _applicationDbContext.SaveChanges();
        }

        public BoardGame EditBoardGame(BoardGame boardGame)
        {
            _applicationDbContext.Attach(boardGame).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return boardGame;
        }

        public BoardGame Get(int id)
        {
            return _applicationDbContext.BoardGames.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _applicationDbContext.BoardGames.OrderBy(b => b.Name);
        }

        public IEnumerable<BoardGame> GetAllGenreName(GenreType genre, string name)
        {
            if (genre == GenreType.None && string.IsNullOrWhiteSpace(name))
            {
                return GetAll();
            }
            if (genre == GenreType.None)
            {
                return _applicationDbContext.BoardGames.Where(b => b.Name == name).OrderBy(g => g.Name).ToList();
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                return _applicationDbContext.BoardGames.Where(b => b.Genre == genre).ToList();
            }
            return _applicationDbContext.BoardGames.Where(b => b.Name == name && b.Genre == genre).OrderBy(g => g.Name).ToList();
        }
    }
}
