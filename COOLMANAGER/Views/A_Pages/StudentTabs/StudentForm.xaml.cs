using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using COOLMANAGER.Views.T_Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COOLMANAGER.Views
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : UserControl
    {
        DB db = new DB();
        string StudName;
        List<Student> students;
        public StudentForm()
        {
            InitializeComponent();
            // Создаю лист с информацией об учениках в окне студентов
            fillSTGrid();
        }

         void fillSTGrid()
        {
            StudentViewModel StudentData = new StudentViewModel();
            students = StudentData.fillStudentGrid();
            StudentsDataGreed.ItemsSource = students;
        }

        private void StudentSearchNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StudentSearchNameTextBox.Text == "Имя, фамилия, отчество")
            {
                StudentSearchNameTextBox.Text = "";
            }
        }

        private void StudentSearchNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (StudentSearchNameTextBox.Text == "")
            {
                StudentSearchNameTextBox.Text = "Имя, фамилия, отчество";
            }
        }  
        private void StudentSearchNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //warningDataLabel.Visible = false;
            if (StudentSearchNameTextBox.Text == "Имя, фамилия, отчество")
            {
                StudName = "";
            }
            else
            {
                StudName = StudentSearchNameTextBox.Text;
                Filtring(StudName);
            }

        }

        private void StudentAddB_Click(object sender, RoutedEventArgs e)
        {
            StudentAddForm studentAdd = new StudentAddForm();
            studentAdd.Closed += (obj, args) => fillSTGrid();
            studentAdd.ShowDialog();
        }

        private void Filtring(string value)
        {
            var search = students.Where(x => (x.is_student == 1) && ((x.name.ToLower().StartsWith(value.ToLower()) || x.surname.ToLower().StartsWith(value.ToLower()) ||
            x.lastname.ToLower().StartsWith(value.ToLower()))));

            StudentsDataGreed.ItemsSource = search;
        }
        int selectedStudent;
        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            selectedStudent = Convert.ToInt32(((sender as Button).DataContext as Student).id_student);
            StudentAddForm studentAddE = new StudentAddForm(selectedStudent);
            studentAddE.Closed += (obj, args) => fillSTGrid();
            studentAddE.ShowDialog();
        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
            selectedStudent = Convert.ToInt32(((sender as Button).DataContext as Student).id_student);
            
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы действительно хотите удалить ученика?", "Удалить", btnMessageBox, icnMessageBox);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MySqlCommand command = new MySqlCommand("DELETE FROM `students` WHERE `students`.`id_student` = " + selectedStudent + "", db.getConnection());
                    db.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Ученик успешно удалён");
                        db.closeConnection();
                    }
                    fillSTGrid();
                    break;

                case MessageBoxResult.No:
                    db.closeConnection();
                    break;
            }
        }
    }
}
    