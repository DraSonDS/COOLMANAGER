using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
    class User
    {
        public int id_user { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int id_post { get; set; }
    }
}
