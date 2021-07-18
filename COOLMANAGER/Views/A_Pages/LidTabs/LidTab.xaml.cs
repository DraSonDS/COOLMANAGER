using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using COOLMANAGER.Views.A_Pages.GroupTabs;
using COOLMANAGER.Views.A_Pages.LidTabs;
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

namespace COOLMANAGER.Views.A_Pages.LidPage
{
    /// <summary>
    /// Interaction logic for LidTab.xaml
    /// </summary>
    public partial class LidTab : UserControl
    {
        DB db = new DB();
        List<Student> lids;
        string lidName;
        public LidTab()
        {
            InitializeComponent();
            FillLidDG();
        }

        private void LidAddB_Click(object sender, RoutedEventArgs e)
        {
            LidAddForm LidAdd = new LidAddForm(this);
            LidAdd.ShowDialog();
        }

        public void FillLidDG()
        {
            //Создаю лист с информацией об учениках в окне студентов
            StudentViewModel LidData = new StudentViewModel();
            lids = LidData.fillStudentGrid();

            var selectedLids = from student in lids
                               where student.is_student == 0
                               select student;
            
            LidDG.ItemsSource = selectedLids;
        }
        int selectedStudent;
        private void LidEditB_Click(object sender, RoutedEventArgs e)
        {
            selectedStudent = Convert.ToInt32(((sender as Button).DataContext as Student).id_student);
           
            LidAddForm LidAdd = new LidAddForm(this, selectedStudent);
            LidAdd.Closed += (obj, args) => FillLidDG();
            LidAdd.ShowDialog();
        }

        private void AddToGroupB_Click(object sender, RoutedEventArgs e)
        {
            selectedStudent = Convert.ToInt32(((sender as Button).DataContext as Student).id_student);
            LidAddToGroup lidAddToGroup = new LidAddToGroup(selectedStudent);
            lidAddToGroup.Closed += (obj, args) => FillLidDG();
            lidAddToGroup.ShowDialog();


        }
        private void LidDeleteB_Click(object sender, RoutedEventArgs e)
        {
            selectedStudent = Convert.ToInt32(((sender as Button).DataContext as Student).id_student);
           
            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы действительно хотите удалить лида?", "Удалить", btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MySqlCommand command = new MySqlCommand("DELETE FROM `students` WHERE `students`.`id_student` = "+ selectedStudent + "", db.getConnection());
                    db.openConnection();
                    if(command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Лид успешно удалён");
                        FillLidDG();
                    }
                    db.closeConnection();
                    break;

                case MessageBoxResult.No:
                    db.closeConnection();
                    break;
            }
        }

        private void LidSearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LidSearchTB.Text == "Имя, фамилия, отчество")
            {
                LidSearchTB.Text = "";
            }
        }

        private void LidSearchTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LidSearchTB.Text == "")
            {
                LidSearchTB.Text = "Имя, фамилия, отчество";
            }
        }

        private void LidSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LidSearchTB.Text == "Имя, фамилия, отчество")
            {
                lidName = "";
            }
            else
            {
                lidName = LidSearchTB.Text;
                Filtring(lidName);
            }
        }
        private void Filtring(string value)
        {
            var search = lids.Where(x => (x.is_student == 0) && ((x.name.ToLower().StartsWith(value.ToLower()) || x.surname.ToLower().StartsWith(value.ToLower()) ||
            x.lastname.ToLower().StartsWith(value.ToLower()))));

            LidDG.ItemsSource = search;
        }
    }
}
