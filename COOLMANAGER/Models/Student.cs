using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
    public class Student
    {
        public int id_student { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastname { get; set; }
        public string birth_date { get; set; }
        public string reg_date { get; set; }
        public string advert_type { get; set; }
        public string request_type { get; set; }
        public string student_subjects { get; set; }
        public int is_student { get; set; }
        public string phone_number;
        public string email { get; set; }
        public string comment {get; set; }

        public string contact
        {
            get { 
                if(phone_number == "")
                {
                    return "";
                }
                else
                {
                    return "+"+phone_number+"\n" + email;
                }  
            }
        }
        private string _studentAge;
        public string StudentAge
        {
            get
            {
                string age;
                if (_studentAge == "")
                {
                    age = "Не определенно";
                    return age;
                }
                else
                {
                     int years = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(_studentAge)).TotalDays);
                     years = Convert.ToInt32(years / 365);
                     if (years < 0)
                         age = "Ученик родится\nв будущем";
                     else
                     {
                         _studentAge = Convert.ToDateTime(_studentAge).ToString("dd.MM.yyyy");

                         age = $"{years} лет \n({_studentAge})";
                     }
                     return age;
                }
                
            }
            set { _studentAge = value; }
        }

        public string FullName
        {
            get
            {
                return $"{ surname } { name }\n{ lastname }";
            }
        }

        public string Date_and_advert_Type
        {
            get 
            {
                reg_date = Convert.ToDateTime(reg_date).ToString("dd.MM.yyyy");
                if (advert_type =="")
                {
                    return $"{reg_date} \n(не определенно)";
                }
                else
                {
                    return $"{reg_date} \n({advert_type})"; 
                }
                
            }
        }
        public string Initials
        {
            get
            {
                if(lastname == "")
                {
                    return name.Substring(0, 1) + ". " + 
                    surname;
                }
                else
                {
                    return name.Substring(0, 1) + ". " +
                    lastname.Substring(0, 1) + ". " +
                    surname;
                }
               
            }
        }

    }
}
