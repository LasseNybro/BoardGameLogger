using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGameLogger.Models
{
    public class BoardGame
    {
        public BoardGame()
        {
            Sessions = new List<Session>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public GenreType Genre { get; set; }
        [Required]
        public int MinPlayers { get; set; }
        [Required]
        public int MaxPlayers { get; set; }
        //public String PictureLink { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public IEnumerable<Session> Sessions { get; set; }
    }
}
