using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGameLogger.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        //public User Creator { get; set; }
        //public IEnumerable<User> Participants { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
