using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using COOLMANAGER.Views.A_Pages.GroupTabs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using MySql.Data.MySqlClient;

namespace COOLMANAGER.Views
{
    /// <summary>
    /// Interaction logic for GroupForm.xaml
    /// </summary>
    public partial class GroupForm : UserControl
    {
        List<Group> groups;
        List<Teacher> teachers;
        string groupName;
        MainForm parent;
        DB db = new DB();
        public GroupForm(MainForm parent)
        {
            InitializeComponent();
            //FillGroupDataGrid();
            // Создаю лист с информацией об учениках в окне студентов
            fillGroupDG();
            this.parent = parent;

        }

        void fillGroupDG()
        {
            GroupViewModel GroupData = new GroupViewModel();
            groups = GroupData.fillGroupGrid();
            GroupDataGrid.ItemsSource = groups;
        }

        private void GroupDataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void GroupDataGridCell_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataGridCell).Column.Header.ToString() == "Группа")
            {
                //give groupName to GroupEditFrom   
                GroupEditForms.GroupDetailForm groupDetailForm = new GroupEditForms.GroupDetailForm(((sender as DataGridCell).DataContext as Group).group_name);
                parent.ContPlace.Content = groupDetailForm;
            }
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddGroupForm addGroupForm = new AddGroupForm();
            addGroupForm.Closed += (obj, args) => fillGroupDG();
            addGroupForm.ShowDialog();
        }

        private void GroupSearchNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GroupSearchNameTextBox.Text == "Наименование")
            {
                GroupSearchNameTextBox.Text = "";
            }
        }

        private void GroupSearchNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GroupSearchNameTextBox.Text == "")
            {
                GroupSearchNameTextBox.Text = "Наименование";
            }
        }

        private void GroupSearchNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GroupSearchNameTextBox.Text == "Наименование")
            {
                groupName = "";
            }
            else
            {
                groupName = GroupSearchNameTextBox.Text;
                Filtring(groupName);
            }
        }
        private void Filtring(string value)
        {    

            var search = groups.Where(x => x.group_name.ToLower().StartsWith(value.ToLower()));

            GroupDataGrid.ItemsSource = search;
        }

        int selectedGroup;

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            selectedGroup = Convert.ToInt32(((sender as Button).DataContext as Group).id_group);

            AddGroupForm addGroupForm = new AddGroupForm(selectedGroup);
            addGroupForm.Closed += (obj, args) => fillGroupDG();
            addGroupForm.ShowDialog();
        }

        private void DeleteB_Click(object sender, RoutedEventArgs e)
        {
            selectedGroup = Convert.ToInt32(((sender as Button).DataContext as Group).id_group);

            MessageBox.Show(selectedGroup.ToString());

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Вы действительно хотите удалить преподавателя?", "Удалить", btnMessageBox, icnMessageBox);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    MySqlCommand command = new MySqlCommand("DELETE FROM `groups` WHERE `groups`.`id_group` = " + selectedGroup + "", db.getConnection());
                    db.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Группа успешно удалена");
                        db.closeConnection();
                    }
                    fillGroupDG();
                    break;

                case MessageBoxResult.No:
                    db.closeConnection();
                    break;
            }
        }
    }
}
