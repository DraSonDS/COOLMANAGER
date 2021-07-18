using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace COOLMANAGER.Views.A_Pages.GroupTabs
{
    /// <summary>
    /// Interaction logic for AddStudentToGroupForm.xaml
    /// </summary>
    public partial class AddStudentToGroupForm : Window
    {
        DB db = new DB();
        DataTable table;
        MySqlDataAdapter adapter;
        string groupName;
        List<Student> students;
        List<Student> studentsNotInGroup = new List<Student>();
        List<Student> studentsAtGroup = new List<Student>();
        List<Groups_and_Students> groups_And_Students;
        StudentViewModel Student = new StudentViewModel();
        GroupViewModel GroupViewModel = new GroupViewModel();
        int groupID;

        public AddStudentToGroupForm(int groupID)
        {
            InitializeComponent();
            students = Student.fillStudentGrid();
            groups_And_Students = GroupViewModel.fillGRoup_and_student();
            this.groupID = groupID;
            FillLists();
        }

        void FillLists()
        {
            //add students into listbox
            table = new DataTable();
            adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand
                ("SELECT *, students.id_student as id_student " +
                "FROM `students` " +
                    "LEFT JOIN groups_and_students ON students.id_student = groups_and_students.id_student " +
                        "AND groups_and_students.id_group = " + groupID + " " +
                "WHERE groups_and_students.id_group IS NULL", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                studentsNotInGroup.Add(new Student()
                {
                    id_student = Convert.ToInt32(row["id_student"]),
                    name = Convert.ToString(row["name"]),
                    surname = Convert.ToString(row["surname"]),
                    lastname = Convert.ToString(row["lastname"]),
                });


                LeftListBox.ItemsSource = studentsNotInGroup;
                LeftListBox.DisplayMemberPath = "Initials";

                RightListBox.DisplayMemberPath = "Initials";

            }

        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        private void ApplyDataBinding()
        {
            LeftListBox.ItemsSource = null;
            RightListBox.ItemsSource = null;
            LeftListBox.ItemsSource = studentsNotInGroup;
            RightListBox.ItemsSource = studentsAtGroup; 
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListBox.SelectedItem is null)
            {
                return;
            }
            else
            {


                Student s = LeftListBox.SelectedItem as Student;
                studentsNotInGroup.Remove(s);
                studentsAtGroup.Add(s);
                ApplyDataBinding();
            }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            if (RightListBox.SelectedItem is null)
            {
                return;
            }
            else
            {
                Student s = RightListBox.SelectedItem as Student;
                studentsAtGroup.Remove(s);
                studentsNotInGroup.Add(s);
                ApplyDataBinding();
            }
        }

        private void SRegistrateB_Click(object sender, RoutedEventArgs e)
        {
            foreach(Student s in studentsAtGroup)
            {
                MySqlCommand command = new MySqlCommand(" " +
                    "INSERT INTO `groups_and_students` (`id_student`, `id_group`, `date_of_enrollment`) " +
                    "VALUES ("+ s.id_student+", "+ groupID + ", @reg_date)", db.getConnection());
                command.Parameters.Add("@reg_date", MySqlDbType.Date).Value = DateTime.Now;
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Ученики добавлены в группу.");
                this.Close();
            }
        }
    }
}
