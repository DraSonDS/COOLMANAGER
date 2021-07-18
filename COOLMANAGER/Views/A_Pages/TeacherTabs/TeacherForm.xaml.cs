using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using COOLMANAGER.Views.A_Pages.TeacherTabs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COOLMANAGER.Views
{
    /// <summary>
    /// Interaction logic for TeacherForm.xaml
    /// </summary>
    public partial class TeacherForm : UserControl
    {
        List<Teacher> teachers;
        string TeacherName;
        DB db = new DB();
        public TeacherForm()
        {
            InitializeComponent();
            fillT();
        }
        void fillT()
        {
            TeacherViewModel teahersData = new TeacherViewModel();
            teachers = teahersData.fillTeacherGrid();
            TeachersDataGrid.ItemsSource = teachers;
        } 
       

        private void AddTeacherB_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            addTeacherForm.Closed += (obj, args) => fillT();
            addTeacherForm.ShowDialog();

        }

        private void TeacherSearchNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TeacherSearchNameTextBox.Text == "Имя, фамилия, отчество")
            {
                TeacherSearchNameTextBox.Text = "";
            }
        }

        private void TeacherSearchNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TeacherSearchNameTextBox.Text == "")
            {
                TeacherSearchNameTextBox.Text = "Имя, фамилия, отчество";
            }
        }

        private void TeacherSearchNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TeacherSearchNameTextBox.Text == "Имя, фамилия, отчество")
            {
                TeacherName = "";
            }
            else
            {
                TeacherName = TeacherSearchNameTextBox.Text;
                Filtring(TeacherName);
            }
        }
        private void Filtring(string value)
        {
            var search = teachers.Where(x => (x.teacher_name.ToLower().StartsWith(value.ToLower()) || x.teacher_surname.ToLower().StartsWith(value.ToLower())));

            TeachersDataGrid.ItemsSource = search;
        }

        int selectedTeacher;
        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            selectedTeacher = Convert.ToInt32(((sender as Button).DataContext as Teacher).id_teacher);
            AddTeacherForm addTeacherForm = new AddTeacherForm(selectedTeacher);
            addTeacherForm.Closed += (obj, args) => fillT();
            addTeacherForm.ShowDialog();
        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
            selectedTeacher = Convert.ToInt32(((sender as Button).DataContext as Teacher).id_teacher);    

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы действительно хотите удалить преподавателя?", "Удалить", btnMessageBox, icnMessageBox);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MySqlCommand command = new MySqlCommand("DELETE FROM `teachers` WHERE `teachers`.`id_teacher` = " + selectedTeacher + "", db.getConnection());
                    db.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Преподаватель успешно удалён");
                        db.closeConnection();
                    }
                    fillT();
                    break;

                case MessageBoxResult.No:
                    db.closeConnection();
                    break;
            }
        }
    }
}
