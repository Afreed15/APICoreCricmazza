using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CricMazaAPISerDb.Models
{
    public partial class Players
    {
        public Players()
        {
            PlayerProfile = new HashSet<PlayerProfile>();
        }

        public int Pid { get; set; }
        public string Tplayer { get; set; }
        public string Img { get; set; }
        public int? Tid { get; set; }

        public virtual Teams T { get; set; }
        public virtual ICollection<PlayerProfile> PlayerProfile { get; set; }
    }
}
