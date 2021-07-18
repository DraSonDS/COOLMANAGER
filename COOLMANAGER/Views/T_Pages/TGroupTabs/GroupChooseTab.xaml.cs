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

namespace COOLMANAGER.Views.T_Pages.TGroupTabs
{
    /// <summary>
    /// Interaction logic for GroupChooseTab.xaml
    /// </summary>
    public partial class GroupChooseTab : UserControl
    {
        DB db = new DB();
        int TeacherID;
        int UserID;
        TMainForm parentWindow;
        public GroupChooseTab(int TeacherId, TMainForm parentWindow)
        {
            InitializeComponent();
            
            EmptyListMessage.Visibility = Visibility.Collapsed;
            this.UserID = TeacherId;
            this.parentWindow = parentWindow;
            fillGroups();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            string grName = ((sender as Button).Content as TextBlock).Text; ;
          
            MySqlCommand command = new MySqlCommand("SELECT id_group FROM groups WHERE group_name = '" + grName + "'", db.getConnection());
            db.openConnection();
            int GroupID = Convert.ToInt32(command.ExecuteScalar());
            db.closeConnection();
            TGroupTab groupTab = new TGroupTab(TeacherID, GroupID, parentWindow, UserID);
            
            parentWindow.TContentPlace.Content = groupTab;
        }

        void fillGroups()
        {
            string commandText = "SELECT * FROM groups AS g " +
                "JOIN teachers AS t ON g.id_teacher = t.id_teacher " +
                "JOIN users AS u ON t.id_user = u.id_user " +
                "WHERE u.id_user = " + UserID + "";
            if (db.commandTable(commandText).Rows.Count == 0)
            {
                EmptyListMessage.Visibility = Visibility.Visible;
            }
            else
            {
                foreach (DataRow rows in db.commandTable(commandText).Rows)
                {
                    var myBtn = new Button();
                    myBtn.Style = Application.Current.FindResource("GroupB") as Style;

                    TextBlock grname = new TextBlock();
                    grname.Text = Convert.ToString(rows["group_name"]);
                    grname.TextWrapping = TextWrapping.Wrap;
                    grname.FontWeight = FontWeights.SemiBold;
                    grname.HorizontalAlignment = HorizontalAlignment.Center;
                    grname.VerticalAlignment = VerticalAlignment.Center;

                    myBtn.Content = grname;
                    Thickness margin = myBtn.Margin;
                    myBtn.Click += myBtn_Click;
                    GroupList.Children.Add(myBtn);
                    TeacherID = Convert.ToInt32(rows["id_teacher"]);
                }
            }
        }
    }
}
