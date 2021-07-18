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

namespace COOLMANAGER.Views.A_Pages.FinanceTabs
{
    /// <summary>
    /// Interaction logic for AddPurse.xaml
    /// </summary>
    public partial class AddPurse : Window
    {
        DB db = new DB();
        List<Student> students = new List<Student>();
        List<Group> groups = new List<Group>();
        List<Groups_and_Students> groups_and_students = new List<Groups_and_Students>();
        GroupViewModel groupViewModel = new GroupViewModel();
        StudentViewModel studentViewModel = new StudentViewModel();
        Student selectedPerson;
        string groupName;
        int studentPurseID;
        int id_student;
        int id_group;

        bool register;

        public AddPurse()
        {
            InitializeComponent();
            students = studentViewModel.fillStudentGrid();
            groups = groupViewModel.fillGroupGrid();
            groups_and_students = groupViewModel.fillGRoup_and_student();
            studentCB.ItemsSource = students;
            WarningLabel.Visibility = Visibility.Hidden;
            register = true;
        }
        public AddPurse(int studentPurseID)
        {
            InitializeComponent();
            students = studentViewModel.fillStudentGrid();
            groups = groupViewModel.fillGroupGrid();
            groups_and_students = groupViewModel.fillGRoup_and_student();
            studentCB.ItemsSource = students;
            WarningLabel.Visibility = Visibility.Hidden;
            register = false;
            this.studentPurseID = studentPurseID;
            MainLabel.Text = "Редактирование платежа";
            SRegistrateB.Content = "Редактировать";
            SRegistrateB.Width = 120;

            foreach (DataRow row in db.commandTable("SELECT * FROM `student_purse` WHERE id_student_purse = "+ studentPurseID +"").Rows)
            {
                
                foreach (DataRow row1 in db.commandTable("SELECT *, s_p.id_student as id_student FROM `student_purse` as s_p " +
                    "WHERE id_student_purse = " + studentPurseID + "").Rows)
                {
                    id_student = Convert.ToInt32(row1["id_student"]); 
                    studentCB.SelectedItem = selectedST(id_student);

                    id_group = Convert.ToInt32(row1["id_group"]);
                    groupCB.SelectedItem = selectedGR(id_group);

                    summ.Text = Convert.ToString(row1["sum"]);
                }
            }
        }

        Student selectedST(int id)
        {
            var st = from s in students
                     where s.id_student == id
                     select s;

            Student st1 = new Student();

            foreach (Student s in st)
            {
                st1 = s;
            }
            return st1;
        }

        Group selectedGR(int id)
        {
            var st = from s in groups
                     where s.id_group == id
                     select s;

            Group st1 = new Group();

            foreach (Group s in st)
            {
                st1 = s;
            }
            return st1;
        }

        private void pRegistrateB_Click(object sender, RoutedEventArgs e)
        {
            if (register)
                reg();
            else
                edit();
        }

        void reg()
        {
            if (studentCB.SelectedValue is null || groupCB.SelectedValue is null ||
                summ.Text == "")
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO `student_purse` (`id_student`, `id_group`, `sum`, `date_of_receipt`) " +
               "VALUES (@id_student, @id_group, @sum, @date_of_receipt)", db.getConnection());


            selectedPerson = (Student)studentCB.SelectedItem;
            int studentID = selectedPerson.id_student;
            command.Parameters.Add("@id_student", MySqlDbType.Int32).Value = studentID;
            command.Parameters.Add("@id_group", MySqlDbType.Int32).Value = GroupID(groupName);
            command.Parameters.Add("@sum", MySqlDbType.Decimal).Value = summ.Text;
            command.Parameters.Add("@date_of_receipt", MySqlDbType.Date).Value = DateTime.Now;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Платёж добавлен");
                db.closeConnection();
                this.Close();
            }
        }

        void edit()
        {
            if (studentCB.SelectedValue is null || groupCB.SelectedValue is null ||
                summ.Text == "")
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            MySqlCommand command = new MySqlCommand("UPDATE `student_purse` SET " +
                "`id_student` = @id_student, " +
                "`id_group` = @id_group, " +
                "`sum` = @sum, " +
                "`date_of_receipt` = @date_of_receipt " +
                "WHERE `student_purse`.`id_student_purse` = " + studentPurseID + " ", db.getConnection());

            selectedPerson = (Student)studentCB.SelectedItem;
            int studentID = selectedPerson.id_student;
            command.Parameters.Add("@id_student", MySqlDbType.Int32).Value = studentID;
            command.Parameters.Add("@id_group", MySqlDbType.Int32).Value = GroupID(groupName);
            command.Parameters.Add("@sum", MySqlDbType.Decimal).Value = summ.Text;
            command.Parameters.Add("@date_of_receipt", MySqlDbType.Date).Value = DateTime.Now;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Информация о платеже изменена");
                db.closeConnection();
                this.Close();
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void fillGroupCB(int id_student)
        {
            var groupresult = from gr in groups
                         join g_s in groups_and_students on gr.id_group equals g_s.id_group
                         join s in students on g_s.id_student equals s.id_student
                         where s.id_student == id_student
                         select gr;

            groupCB.ItemsSource = groupresult;
            groupCB.DisplayMemberPath = "group_name";
            
        }

        private void studentCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            groupCB.ItemsSource = null;
            //groupCB.Items.Clear();

            selectedPerson = (Student)studentCB.SelectedItem;
            int studentID = selectedPerson.id_student;

            fillGroupCB(studentID);


            //fillGroupCB(int id_student)
        }

        private void summ_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        int GroupID(string group_name)
        {
            int grID = 0;
            var groupresult = from gr in groups
                              where gr.group_name == group_name
                              select gr;
            foreach (Group result in groupresult)
            {
                grID = result.id_group;
            }
            return grID;

        }
        private void groupCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(groupCB.Items.Count == 0)
            {
                return;
            }
            else
            groupName = ((Group)(groupCB.SelectedItem)).group_name.ToString();
        }
    }
}
