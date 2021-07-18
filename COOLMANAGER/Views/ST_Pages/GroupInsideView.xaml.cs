using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for GroupInsideView.xaml
    /// </summary>
    public partial class GroupInsideView : UserControl
    {
        DB db = new DB();
        
        public string GroupID { get; set; }
        public string StudentID { get; set; }
        public string GroupName { get; set; }
        ST_StudentMainWindow parentWindow;


        public GroupInsideView(ST_StudentMainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillExpanders();
        }

        public void FillExpanders()
        {
            MyStackPanel.Children.Clear();
            DoneHomeworkStuckPanel.Children.Clear();

            GroupNameTextBlock.Text = GroupName;
            if (db.commandTable("SELECT * FROM homework AS h JOIN groups_and_students AS g_s ON h.id_group = g_s.id_group LEFT JOIN student_homework AS s_h ON g_s.id_student = s_h.id_student AND h.id_homework = s_h.id_homework WHERE h.id_group = '" + GroupID + "' AND s_h.id_student IS NULL AND g_s.id_student = '" + StudentID + "'").Rows.Count == 0)
            {
                TextBlock NoneInfoTextBlock = new TextBlock();
                NoneInfoTextBlock.Text = "На данный момент нет нового домашнего задания";
                MyStackPanel.Children.Add(NoneInfoTextBlock);
            }
            else
            {
                foreach (DataRow rows in db.commandTable("SELECT * FROM homework AS h JOIN groups_and_students AS g_s ON h.id_group = g_s.id_group LEFT JOIN student_homework AS s_h ON g_s.id_student = s_h.id_student AND h.id_homework = s_h.id_homework WHERE h.id_group = '" + GroupID + "' AND s_h.id_student IS NULL AND g_s.id_student = '" + StudentID + "'").Rows)
                {
                    ExpanderPanel exp = new ExpanderPanel(this, Convert.ToString(rows["id_homework"]), Convert.ToString(rows["task_label"]), Convert.ToString(rows["comment"]), Convert.ToDateTime(Convert.ToString(rows["date_of_assignment"])).ToString("dd.MM.yyyy"), Convert.ToDateTime(Convert.ToString(rows["date_of_completion"])).ToString("dd.MM.yyyy"), Convert.ToString(rows["mark"]), MyStackPanel);
                    exp.makeExpader();
                }
            }

            if (db.commandTable("SELECT * FROM homework AS h JOIN student_homework AS s_h ON h.id_homework = s_h.id_homework WHERE h.id_group = '" + GroupID + "' AND id_student = '" + StudentID + "'").Rows.Count == 0)
            {
                TextBlock NoneDoneHomeworkTextBlock = new TextBlock();
                NoneDoneHomeworkTextBlock.Text = "На данный момент нет сданных работ задания";
                DoneHomeworkStuckPanel.Children.Add(NoneDoneHomeworkTextBlock);
            }
            else
            {
                foreach (DataRow rows in db.commandTable("SELECT * FROM homework AS h JOIN student_homework AS s_h ON h.id_homework = s_h.id_homework WHERE h.id_group = '" + GroupID + "' AND id_student = '" + StudentID + "'").Rows)
                {
                    ExpanderPanel exp = new ExpanderPanel(this, Convert.ToString(rows["id_homework"]), Convert.ToString(rows["task_label"]), Convert.ToString(rows["comment"]), Convert.ToDateTime(Convert.ToString(rows["date_of_assignment"])).ToString("dd.MM.yyyy"), Convert.ToDateTime(Convert.ToString(rows["date_of_completion"])).ToString("dd.MM.yyyy"), Convert.ToString(rows["mark"]), DoneHomeworkStuckPanel);
                    exp.makeExpader();
                }
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GroupView groupView = new GroupView(parentWindow);
            groupView.StudentGoupId = this.StudentID;
            parentWindow.ContentHolderFrame.Content = groupView;
        }
    }
    public class ExpanderPanel 
    { 
        public string StudentID { get; set; }
        DB db = new DB();
        public string GroupID { get; set; }
        GroupInsideView ExpanderHolder;

        string id_homework;
        string label;
        string taskcomment;
        string post_date;
        string complation_date;
        string mark;
        StackPanel StackpanelName;

        public ExpanderPanel(GroupInsideView ExpanderHolder,string id_homework, string label, string taskcomment, string post_date, string complation_date, string mark, StackPanel StackpanelName)
        {
            this.ExpanderHolder = ExpanderHolder;
            this.id_homework = id_homework;
            this.label = label;
            this.taskcomment = taskcomment;
            this.post_date = post_date;
            this.complation_date = complation_date;
            this.mark = mark;
            this.StackpanelName = StackpanelName;
        }

        public void makeExpader()
        {
            this.GroupID = ExpanderHolder.GroupID;

            //Create containing stack panel and assign to Grid row/col
            StackPanel sp = new StackPanel();
            sp.Background = new SolidColorBrush(Color.FromRgb(230, 255, 163));
            sp.Margin = new Thickness(0, 10, 0, 0);

            //Create Expander object
            Expander exp = new Expander();

            StackPanel labelStackPanel = new StackPanel();
            labelStackPanel.Orientation = Orientation.Horizontal;
            TextBlock MainLabel = new TextBlock();
            MainLabel.Text = label;

            TextBlock DateOfTheEnd = new TextBlock();
            DateOfTheEnd.Text = "Сдать до " + complation_date;
            DateOfTheEnd.Margin = new Thickness(20, 0, 0, 0);
            DateOfTheEnd.FontSize = 12;
            DateOfTheEnd.Opacity = .40;
            DateOfTheEnd.VerticalAlignment = VerticalAlignment.Bottom;

            labelStackPanel.Children.Add(MainLabel);
            labelStackPanel.Children.Add(DateOfTheEnd);

            exp.Header = labelStackPanel;

            //create grid

            Grid holderGrid = new Grid();
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = new GridLength(1, GridUnitType.Star);
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();

            holderGrid.ColumnDefinitions.Add(colDef1);
            holderGrid.ColumnDefinitions.Add(colDef2);
            holderGrid.RowDefinitions.Add(rowDef1);
            holderGrid.RowDefinitions.Add(rowDef2);
            holderGrid.RowDefinitions.Add(rowDef3);
            holderGrid.RowDefinitions.Add(rowDef4);

            //Create TextBlock with ScrollViewer for Expander Content

            TextBlock date_of_post = new TextBlock();
            date_of_post.Text = "Задано " + post_date;
            date_of_post.FontSize = 14;
            date_of_post.Opacity = .40;
            date_of_post.Margin = new Thickness(5, 10, 0, 0);
            Grid.SetRow(date_of_post, 0);

            TextBlock taskcommentary = new TextBlock();
            taskcommentary.Text = taskcomment;
            taskcommentary.Margin = new Thickness(5, 10, 0, 0);
            taskcommentary.TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(taskcommentary, 1);

            Border line = new Border();
            line.Height = 2;
            line.Margin = new Thickness(5, 10, 0, 0);
            line.Background = new SolidColorBrush(Colors.Black);
            Grid.SetRow(line, 2);

            Button taskButton = new Button();
            taskButton.Content = "Сдать задание";
            taskButton.Margin = new Thickness(5, 10, 0, 10);
            taskButton.Width = 300;

            if (StackpanelName == ExpanderHolder.MyStackPanel)
            {
                taskButton.Click += taskButtonn_Click;
            }
            else
            {

                taskButton.Visibility = Visibility.Hidden;
            }

            Grid.SetRow(taskButton, 3);

            TextBlock markTextBlock = new TextBlock();

            if (mark == "")
            {
                markTextBlock.Text = "Оценка не поставлена";
            }
            else
            {
                markTextBlock.Text = "Оценка: " + mark + "/5";
            }
            markTextBlock.Margin = new Thickness(5, 10, 0, 0);
            markTextBlock.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumn(markTextBlock, 1);

            holderGrid.Children.Add(date_of_post);
            holderGrid.Children.Add(taskcommentary);
            holderGrid.Children.Add(line);
            holderGrid.Children.Add(taskButton);

            if (StackpanelName == ExpanderHolder.DoneHomeworkStuckPanel)
            {
                holderGrid.Children.Add(markTextBlock);
            }

            exp.Content = holderGrid;
            sp.Children.Add(exp);
            StackpanelName.Children.Add(sp);
        }

        private void taskButtonn_Click(object sender, RoutedEventArgs e)
        {
            HometaskViews.HometaskSendView hometaskSendView = new HometaskViews.HometaskSendView();
          
            hometaskSendView.StudentID = Convert.ToInt32(ExpanderHolder.StudentID);
            hometaskSendView.HomeworkID = Convert.ToInt32(id_homework);

            hometaskSendView.Closed += (obj, args) => ExpanderHolder.FillExpanders();

            hometaskSendView.ShowDialog();

        }

        private void taskEditButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}