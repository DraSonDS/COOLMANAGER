using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
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

namespace COOLMANAGER.Views.A_Pages.LidTabs
{
    /// <summary>
    /// Interaction logic for LidAddToGroup.xaml
    /// </summary>
    public partial class LidAddToGroup : Window
    {
        DB db = new DB();
        List<Group> group = new List<Group>();
        Group gr = new Group();
        GroupViewModel groupViewModel = new GroupViewModel();
        int studentID;

        public LidAddToGroup(int StudentID)
        {
            InitializeComponent();
            this.studentID = StudentID;
            fillGropList();
        }

        private void SRegistrateB_Click(object sender, RoutedEventArgs e)
        {
            gr = GroupList.SelectedItem as Group;

            if(GroupList.SelectedItem is null)
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            else
            {
            MySqlCommand command = new MySqlCommand(" " +
                "INSERT INTO `groups_and_students` (`id_student`, `id_group`, `date_of_enrollment`) " +
                    "VALUES (" + studentID + ", " + gr.id_group + ", @reg_date);", db.getConnection());
            command.Parameters.Add("@reg_date", MySqlDbType.Date).Value = DateTime.Now;

                MySqlCommand command1 = new MySqlCommand(" " +
               "UPDATE `students` SET `is_student` = 1 WHERE `students`.`id_student` = "+ studentID + "", db.getConnection());

                db.openConnection();
                command.ExecuteNonQuery();
                command1.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show("Лид добавлен в группу.");
                this.Close();
            }

        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void fillGropList()
        {
            group = groupViewModel.fillGroupGrid();
            GroupList.ItemsSource = group;
            GroupList.DisplayMemberPath = "group_name";
        }
    }
}
