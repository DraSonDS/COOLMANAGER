using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using COOLMANAGER.Views.A_Pages.FinanceTabs;
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

namespace COOLMANAGER.Views.A_Pages.FInanceTabs
{
    /// <summary>
    /// Interaction logic for FinanceTab.xaml
    /// </summary>
    public partial class FinanceTab : UserControl
    {
        string studentName;
        DB db = new DB();
        List<Student_Purse> finanseDGSource;
        public FinanceTab()
        {
            InitializeComponent();
            fillDG();
        }

        void fillDG()
        {
            Student_PurseViewModel student_purse = new Student_PurseViewModel();
            finanseDGSource = student_purse.fillStudentPurse();
            PurseDG.ItemsSource = finanseDGSource;
        }

        private void addFin_Click(object sender, RoutedEventArgs e)
        {
            AddPurse addPurse = new AddPurse();
            addPurse.Closed += (obj, args) => fillDG();
            addPurse.ShowDialog();
        }

        private void PurseSearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PurseSearchTB.Text == "Имя, фамилия, отчество")
            {
                PurseSearchTB.Text = "";
            }
        }

        private void PurseSearchTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PurseSearchTB.Text == "")
            {
                PurseSearchTB.Text = "Имя, фамилия, отчество";
            }
        }

        private void PurseSearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PurseSearchTB.Text == "Имя, фамилия, отчество")
            {
                studentName = "";
            }
            else
            {
                studentName = PurseSearchTB.Text;
                Filtring(studentName);
            }
        }
        private void Filtring(string value)
        {
            var search = finanseDGSource.Where(x => (x.name.ToLower().StartsWith(value.ToLower()) || x.surname.ToLower().StartsWith(value.ToLower())));

            PurseDG.ItemsSource = search;
        }
        int selectedPurse;
      
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            selectedPurse = Convert.ToInt32(((sender as Button).DataContext as Student_Purse).id_student_purse);
            

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы действительно хотите удалить платёж?", "Удалить", btnMessageBox, icnMessageBox);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MySqlCommand command = new MySqlCommand("DELETE FROM `student_purse` WHERE `student_purse`.`id_student_purse` = " + selectedPurse +"", db.getConnection());
                    db.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Платёж успешно удалён");
                        db.closeConnection();
                    }
                    fillDG();
                    break;

                case MessageBoxResult.No:
                    db.closeConnection();
                    break;
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            selectedPurse = Convert.ToInt32(((sender as Button).DataContext as Student_Purse).id_student_purse);

            AddPurse addPurse = new AddPurse(selectedPurse);
            addPurse.Closed += (obj, args) => fillDG();
            addPurse.ShowDialog();

        }
    }
}
