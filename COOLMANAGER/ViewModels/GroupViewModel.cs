using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
    public class GroupViewModel
    {
        List<Group> groups = new List<Group>();
        List<Groups_and_Students> groups_And_Students = new List<Groups_and_Students>();
        DB GroupDB = new DB();

        public List<Group> fillGroupGrid()
        {

            foreach (DataRow row in GroupDB.commandTable("SELECT * FROM groups as g JOIN teachers as t " +
                "ON g.id_teacher = t.id_teacher " +
                "JOIN users as u on t.id_user = u.id_user ").Rows)
            {
                groups.Add(new Group()
                {
                    id_group = Convert.ToInt32(string.Format("{0}", row.ItemArray[0])),
                    group_name = string.Format("{0}", row.ItemArray[1]),
                    name_subject = string.Format("{0}", row.ItemArray[2]),
                    status = string.Format("{0}", row.ItemArray[3]),
                    type = string.Format("{0}", row.ItemArray[4]),
                    id_teacher = Convert.ToInt32(string.Format("{0}", row.ItemArray[5])),
                    teachers_name = Convert.ToString(row["name"]),
                    teachers_surname = Convert.ToString(row["surname"])
                });
            }
            return groups;
        }
        public List<Groups_and_Students> fillGRoup_and_student()
        {
            foreach (DataRow row in GroupDB.commandTable("SELECT * FROM groups_and_students").Rows)
            {
                groups_And_Students.Add(new Groups_and_Students()
                    {
                        id_student = Convert.ToInt32(row["id_student"]),
                        id_group = Convert.ToInt32(row["id_group"]),
                        date_of_enrollment = Convert.ToString(row["date_of_enrollment"])
                    });
            }
            return groups_And_Students;
        }
    }
}
