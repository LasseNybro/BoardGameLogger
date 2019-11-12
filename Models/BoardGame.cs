using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameLogger.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public GenreType Genre { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
    }
}
