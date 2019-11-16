using BoardGameLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameLogger.Data
{
    public interface IBoardGameData
    {
        BoardGame addBoardGame(BoardGame boardGame);
        IEnumerable<BoardGame> getAll();
        BoardGame get(int id);
    }
}
