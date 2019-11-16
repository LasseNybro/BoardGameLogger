using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGameLogger.Models;

namespace BoardGameLogger.Data
{
    public class InMemoryBoardGameData : IBoardGameData
    {
        private List<BoardGame> _BoardGameStorage;

        public InMemoryBoardGameData()
        {
            List<BoardGame> BoardGameStorage = new List<BoardGame>()
            {
                new BoardGame()
                {
                    Id = 1,
                    Name = "Loot Letter",
                    Genre = GenreType.HiddenIdentity,
                    Description = "A short game about guessing who has got the loot.",
                    MinPlayers = 2,
                    MaxPlayers = 4
                },
                new BoardGame()
                {
                    Id = 2,
                    Name = "Carcasonne",
                    Genre = GenreType.Strategy,
                    Description = "A tile-laying game about placing meeples and farming.",
                    MinPlayers = 2,
                    MaxPlayers = 4
                },
                new BoardGame()
                {
                    Id = 3,
                    Name = "One Night Ultimate Werewolf",
                    Genre = GenreType.HiddenIdentity,
                    Description = "A short game about guessing who is the werewolf.",
                    MinPlayers = 3,
                    MaxPlayers = 10
                },
                new BoardGame()
                {
                    Id = 4,
                    Name = "7 Wonders",
                    Genre = GenreType.Strategy,
                    Description = "A card game about constructing the best civilization and constructing your wonder.",
                    MinPlayers = 3,
                    MaxPlayers = 7
                },
                new BoardGame()
                {
                    Id = 5,
                    Name = "Dixit",
                    Genre = GenreType.Abstract,
                    Description = "An abstract game where you describe abstract pictures on cards and try to make some of the other players guess your card.",
                    MinPlayers = 3,
                    MaxPlayers = 6
                },
                new BoardGame()
                {
                    Id = 6,
                    Name = "Hanabi",
                    Genre = GenreType.CoOp,
                    Description = "A game about orchestrating a fireworks display together with the other players.",
                    MinPlayers = 2,
                    MaxPlayers = 5
                }
            };
            _BoardGameStorage = BoardGameStorage;
        }
        public BoardGame addBoardGame(BoardGame boardGame)
        {
            int id = _BoardGameStorage.Max(b => b.Id)+1;
            boardGame.Id = id;
            _BoardGameStorage.Add(boardGame);
            return boardGame;
        }

        public BoardGame get(int id)
        {
            return _BoardGameStorage.FirstOrDefault(b => b.Id==id);
        }

        public IEnumerable<BoardGame> getAll()
        {
            return _BoardGameStorage.OrderBy(b => b.Name);
        }
    }
}
