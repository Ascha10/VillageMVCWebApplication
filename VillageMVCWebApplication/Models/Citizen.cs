using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillageMVCWebApplication.Models
{
    public class Citizen
    {
        public int CitizenId { get; set; }
        public string CitizenParent { get; set; }
        public string Gender { get; set; }
        public bool IsBornInVillage { get; set; }
        public DateTime Birthdate { get; set; }
    }
}