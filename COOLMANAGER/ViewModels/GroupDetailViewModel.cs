using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
   public class GroupDetailViewModel
    {
        Schedue schedue = new Schedue();
        Group group = new Group();
        List<Student> student = new List<Student>();
        DB Table = new DB();

        public Schedue fillSchedue(string grName)
        {
            foreach (DataRow row in Table.commandTable("SELECT sch.monday, sch.tuesday, sch.wednesday, sch.thursday, sch.friday, sch.saturday, sch.sunday, sch.time_start_lesstion, sch.time_end_lesstion " +
                "FROM schedule as sch JOIN groups as g ON sch.id_group = g.id_group " +
                "WHERE g.group_name = '" + grName + "'  ").Rows)
            {
                schedue.monday = Convert.ToInt32(string.Format("{0}", row.ItemArray[0]));
                schedue.tuesday = Convert.ToInt32(string.Format("{0}", row.ItemArray[1]));
                schedue.wednesday = Convert.ToInt32(string.Format("{0}", row.ItemArray[2]));
                schedue.thursday = Convert.ToInt32(string.Format("{0}", row.ItemArray[3]));
                schedue.friday = Convert.ToInt32(string.Format("{0}", row.ItemArray[4]));
                schedue.saturday = Convert.ToInt32(string.Format("{0}", row.ItemArray[5]));
                schedue.sunday = Convert.ToInt32(string.Format("{0}", row.ItemArray[6]));
                schedue.time_start_lession = Convert.ToDateTime(string.Format("{0}", row.ItemArray[7]));
                schedue.time_end_lession = Convert.ToDateTime(string.Format("{0}", row.ItemArray[8]));
            }
            return schedue;
        }

        public Group fillGroup(string grName)
        {
            foreach (DataRow row in Table.commandTable("SELECT u.name, u.surname, g.group_name, g.name_subject, g.status, g.type, g.id_group FROM `groups` AS g " +
                "JOIN teachers AS t ON g.id_teacher = t.id_teacher " +
                "JOIN users as u ON t.id_user = u.id_user WHERE g.group_name = '" + grName + "'  ").Rows)
            {
                group.teachers_name = string.Format("{0}", row.ItemArray[0]);
                group.teachers_surname = string.Format("{0}", row.ItemArray[1]);
                group.group_name = string.Format("{0}", row.ItemArray[2]);
                group.name_subject = string.Format("{0}", row.ItemArray[3]);
                group.status = string.Format("{0}", row.ItemArray[4]);
                group.type = string.Format("{0}", row.ItemArray[5]);
                group.id_group = Convert.ToInt32(string.Format("{0}", row.ItemArray[6])); 

            }
                return group;
        }

        public List<Student> fillStudents_in_group(string grName)
        {
            foreach (DataRow row in Table.commandTable("SELECT st.id_student, st.name,st.surname, st.lastname, st.birth_date, st.reg_date, st.advert_type, st.request_type, " +
                "GROUP_CONCAT(gr.group_name SEPARATOR '\n') AS subjects FROM students AS st " +
                "LEFT JOIN groups_and_students AS g_s ON st.id_student = g_s.id_student " +
                "LEFT JOIN groups AS gr ON g_s.id_group = gr.id_group " +
                "WHERE gr.group_name = '"+ grName + "' " +
                "GROUP BY st.id_student, st.name,st.surname, st.lastname, st.birth_date, st.reg_date, st.advert_type, st.request_type ").Rows)
            {
                student.Add(new Student()
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
                    student_subjects = string.Format("{0}", row.ItemArray[8])
                });
            }
            return student;
        }
        
    }
}
