using BoardGameLogger.Models;
using System.Collections.Generic;

namespace BoardGameLogger.Services
{
    public interface IBoardGameData
    {
        BoardGame Get(int id);
        IEnumerable<BoardGame> GetAll();
        IEnumerable<BoardGame> GetAllGenreName(GenreType genre, string name);
        BoardGame CreateBoardGame(BoardGame boardGame);
        BoardGame EditBoardGame(BoardGame boardGame);
        void DeleteBoardGame(BoardGame boardGame);
    }
}
