using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CricMazaAPISerDb.Models
{
    public partial class Login
    {
        public int Lid { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string Lrole { get; set; }
    }
}
