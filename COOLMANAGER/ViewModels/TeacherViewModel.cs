using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
   public class TeacherViewModel
    {
        List<Teacher> teachers = new List<Teacher>();
        DB TeacherDB = new DB();

        public List<Teacher> fillTeacherGrid()
        {

            foreach (DataRow row in TeacherDB.commandTable("SELECT t.id_teacher, t.date_of_registration, u.name, u.surname, GROUP_CONCAT(s.name_subject SEPARATOR '\n') FROM users as u JOIN teachers AS t ON u.id_user = t.id_user JOIN subjects_and_teachers AS s_t ON t.id_teacher = s_t.id_teacher JOIN subjects AS s ON s_t.id_subject = s.id_subject GROUP BY t.id_teacher, t.date_of_registration, u.name, u.surname").Rows)
            {
                teachers.Add(new Teacher()
                {
                    id_teacher = Convert.ToInt32(string.Format("{0}", row.ItemArray[0])),
                    date_of_registration = string.Format("{0}", row.ItemArray[1]),
                    teacher_name = string.Format("{0}", row.ItemArray[2]),
                    teacher_surname = string.Format("{0}", row.ItemArray[3]),
                    teacher_subjects = string.Format("{0}", row.ItemArray[4]),
                    
                });
            }
            return teachers;
        }
    }
}
