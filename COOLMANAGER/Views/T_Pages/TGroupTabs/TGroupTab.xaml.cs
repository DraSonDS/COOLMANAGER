using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COOLMANAGER.Views.T_Pages.TGroupTabs
{
    /// <summary>
    /// Interaction logic for TGroupTab.xaml
    /// </summary>
    public partial class TGroupTab : UserControl
    { 
        ExpanderPanel TaskExpander;
        int GroupID;
        int TeacherID;
        int UserID;
        TMainForm parentWindow;
        DB db = new DB();
        Style ExpStyle;
        Style ViewAssighnemtB;
        TextBlock TextBlockTask;
        //grade student row  
        public TGroupTab(int TeacherID, int GroupID, TMainForm parentWindow, int UserID)
        {  
            InitializeComponent();
            TaskName.Visibility = Visibility.Hidden;
            this.TextBlockTask = this.TaskName;
            this.TeacherID = TeacherID;
            this.UserID = UserID;
            this.GroupID = GroupID;
            this.parentWindow = parentWindow;
            ExpStyle = this.FindResource("TModernExpander") as Style;           
            ViewAssighnemtB = this.FindResource("ViewAssignmentB") as Style;
            fillTaskList();
            fillGrades();
            fillSTGrid();
        }
        public void fillTaskList()
        {
            TaskContentHolder.Children.Clear();
            foreach (DataRow row in db.commandTable("SELECT * FROM homework WHERE id_group = "+ GroupID + " ORDER BY `homework`.`date_of_completion` DESC ").Rows)
            {
                TaskExpander = new ExpanderPanel(Convert.ToInt32(row["id_homework"]), Convert.ToString(row["task_label"]), Convert.ToString(row["comment"]), Convert.ToString(row["date_of_assignment"]), Convert.ToString(row["date_of_completion"]), TaskContentHolder, ExpStyle, ViewAssighnemtB, TextBlockTask, StudentsDoneTasks);
                TaskExpander.makeExpader();
            }   
        }

        private void AddTaskB_Click(object sender, RoutedEventArgs e)
        {
            AddHomeWorkForm addHomeWork = new AddHomeWorkForm(GroupID, TeacherID, this);
            addHomeWork.ShowDialog();
        }

        private void fillGrades()
        {
            int rowCount = 1;
            int ColumnCount = 1;

            foreach (DataRow row in db.commandTable("SELECT * FROM groups_and_students AS g_s " +
                "JOIN students AS s ON g_s.id_student = s.id_student " +
                "WHERE id_group = " + GroupID + " ORDER BY `s`.`surname` ASC").Rows)
            {
                string fullName = Convert.ToString(row["name"]).Substring(0, 1) + ". " +
                    Convert.ToString(row["lastname"]).Substring(0, 1) + ". " +
                    Convert.ToString(row["surname"]);
                RowDefinition StudentGradeRow = new RowDefinition();
                StudentGradeRow.Height = new GridLength(50);
                GradesGrid.RowDefinitions.Add(StudentGradeRow);

                TextBlock StudentName = new TextBlock();
                StudentName.Text = fullName;
                StudentName.VerticalAlignment = VerticalAlignment.Center;
                StudentName.Foreground = new SolidColorBrush(Colors.Black);
                Grid.SetRow(StudentName, rowCount);
                GradesGrid.Children.Add(StudentName);
                rowCount++;
            }

           
            int id_homework = 0;
            foreach (DataRow row in db.commandTable("SELECT * FROM homework WHERE id_group = " + GroupID + " ORDER BY `homework`.`date_of_completion` DESC ").Rows)
            {
                ColumnDefinition TaskGradeColumn = new ColumnDefinition();
                TaskGradeColumn.Width = new GridLength(100, GridUnitType.Pixel);
                GradesGrid.ColumnDefinitions.Add(TaskGradeColumn);

                StackPanel taskInfo = new StackPanel();
                taskInfo.Margin = new Thickness(5);
                Grid.SetRow(taskInfo, 0);
                Grid.SetColumn(taskInfo, ColumnCount);

                TextBlock dateOfCompletion = new TextBlock();
                dateOfCompletion.Text = Convert.ToDateTime(row["date_of_completion"]).ToString("M");
                dateOfCompletion.Opacity = .40;
                dateOfCompletion.Foreground = new SolidColorBrush(Colors.Black);
                dateOfCompletion.HorizontalAlignment = HorizontalAlignment.Left;
                dateOfCompletion.FontSize = 12;
                taskInfo.Children.Add(dateOfCompletion);
               
                TextBlock taskName = new TextBlock();
                taskName.Text = Convert.ToString(row["task_label"]);
                taskName.FontWeight = FontWeights.Bold;
                taskName.TextWrapping = TextWrapping.Wrap;
                taskName.Foreground = new SolidColorBrush(Colors.Black);
                taskInfo.Children.Add(taskName);
                GradesGrid.Children.Add(taskInfo);

                id_homework = Convert.ToInt32(row["id_homework"]);

                rowCount = 1;
                foreach (DataRow row1 in db.commandTable("SELECT *, s_h.id_homework as student_homework " +
                    "FROM groups_and_students AS g_s " +
                    "JOIN students as s ON g_s.id_student = s.id_student " +
                    "JOIN homework as h ON g_s.id_group = h.id_group " +
                    "LEFT JOIN student_homework as s_h ON g_s.id_student = s_h.id_student AND h.id_homework = s_h.id_homework " + 
                    "WHERE g_s.id_group = " + GroupID + " AND h.id_homework = " + id_homework + " " +
                    "ORDER BY `s`.`surname` ASC ").Rows)
                {
                    TextBlock mark = new TextBlock();
                    mark.HorizontalAlignment = HorizontalAlignment.Left;
                    mark.VerticalAlignment = VerticalAlignment.Center;
                    mark.Margin = new Thickness(5);
                    mark.TextWrapping = TextWrapping.Wrap;
                    mark.Foreground = new SolidColorBrush(Colors.Black);


                    if (row1["student_homework"] == DBNull.Value)
                    {
                        mark.Text = "Отсутствует";
                    }
                    else if (row1["mark"] == DBNull.Value)
                    {
                        mark.Text = "Оценка не поставлена";
                    }
                    else
                    {
                        if (Convert.ToInt32(row1["mark"]) == 5)
                        {
                            mark.Text = "5";
                            mark.Foreground = new SolidColorBrush(Colors.Green);
                        }
                        else if (Convert.ToInt32(row1["mark"]) == 4)
                        {
                            mark.Text = "4";
                            mark.Foreground = new SolidColorBrush(Colors.Green);
                        }
                        else if (Convert.ToInt32(row1["mark"]) == 3)
                        {
                            mark.Text = "3";
                            mark.Foreground = new SolidColorBrush(Colors.Orange);
                        }
                        else if (Convert.ToInt32(row1["mark"]) == 2)
                        {
                            mark.Text = "2";
                            mark.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    Grid.SetColumn(mark, ColumnCount);
                    Grid.SetRow(mark, rowCount);
                    GradesGrid.Children.Add(mark);

                    rowCount++;
                }

                ColumnCount++;
            }   
        }
        public void fillSTGrid()
        {
            List<Student> student_in_group = new List<Student>();
           foreach (DataRow stRow in db.commandTable("SELECT * FROM students as s JOIN groups_and_students as g_s ON s.id_student = g_s.id_student WHERE g_s.id_group = "+ GroupID +"").Rows)
            {
                student_in_group.Add(new Student()
                {
                    name = Convert.ToString(stRow["name"]),
                    surname = Convert.ToString(stRow["surname"]),
                    lastname = Convert.ToString(stRow["lastname"]),
                    StudentAge = Convert.ToString(stRow["birth_date"])
                });
            }
            StudentGrid.ItemsSource = student_in_group;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GroupChooseTab groupChooseTab = new GroupChooseTab(UserID, parentWindow);
            parentWindow.TContentPlace.Content = groupChooseTab;
        }
    }

    public class ExpanderPanel
    {
        DB db = new DB();
        public string GroupID { get; set; }
        int id_homework;
        string label;
        string taskcomment;
        string post_date;
        string complation_date;
        StackPanel StackpanelName;
        Style ExpStyle;
        Style ViewAssighnemtB;
        TextBlock TaskName;
        StackPanel TaskSP;

        public ExpanderPanel(int id_homework, string label, string taskcomment, string post_date, string complation_date, StackPanel StackpanelName, Style ExpStyle , Style ViewAssighnemtB, TextBlock taskName, StackPanel TaskSP)
        {
            this.id_homework = id_homework;
            this.label = label;
            this.taskcomment = taskcomment;
            this.post_date = post_date;
            this.complation_date = complation_date;
            this.StackpanelName = StackpanelName;
            this.ExpStyle = ExpStyle;
            this.ViewAssighnemtB = ViewAssighnemtB;
            this.TaskName = taskName;
            this.TaskSP = TaskSP;
        }

        public string turnedInCount()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(id_student) FROM student_homework WHERE id_homework = "+ id_homework + "", db.getConnection());
            db.openConnection();
            string count =command.ExecuteScalar().ToString();
            db.closeConnection();
            return count;
        }
        public string AssignedStudentCount()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(id_student) FROM student_homework WHERE id_homework = " + id_homework + " AND mark != null", db.getConnection());
            db.openConnection();
            string count = command.ExecuteScalar().ToString();
            db.closeConnection();
            return count;
        }

        public void makeExpader()
        {
            //Create Expander object
            Expander exp = new Expander();
            exp.Style = ExpStyle;

            WrapPanel labelStackPanel = new WrapPanel();
            labelStackPanel.Orientation = Orientation.Horizontal;

            TextBlock MainLabel = new TextBlock();
            MainLabel.Text = label;
            MainLabel.Margin = new Thickness(10, 0, 0, 0);

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
            colDef1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = GridLength.Auto;
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
            line.Opacity = .70;
            line.Background = new SolidColorBrush(Colors.Silver);
            Grid.SetRow(line, 2);
            Grid.SetColumnSpan(line, 2);

            Button taskButton = new Button();
            taskButton.Content = "Посмотреть работы";
            taskButton.Margin = new Thickness(5, 10, 0, 10);
            taskButton.Width = 200;
            taskButton.Style = ViewAssighnemtB;
            Grid.SetRow(taskButton, 3);
            taskButton.Click += taskButtonn_Click;

            WrapPanel TurnedAndAssigned = new WrapPanel();
            TurnedAndAssigned.Orientation = Orientation.Horizontal;
            Grid.SetColumn(TurnedAndAssigned, 2);
            Grid.SetRowSpan(TurnedAndAssigned, 4);

            StackPanel TurnedIn = new StackPanel();
            TurnedAndAssigned.Children.Add(TurnedIn);

            TextBlock TurnedInCount = new TextBlock();
            TurnedInCount.Text = turnedInCount();
            TurnedInCount.FontSize = 20;
            TurnedInCount.FontWeight = FontWeights.Black;

            TextBlock TurnedInText = new TextBlock();
            TurnedInText.Text = "Работ сдано";
            TurnedInText.Opacity = .40;

            TurnedIn.Children.Add(TurnedInCount);
            TurnedIn.Children.Add(TurnedInText);

            StackPanel Assigned = new StackPanel();
            Assigned.Margin = new Thickness(10, 0, 0, 0);
            TurnedAndAssigned.Children.Add(Assigned);

            TextBlock AssignedCount = new TextBlock();
            AssignedCount.Text = AssignedStudentCount();
            AssignedCount.FontSize = 20;
            AssignedCount.FontWeight = FontWeights.Black;

            TextBlock AssignedText = new TextBlock();
            AssignedText.Text = "Оценено";
            AssignedText.Opacity = .40;

            Assigned.Children.Add(AssignedCount);
            Assigned.Children.Add(AssignedText);

            holderGrid.Children.Add(date_of_post);
            holderGrid.Children.Add(taskcommentary);
            holderGrid.Children.Add(line);
            holderGrid.Children.Add(taskButton);
            holderGrid.Children.Add(TurnedAndAssigned);

            exp.Content = holderGrid; 
            StackpanelName.Children.Add(exp);
        }

        int StudentID;

        private void taskButtonn_Click(object sender, RoutedEventArgs e)
        {
            TaskName.Visibility = Visibility.Visible;
            TaskName.Text = label;
            TaskSP.Children.Clear();

            if(db.commandTable("SELECT * FROM `student_homework` as s_h JOIN students as s ON s_h.id_student = s.id_student WHERE id_homework = " + id_homework + "").Rows.Count == 0)
            {
                TextBlock emptyList = new TextBlock();
                emptyList.Text = "Заданий не найдено";
                emptyList.Margin = new Thickness(5);
                emptyList.HorizontalAlignment = HorizontalAlignment.Left;
                TaskSP.Children.Add(emptyList);
            }
            else
            {
                foreach (DataRow trow in db.commandTable("SELECT * FROM `student_homework` as s_h JOIN students as s ON s_h.id_student = s.id_student WHERE id_homework = " + id_homework + "").Rows)
                {
                    StudentID = Convert.ToInt32(trow["id_student"]);

                    Expander DoneTaskExp = new Expander();
                    DoneTaskExp.Style = ExpStyle;

                    TextBlock StudentsTask = new TextBlock();
                    StudentsTask.Text = Convert.ToString(trow["surname"] + " " + trow["name"]);
                    StudentsTask.Margin = new Thickness(5);
                    DoneTaskExp.Header = StudentsTask;

                    StackPanel taskInfo = new StackPanel();
                    taskInfo.Margin = new Thickness(10);

                    StackPanel markPlaceholder = new StackPanel();
                    markPlaceholder.Orientation = Orientation.Horizontal;
                    markPlaceholder.HorizontalAlignment = HorizontalAlignment.Right;

                    TextBlock markrefresh = new TextBlock();
                    markrefresh.Text = "Оценка поставлена";
                    markrefresh.Margin = new Thickness(0, 0, 5, 0);
                    markrefresh.Opacity = 0;
                    markPlaceholder.Children.Add(markrefresh);
                  

                    TextBlock markLabel = new TextBlock();
                    markLabel.Text = "Оценка: ";
                    markPlaceholder.Children.Add(markLabel);

                   
                    MarkCB markPlace = new MarkCB();
                    markPlace.Text = Convert.ToString(trow["mark"]);
                    markPlace.BorderThickness = new Thickness(0, 0, 0, 1);
                    markPlace.id_student = StudentID;
                    markPlace.id_homework = id_homework;
                    markPlace.Width = 15;
                    markPlaceholder.Children.Add(markPlace);
                    markPlace.PreviewTextInput += MarkPlace_PreviewTextInput;
                    markPlace.MaxLength = 1;
                    markPlace.LostFocus += MarkPlace_LostFocus;
                    markPlace.KeyDown += MarkPlace_KeyDown;

                    TextBlock markLabel2 = new TextBlock();
                    markLabel2.Text = "/ 5";
                    markPlaceholder.Children.Add(markLabel2);

                    taskInfo.Children.Add(markPlaceholder);

                    TextBlock comment = new TextBlock();
                    comment.TextWrapping = TextWrapping.Wrap;
                    comment.Text = Convert.ToString(trow["comment"]);
                    comment.Margin = new Thickness(5);
                    taskInfo.Children.Add(comment);


                    MyButton downloadFile = new MyButton();
                    downloadFile.Content = "Скачать файл";
                    downloadFile.Width = 130;
                    downloadFile.HorizontalAlignment = HorizontalAlignment.Left;
                    downloadFile.Margin = new Thickness(5);

                    if(trow["file_data"] == DBNull.Value)
                    {
                        downloadFile.IsEnabled = false;
                    }
                    taskInfo.Children.Add(downloadFile);
                    DoneTaskExp.Content = taskInfo;

                    downloadFile.id_homework = id_homework;

                    downloadFile.id_student = StudentID;


                    downloadFile.Click += DownloadFile_Click;

                    TaskSP.Children.Add(DoneTaskExp);
                }
            }    
        }

        private void MarkPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if ((sender as MarkCB).Text == "")
                {
                    return;
                }
                else
                {
                    foreach (var child in ((sender as MarkCB).Parent as StackPanel).Children)
                    {
                        if (child.GetType().ToString() == "System.Windows.Controls.TextBlock")
                        {
                            TextBlock markRefreshTB = (TextBlock)child;
                            if (markRefreshTB.Text == "Оценка поставлена")
                            {
                                markRefreshTB.Opacity = 1;

                                DoubleAnimation markRefreshAnimation = new DoubleAnimation();
                                markRefreshAnimation.From = markRefreshTB.Opacity;
                                markRefreshAnimation.To = .0;
                                markRefreshAnimation.Duration = TimeSpan.FromSeconds(3);
                                markRefreshTB.BeginAnimation(TextBlock.OpacityProperty, markRefreshAnimation);
                                Keyboard.Focus(((sender as MarkCB).Parent as StackPanel));
                            }
                        }
                    }
                    int mark = Convert.ToInt32((sender as MarkCB).Text);
                    int id_student = (sender as MarkCB).id_student;
                    int id_homework = (sender as MarkCB).id_homework;

                    addMark(mark, id_student, id_homework);
                    
                }
            }
        }

        private void MarkPlace_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as MarkCB).Text == "")
            {
                return;
            }
            else
            {
                foreach (var child in ((sender as MarkCB).Parent as StackPanel).Children)
                {
                    if (child.GetType().ToString() == "System.Windows.Controls.TextBlock")
                    {
                        TextBlock markRefreshTB = (TextBlock)child;
                        if(markRefreshTB.Text == "Оценка поставлена")
                        {
                            markRefreshTB.Opacity = 1;
                           
                            DoubleAnimation markRefreshAnimation = new DoubleAnimation();
                            markRefreshAnimation.From = markRefreshTB.Opacity;
                            markRefreshAnimation.To = .0;
                            markRefreshAnimation.Duration = TimeSpan.FromSeconds(3);
                            markRefreshTB.BeginAnimation(TextBlock.OpacityProperty, markRefreshAnimation);

                        }
                    }
                }
                int mark = Convert.ToInt32((sender as MarkCB).Text);
                int id_student = (sender as MarkCB).id_student;
                int id_homework = (sender as MarkCB).id_homework;

                addMark(mark, id_student, id_homework);
            }
            
        }

        void addMark(int mark, int id_student, int id_homework)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student_homework` SET `mark` = "+ mark + " WHERE `id_homework` = " + id_homework + " AND `id_student` = " + id_student + " ", db.getConnection());
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }

        private void MarkPlace_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex("[^2-5]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void DownloadFile_Click(object sender, RoutedEventArgs e)
        {
            int homeworkID = (sender as MyButton).id_homework;
            int studentID = (sender as MyButton).id_student;
           
            DB db = new DB();
            MySqlDataAdapter da;
            MySqlCommandBuilder cb;
            DataTable data_bin = new DataTable();
            da = new MySqlDataAdapter("SELECT `file_name`,`file_data` FROM `student_homework` WHERE `id_homework` = "+ homeworkID + " AND `id_student` = "+ studentID + " ", db.getConnection());
            cb = new MySqlCommandBuilder(da);
            da.Fill(data_bin);
            foreach (DataRow rows in data_bin.Rows)
            {
                string PathToDownload;
                System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
                var result = openFileDlg.ShowDialog();
                if (result.ToString() != string.Empty)
                {
                    PathToDownload = openFileDlg.SelectedPath;
                    string str = PathToDownload + "/" + (string)rows["file_name"];
                    byte[] Img = (byte[])rows["file_data"];
                    FileStream fs = new FileStream(str, FileMode.CreateNew, FileAccess.Write);
                    fs.Write(Img, 0, Img.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
        }
    }
    class MyButton : Button
    {
        private Type m_TYpe;

        private object m_Object;

        public object Object
        {
            get { return m_Object; }
            set { m_Object = value; }
        }

        public Type TYpe
        {
            get { return m_TYpe; }
            set { m_TYpe = value; }
        }

        public int id_student;
        public int id_homework;
    }

    class MarkCB : TextBox
    {
        private Type m_TYpe;

        private object m_Object;

        public object Object
        {
            get { return m_Object; }
            set { m_Object = value; }
        }

        public Type TYpe
        {
            get { return m_TYpe; }
            set { m_TYpe = value; }
        }

        public int id_student;
        public int id_homework;
    }

}
