using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CricMazaAPISerDb.Models
{
    public partial class PointsTable
    {
        public int Ptid { get; set; }
        public int? Tid { get; set; }
        public int Played { get; set; }
        public double NetRate { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }
        public int Points { get; set; }

        public virtual Teams T { get; set; }
    }
}
