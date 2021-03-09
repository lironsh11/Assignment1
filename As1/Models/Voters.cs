using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As1.Models
{
    public class Voters
    {
        public int ID { get; set; }
        public string Tz { get; set; }

        public string Name { get; set; }
   
        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string City { get; set; }

        public DateTime IdExpDate { get; set; }
    }
}


