using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
   public class Student_PurseViewModel
    {
        List<Student_Purse> student_purses = new List<Student_Purse>();
        DB db = new DB();

        public List<Student_Purse> fillStudentPurse()
        {
            foreach (DataRow row in db.commandTable("SELECT *, s.id_student AS idstudent, g.group_name as groupName, s_p.id_group as idgroup FROM student_purse AS s_p " +
                "JOIN students AS s ON s_p.id_student = s.id_student " +
                "JOIN groups_and_students as g_s ON s_p.id_student = g_s.id_student " +
                "JOIN groups as g ON g_s.id_group = g.id_group " +
                "WHERE s_p.id_group = g.id_group ").Rows)
            {
                student_purses.Add(new Student_Purse()
                {
                    id_student_purse = Convert.ToInt32(row["id_student_purse"]),
                    id_student = Convert.ToInt32(row["idstudent"]),
                    id_group = Convert.ToInt32(row["idgroup"]),
                    sum = Convert.ToDecimal(row["sum"]),
                    date_of_receipt = Convert.ToDateTime(Convert.ToString(row["date_of_receipt"])).ToString("dd.MM.yyyy"),
                    name = Convert.ToString(row["name"]),
                    surname = Convert.ToString(row["surname"]),
                    lastname = Convert.ToString(row["lastname"]),
                    group_name = Convert.ToString(row["groupName"]) 
                });
            }
            return student_purses;
        }
    }
}
