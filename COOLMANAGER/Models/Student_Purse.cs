using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
    public class Student_Purse
    {
        public int id_student_purse { get; set; }
        public int id_student { get; set; }
        public int id_group { get; set; }
        public decimal sum { get; set; }
        public string date_of_receipt { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastname { get; set; }

        public string student_fullname {
            get
            {
                return surname + " " + name + "\n" + lastname;
            }
            }
        public string group_name { get; set; }
        public decimal debt { get; set; }
        public string Summ 
        { 
            get
            {
                return sum + " ₽";
            } 
        }
        public string Comment 
        { 
            get
            {
                return "Оплата за группу\n"  + "\"" + group_name + "\"";
            } 
        }

        public string Debt
        {
            get { return debt + " ₽"; }
            set
            {
                debt = Convert.ToDecimal(value);
            }
           
        }


    }

}
