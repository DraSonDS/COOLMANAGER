using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
   public class StudentViewModel
    {
        List<Student> students = new List<Student>();
        DB StudentDB = new DB();

        public List<Student> fillStudentGrid()
        {
            foreach (DataRow row in StudentDB.commandTable("SELECT st.id_student, st.name,st.surname, st.lastname, st.birth_date, st.reg_date, st.advert_type, st.request_type, st.is_student, c.phone_number, c.email, comm.text, GROUP_CONCAT(gr.group_name SEPARATOR '\n') AS subjects " +
                "FROM students AS st " +
                "LEFT JOIN groups_and_students AS g_s ON st.id_student = g_s.id_student " +
                "LEFT JOIN groups AS gr ON g_s.id_group = gr.id_group " +
                "LEFT JOIN contacts AS c ON st.id_student = c.id_student " +
                "LEFT JOIN comment AS comm ON st.id_student = comm.id_student " +
                "GROUP BY st.id_student, st.name,st.surname, st.lastname, st.birth_date, st.reg_date, st.advert_type, st.request_type, st.is_student, c.phone_number, c.email, comm.text").Rows)
            {
                students.Add(new Student()
                {
                    id_student = Convert.ToInt32(string.Format("{0}", row.ItemArray[0])),
                    name = string.Format("{0}", row.ItemArray[1]),
                    surname = string.Format("{0}", row.ItemArray[2]),
                    lastname = string.Format("{0}", row.ItemArray[3]),
                    birth_date = string.Format("{0}", row.ItemArray[4]),
                    reg_date = string.Format("{0}", row.ItemArray[5]),
                    advert_type = string.Format("{0}", row.ItemArray[6]),
                    request_type = string.Format("{0}", row.ItemArray[7]),
                    StudentAge = string.Format("{0}", row.ItemArray[4]),
                    is_student = Convert.ToInt32(string.Format("{0}", row.ItemArray[8])),
                    phone_number = string.Format("{0}", row.ItemArray[9]),
                    email = string.Format("{0}", row.ItemArray[10]),
                    comment = string.Format("{0}", row.ItemArray[11]),
                    student_subjects = string.Format("{0}", row.ItemArray[12])
                });
            }
            return students;
        }
    }
}
