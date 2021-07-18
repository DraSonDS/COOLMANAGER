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

namespace COOLMANAGER.Views.ST_Pages
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class GroupView : UserControl
    {
        DB db = new DB();
        public string StudentGoupId { get; set; }

        ST_StudentMainWindow parentWindow;

        public GroupView(ST_StudentMainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (DataRow rows in db.commandTable("SELECT * FROM groups_and_students AS g_s JOIN groups AS g ON g_s.id_group = g.id_group WHERE id_student = '" + this.StudentGoupId + "'").Rows)
            {

                TextBlock groupName = new TextBlock();
                groupName.Text = Convert.ToString(rows["group_name"]);
                groupName.TextWrapping = TextWrapping.Wrap;
                groupName.FontWeight = FontWeights.DemiBold;
                groupName.FontSize = 14;
                groupName.Foreground = new SolidColorBrush(Color.FromRgb(202, 210, 197));


                var myBtn = new Button();
                myBtn.Style = Application.Current.FindResource("GroupB") as Style;
                myBtn.Background = new SolidColorBrush(Color.FromRgb(47, 62, 70));
                myBtn.Content = groupName; 
                myBtn.Click += myBtn_Click;
                myWrapPanel.Children.Add(myBtn);

            }

        }

        private void myBtn_Click(object sender, RoutedEventArgs e)
        {
            GroupInsideView groupInsideView = new GroupInsideView(parentWindow);

            MySqlCommand command = new MySqlCommand("SELECT id_group FROM groups WHERE group_name = '" + ((sender as Button).Content as TextBlock).Text + "'", db.getConnection());

            db.openConnection();
            groupInsideView.GroupID = Convert.ToString(command.ExecuteScalar());
            db.closeConnection();
            groupInsideView.StudentID = this.StudentGoupId;
            groupInsideView.GroupName = ((sender as Button).Content as TextBlock).Text;

            parentWindow.ContentHolderFrame.Content = groupInsideView;
        } 
    }
}
