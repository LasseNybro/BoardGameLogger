using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoardGameLogger.Models
{
    public class SessionEdit
    {
        //public User Creator { get; set; }
        //public IEnumerable<User> Participants { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int BoardGame { get; set; }
    }
}
