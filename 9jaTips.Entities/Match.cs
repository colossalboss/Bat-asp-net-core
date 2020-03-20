using System;
using System.ComponentModel.DataAnnotations;

namespace _9jaTips.Entities
{
    public class Match
    {
        public Match()
        {
        }

        public int MatchId { get; set; }

        [Required]
        public string League { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Home { get; set; }

        [Required]
        public string Away { get; set; }

        public string Result { get; set; }
    }
}
