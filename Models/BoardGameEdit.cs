using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameLogger.Models
{
    public class BoardGameEdit
    {
        public String Name { get; set; }
        public GenreType Genre { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        //public String PictureLink { get; set; }
        public String Description { get; set; }
    }
}
