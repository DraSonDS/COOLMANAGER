using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.Models
{
   public class Teacher
    {
        public int id_teacher { get; set; }

        private string _date_of_registration;
        public string date_of_registration 
        {
            get
            {
                int years = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(_date_of_registration)).TotalDays);
                years = Convert.ToInt32(years / 365);

                string years_experience;

                string date_of_registration = Convert.ToDateTime(_date_of_registration).ToString("dd.MM.yyyy");

                years_experience = $"{years} лет \n({date_of_registration})";

                return years_experience;
            }

            set
            {
                _date_of_registration = value;
            }
        }
        public int id_user { get; set; }
        public string teacher_name{ get; set; }
        public string teacher_surname{ get; set; }
        public string teacher_lastname{ get; set; }
        public string teacher_subjects{ get; set; }

        

        public string FullName
        {
            get
            {
                return $"{teacher_name} {teacher_surname}";
            } 
        }

        //public string experience
        //{
        //    get
        //    {
        //        int years = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(date_of_registration)).TotalDays);
        //        years = Convert.ToInt32(years / 365);

        //        string years_experience;

        //       string date_of_registration = Convert.ToDateTime(date_of_registration).ToString("dd.MM.yyyy");

        //        years_experience = $"{years} лет \n({date_of_registration})";

        //        return years_experience;
        //    } 
        //}

    }
}
