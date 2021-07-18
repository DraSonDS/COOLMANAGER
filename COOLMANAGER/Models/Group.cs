using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
    public class Group
    {
        public int id_group { get; set; }
        public string group_name { get; set; }
        public string name_subject { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public int id_teacher { get; set; }
        public string teachers_name { get; set; }
        public string teachers_surname { get; set; }

       

        public string teachers_fullname
        {
            get { return $"{teachers_name} {teachers_surname}"; }
           
        }

    }
}
