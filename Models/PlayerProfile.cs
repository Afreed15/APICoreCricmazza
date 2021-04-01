using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CricMazaAPISerDb.Models
{
    public partial class PlayerProfile
    {
        public int Profileid { get; set; }
        public string Country { get; set; }
        public int HighestScore { get; set; }
        public string Role { get; set; }
        public string BestBowling { get; set; }
        public int? Tid { get; set; }
        public int? Pid { get; set; }

        public virtual Players P { get; set; }
        public virtual Teams T { get; set; }
    }
}
