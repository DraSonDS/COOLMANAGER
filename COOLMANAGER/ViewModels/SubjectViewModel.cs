using COOLMANAGER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLMANAGER.ViewModels
{
    class SubjectViewModel
    {
        List<Subject> subjects = new List<Subject>();
        DB db = new DB();

        public List<Subject> fillSubject()
        {
            foreach (DataRow row in db.commandTable("SELECT * FROM subjects").Rows)
            {
                subjects.Add(new Subject()
                {
                   id_subject = Convert.ToInt32(row["id_subject"]),
                   name_subject = Convert.ToString(row["name_subject"]),
                   price = Convert.ToDecimal(row["prise"])
                });
            }
            return subjects;
        }
    }
}
