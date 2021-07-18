using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
    class Task
    {
        public int id_task { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string responsoble { get; set; }
        public string orderedBy { get; set; }
        public string proprity { get; set; }
        public string status { get; set; }
    }
}
