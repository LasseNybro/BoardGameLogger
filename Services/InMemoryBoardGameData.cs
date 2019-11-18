using System.Collections.Generic;
using System.Linq;
using BoardGameLogger.Models;

namespace BoardGameLogger.Services
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
        public BoardGame CreateBoardGame(BoardGame boardGame)
        {
            int id = _BoardGameStorage.Max(b => b.Id)+1;
            boardGame.Id = id;
            _BoardGameStorage.Add(boardGame);
            return boardGame;
        }
        public BoardGame Get(int id)
        {
            return _BoardGameStorage.FirstOrDefault(b => b.Id==id);
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _BoardGameStorage.OrderBy(b => b.Name);
        }

        public IEnumerable<BoardGame> GetAllGenreName(GenreType genre, string name)
        {
            if(genre == GenreType.None && string.IsNullOrWhiteSpace(name))
            {
                return GetAll();
            }
            if (genre == GenreType.None)
            {
                return _BoardGameStorage.FindAll(b => b.Name == name).OrderBy(g => g.Name);
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                return _BoardGameStorage.FindAll(b => b.Genre == genre);
            }
            return _BoardGameStorage.FindAll(b => b.Name == name && b.Genre == genre).OrderBy(g => g.Name);
        }
        public BoardGame EditBoardGame(BoardGame boardGame)
        {
            BoardGame old = Get(boardGame.Id);
            old.Name = boardGame.Name;
            old.MinPlayers = boardGame.MinPlayers;
            old.MaxPlayers = boardGame.MaxPlayers;
            old.Genre = boardGame.Genre;
            old.Sessions = boardGame.Sessions;
            return old;
        }

        public void DeleteBoardGame(BoardGame boardGame)
        {
            throw new System.NotImplementedException();
        }
    }
}
