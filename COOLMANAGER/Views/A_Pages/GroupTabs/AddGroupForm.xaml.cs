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
    /// Interaction logic for AddGroupForm.xaml
    /// </summary>
    public partial class AddGroupForm : Window
    {
        DB db = new DB();
        List<Subject> subjects = new List<Subject>();
        SubjectViewModel fsubjects = new SubjectViewModel();
        List<Teacher> teachers = new List<Teacher>();
        List<Subject_and_Teacher> subject_And_Teachers = new List<Subject_and_Teacher>();
        Subject selectedSubject;
        int groupID;
        bool registrate;

        public AddGroupForm()
        {
            InitializeComponent();
            WarningLabel.Visibility = Visibility.Hidden;
            subjects = fsubjects.fillSubject();
            subject.ItemsSource = subjects;
            Status.ItemsSource = new string[] {"Формирующаяся", "В работе"  };
            type.ItemsSource = new string[] {"Общий", "Online", "Спецкурс", "Восстановление" };
            registrate = true;
        }

        public AddGroupForm(int groupID)
        {
            InitializeComponent();
            WarningLabel.Visibility = Visibility.Hidden;
            subjects = fsubjects.fillSubject();
            subject.ItemsSource = subjects;
            Status.ItemsSource = new string[] {"Формирующаяся", "В работе"  };
            type.ItemsSource = new string[] {"Общий", "Online", "Спецкурс", "Восстановление" };
            this.groupID = groupID;
            registrate = false;

            MainLabel.Text = "Редактирование группы";
            SRegistrateB.Content = "Редактировать";
            SRegistrateB.Width = 120;

            foreach (DataRow row in db.commandTable("SELECT * FROM groups as g " +
                "JOIN teachers as t on g.id_teacher = t.id_teacher " +
                "JOIN users as u ON t.id_user = u.id_user " +
                "JOIN subjects as s ON g.name_subject = s.name_subject " +
                "WHERE id_group = " + groupID + "").Rows)
            {
                group_name.Text = Convert.ToString(row["group_name"]);

                var subjectSearch = from s in subjects
                                    where s.name_subject == Convert.ToString(row["name_subject"])
                                    select s;

                foreach(Subject s in subjectSearch)
                {
                    subject.SelectedItem = s ;
                }

                //subject.SelectedItem = Convert.ToString(row["name_subject"]);
                Status.SelectedItem = Convert.ToString(row["status"]);
                type.SelectedItem = Convert.ToString(row["type"]);
                fillTeacherCB(Convert.ToInt32(row["id_subject"]));
                teacher.SelectedItem = Convert.ToString(row["surname"] + " " + row["name"]);
            }
        }

        private void group_name_GotFocus(object sender, RoutedEventArgs e)
        {
            if(group_name.Text == "Название группы")
            {
                group_name.Text = "";
            }
        }

        private void group_name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (group_name.Text == "")
            {
                group_name.Text = "Название группы";
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GRegistrateB_Click(object sender, RoutedEventArgs e)
        {
            if (registrate)
                Reg();
            else
                Edit();


        }

        void Reg()
        {
            WarningLabel.Visibility = Visibility.Hidden;

            if (group_name.Text == "Название группы" || subject.SelectedItem.ToString() is null || Status.SelectedItem.ToString() is null || type.SelectedItem.ToString() is null)
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            string value = (string)(teacher.SelectedValue);  
            string[] words = value.Split(' ');

            string teacher_surname = words[0];
            string teacher_name = words[1];


            MySqlCommand command = new MySqlCommand("INSERT INTO `groups` (`group_name`, `name_subject`, `status`, `type`, `id_teacher`) " +
               "VALUES (@group_name, @name_subject, @status, @type, @id_teacher)", db.getConnection());
            command.Parameters.Add("@group_name", MySqlDbType.VarChar).Value = group_name.Text;

            Subject selectedItem = (Subject)(subject.SelectedValue);
            string sbj = (string)(selectedItem.name_subject);

            command.Parameters.Add("@name_subject", MySqlDbType.VarChar).Value = sbj;


            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = Status.SelectedItem.ToString();
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type.SelectedItem.ToString();

            // taking teacher id
            MySqlCommand command1 = new MySqlCommand("SELECT `id_teacher` FROM `teachers` " +
                "JOIN `users` ON users.id_user = teachers.id_user " +
                "WHERE users.name = '" + teacher_name + "' AND users.surname = '" + teacher_surname + "'", db.getConnection());
            db.openConnection();
            int teacher_id = Convert.ToInt32(command1.ExecuteScalar());
            db.closeConnection();

            command.Parameters.Add("@id_teacher", MySqlDbType.Int32).Value = teacher_id;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Группа успешно добавлена");
                db.closeConnection();
                this.Close();
            }
        }

        void Edit()
        {
            WarningLabel.Visibility = Visibility.Hidden;

            if (group_name.Text == "Название группы" || subject.SelectedItem.ToString() is null || Status.SelectedItem.ToString() is null || type.SelectedItem.ToString() is null)
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            string value = (string)(teacher.SelectedValue);
            string[] words = value.Split(' ');

            string teacher_surname = words[0];
            string teacher_name = words[1];

            MySqlCommand command = new MySqlCommand("UPDATE `groups` SET " +
                "`group_name` = @group_name, " +
                "`name_subject` = @name_subject, " +
                "`status` = @status, " +
                "`type` = @type, " +
                "`id_teacher` = @id_teacher " +
                "WHERE `groups`.`id_group` = " + groupID +" ", db.getConnection());
            command.Parameters.Add("@group_name", MySqlDbType.VarChar).Value = group_name.Text;
            
            Subject selectedItem = (Subject)(subject.SelectedValue);
            string sbj = (string)(selectedItem.name_subject);

            command.Parameters.Add("@name_subject", MySqlDbType.VarChar).Value = sbj;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = Status.SelectedItem.ToString();
            command.Parameters.Add("@type", MySqlDbType.VarChar).Value = type.SelectedItem.ToString();

            // taking teacher id
            MySqlCommand command1 = new MySqlCommand("SELECT `id_teacher` FROM `teachers` " +
                "JOIN `users` ON users.id_user = teachers.id_user " +
                "WHERE users.name = '" + teacher_name + "' AND users.surname = '" + teacher_surname + "'", db.getConnection());
            db.openConnection();
            int teacher_id = Convert.ToInt32(command1.ExecuteScalar());
            db.closeConnection();

            command.Parameters.Add("@id_teacher", MySqlDbType.Int32).Value = teacher_id;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Информация о группе изменена");
                db.closeConnection();
                this.Close();
            }
        }



        private void subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teacher.Items.Clear();
            selectedSubject = (Subject)subject.SelectedItem;
            int subjectID = selectedSubject.id_subject;
            fillTeacherCB(subjectID);
        }

        void fillTeacherCB(int subjectID)
        {
            teacher.Items.Clear();
            foreach (DataRow row in db.commandTable("SELECT * FROM teachers as t " +
               "JOIN users as u ON t.id_user = u.id_user " +
               "JOIN subjects_and_teachers as s_t ON t.id_teacher = s_t.id_teacher " +
               "WHERE s_t.id_subject = "+ subjectID + "").Rows )
            {
                teacher.Items.Add(Convert.ToString(row["surname"] + " " + row["name"]));
            }
        }
    }
}
