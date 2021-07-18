using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace COOLMANAGER.Views.T_Pages.TGroupTabs
{
    /// <summary>
    /// Interaction logic for AddHomeWorkForm.xaml
    /// </summary>
    public partial class AddHomeWorkForm : Window
    {
        DB db = new DB();
        int GroupID;
        int TeacherID;
        TGroupTab parentTab;
        public AddHomeWorkForm(int GroupID, int TeacherID, TGroupTab parentTab)
        {
            InitializeComponent();
            completion_date.DisplayDateStart = DateTime.Now;
            this.GroupID = GroupID;
            this.TeacherID = TeacherID;
            this.parentTab = parentTab;
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTask.Text == "Название")
                NameTask.Text = "";
        }

        private void NameTask_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTask.Text == "")
                NameTask.Text = "Название";
        }

        private void DescriptionTask_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionTask.Text == "Описание")
                DescriptionTask.Text = "";
        }

        private void DescriptionTask_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionTask.Text == "")
                DescriptionTask.Text = "Описание";
        }
        private void HomeTaskAddB_Click(object sender, RoutedEventArgs e)
        {
            WarningLable.Opacity = .0;
            if (NameTask.Text == "Название" || DescriptionTask.Text == "Описание")
            {
                WarningLable.Opacity = .100;
            }
            MySqlCommand command = new MySqlCommand("INSERT INTO homework (id_group, id_teacher, date_of_assignment, date_of_completion, comment, task_label) " +
                "VALUES (@id_group, @id_teacher, @date_of_assignment,@date_of_completion, @comment, @task_label ) ", db.getConnection());
            command.Parameters.Add("@id_group", MySqlDbType.Int32).Value = GroupID;
            command.Parameters.Add("@id_teacher", MySqlDbType.Int32).Value = TeacherID;
            command.Parameters.Add("@date_of_assignment", MySqlDbType.Date).Value = DateTime.Now;
            command.Parameters.Add("@date_of_completion", MySqlDbType.Date).Value = completion_date.SelectedDate.Value.Date;
            command.Parameters.Add("@comment", MySqlDbType.VarChar).Value = DescriptionTask.Text;
            command.Parameters.Add("@task_label", MySqlDbType.VarChar).Value = NameTask.Text;

            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Задание добавлено");
                parentTab.fillTaskList();
                db.closeConnection();
                this.Hide();
            }
           
        }
    }
}
