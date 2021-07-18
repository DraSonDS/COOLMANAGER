using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace COOLMANAGER.Views.A_Pages.StatisticTabs
{
    /// <summary>
    /// Interaction logic for StatisticTabs.xaml
    /// </summary>
    public partial class StatisticTabs : UserControl
    {

        DB db = new DB();
        public StatisticTabs()
        {
            Style expanderStyle;
            expanderStyle = this.FindResource("ModernExpander") as Style;           
            InitializeComponent();
            fillStatistics(expanderStyle);
        }

        public void fillStatistics(Style ExpanderStyle)
        {
            foreach(DataRow row in db.commandTable("SELECT * FROM groups AS g JOIN teachers AS t ON g.id_teacher = t.id_teacher JOIN users AS u ON t.id_user = u.id_user JOIN subjects AS sub ON g.name_subject = sub.name_subject ").Rows)
            {
                int idGroup = Convert.ToInt32(row["id_group"]);
                string groupName = Convert.ToString(row["group_name"]);
                string teachersFullname = Convert.ToString(row["name"] + " " + row["surname"]);
                string subject = Convert.ToString(row["name_subject"]);

                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id_student) FROM `groups_and_students` WHERE id_group = "+ idGroup + "", db.getConnection());
                db.openConnection();
                int studentCount = Convert.ToInt32(cmd.ExecuteScalar());
                db.closeConnection();

                decimal income = studentCount * Convert.ToDecimal(row["prise"]);

                int rowCount = 0;
                Grid studentsGrid = new Grid();
                studentsGrid.Margin = new Thickness(10);
                ColumnDefinition studentC1 = new ColumnDefinition();
                ColumnDefinition studentC2 = new ColumnDefinition();
                studentC1.Width = new GridLength(150, GridUnitType.Pixel);
                studentC2.Width = new GridLength(1, GridUnitType.Star);
                studentsGrid.ColumnDefinitions.Add(studentC1);
                studentsGrid.ColumnDefinitions.Add(studentC2);

                decimal globalGroupDebt = 0;

                foreach (DataRow strow in db.commandTable("SELECT g_s.id_student as idStudent, s.surname as surname, s.name as name, s.lastname as lastname FROM groups_and_students AS g_s " +
                    "JOIN students AS s ON g_s.id_student = s.id_student " +
                    "WHERE g_s.id_group = " + idGroup + "").Rows)
                {
                    int student_id = Convert.ToInt32(strow["idStudent"]);
                    
                    //students grid
                    RowDefinition studentR = new RowDefinition(); 
                    studentR.Height = GridLength.Auto; 
                    studentsGrid.RowDefinitions.Add(studentR);

                    TextBlock studentName = new TextBlock();
                    // studentName.Text = Convert.ToString(strow["surname"] + " " + strow["name"] +" " + strow["lastname"] );

                    string sname = Convert.ToString(strow["name"]).Substring(0,1);
                    string slastname = Convert.ToString(strow["lastname"]).Substring(0,1);

                    studentName.Text = sname + ". " + slastname + ". " +  Convert.ToString(strow["surname"]);
                   
                    studentName.TextWrapping = TextWrapping.Wrap;
                    studentName.VerticalAlignment = VerticalAlignment.Bottom;
                    Grid.SetColumn(studentName, 0);
                    Grid.SetRow(studentName, rowCount);
                    studentsGrid.Children.Add(studentName);

                    StackPanel STDebt = new StackPanel();
                    Grid.SetColumn(STDebt, 1);
                    Grid.SetRow(STDebt, rowCount);
                    studentsGrid.Children.Add(STDebt);

                    decimal paid_summ = 0;
                    decimal globalDebt = 0;

                    fillStudentsInStatistics(idGroup, student_id, ref paid_summ, ref globalDebt, ref globalGroupDebt);

                    TextBlock lockalDebt = new TextBlock();
                    lockalDebt.Text = Convert.ToString(paid_summ) + " ₽ / " + Convert.ToString(globalDebt) + " ₽";
                    lockalDebt.HorizontalAlignment = HorizontalAlignment.Center;
                    STDebt.Children.Add(lockalDebt);

                    ProgressBar debtPBar = new ProgressBar();
                    debtPBar.Minimum = 0;
                    debtPBar.Maximum = Convert.ToDouble(globalDebt);
                    debtPBar.Value = Convert.ToDouble(paid_summ);
                    debtPBar.Style = this.FindResource("StudentDebtBar") as Style;
                    STDebt.Children.Add(debtPBar);

                    rowCount += 1;
                }

                makeStatisticExpander(ExpanderStyle, groupName, Convert.ToString(studentCount), teachersFullname, Convert.ToString(income), Convert.ToString(globalGroupDebt), subject, studentsGrid);

            }
        }

        public void fillStudentsInStatistics(int idGroup, int idStudent, ref decimal paid_summ, ref decimal globalDebt, ref decimal globalGroupDebt)
        {
            int payMonths = 0;
            
            if (db.commandTable("SELECT *, g_s.date_of_enrollment as DateOfEnrollment, s_p.sum as PaidSumm, s.prise AS SPrise " +
                                                 "FROM student_purse as s_p " +
                                                 "JOIN groups as g ON s_p.id_group = g.id_group " +
                                                 "JOIN subjects as s ON g.name_subject = s.name_subject " +
                                                 "JOIN groups_and_students as g_s ON s_p.id_student = g_S.id_student " +
                                                 "WHERE g_s.id_group = s_p.id_group AND s_p.id_student = " + idStudent + " AND s_p.id_group = " + idGroup + " " +
                                                 "ORDER BY `s_p`.`date_of_receipt` ASC").Rows.Count == 0)
            {
                foreach (DataRow row1 in db.commandTable("SELECT * FROM groups_and_students as g_s " +
                    "JOIN groups AS g ON g_s.id_group = g.id_group " +
                    "JOIN subjects AS subj ON g.name_subject = subj.name_subject " +
                    "WHERE g_s.id_student = " + idStudent + " AND g_s.id_group = " + idGroup + " ").Rows)
                {
                    payMonths = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(row1["date_of_enrollment"])).TotalDays) / 30;
                    globalDebt = payMonths * Convert.ToDecimal(row1["prise"]);
                    paid_summ = 0;
                    globalGroupDebt += globalDebt;
                } 
            }
            else
            {
                foreach (DataRow row2 in db.commandTable("SELECT *, g_s.date_of_enrollment as DateOfEnrollment, s_p.sum as PaidSumm, s.prise AS SPrise, s_p.date_of_receipt AS LastReceipt from student_purse as s_p " +
                                                         "JOIN groups as g ON s_p.id_group = g.id_group " +
                                                         "JOIN subjects as s ON g.name_subject = s.name_subject " +
                                                         "JOIN groups_and_students as g_s ON s_p.id_student = g_S.id_student " +
                                                         "WHERE g_s.id_group = s_p.id_group AND s_p.id_student = " + idStudent + " AND s_p.id_group = " + idGroup + " " +
                                                         "ORDER BY `s_p`.`date_of_receipt` ASC").Rows)
                {
                    payMonths = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(row2["DateOfEnrollment"])).TotalDays) / 30;
                    paid_summ += Convert.ToDecimal(row2["PaidSumm"]);
                    globalDebt = payMonths * Convert.ToDecimal(row2["SPrise"]);
                    globalGroupDebt += globalDebt;
                }
            }
        }

        public void makeStatisticExpander(Style ExpanderStyle,
            string group_name,
            string student_count, 
            string teacher_name,
            string global_income,
            string global_debt,
            string name_subject,
            Grid students_grid)
        {
            Expander StatisticExpander = new Expander();
            StatisticExpander.Style = ExpanderStyle;
            Grid headerGrid = new Grid();
            ColumnDefinition colDef1 = new ColumnDefinition();
            colDef1.Width = new GridLength(10, GridUnitType.Pixel);
            ColumnDefinition colDef2 = new ColumnDefinition();
            colDef2.Width = GridLength.Auto;
            ColumnDefinition colDef3 = new ColumnDefinition();
            colDef3.Width = new GridLength(1, GridUnitType.Star);
            headerGrid.ColumnDefinitions.Add(colDef1);
            headerGrid.ColumnDefinitions.Add(colDef2);
            headerGrid.ColumnDefinitions.Add(colDef3);

            Border colorGroup = new Border();
            Random rnd = new Random();
            Color backgroundColor = Color.FromRgb(Convert.ToByte(rnd.Next(253)), Convert.ToByte(rnd.Next(253)), Convert.ToByte(rnd.Next(253)));
            colorGroup.Background = new SolidColorBrush(backgroundColor);
            Grid.SetColumn(colorGroup, 0);
            headerGrid.Children.Add(colorGroup);

            TextBlock groupName = new TextBlock();
            groupName.Text = group_name;
            groupName.FontWeight = FontWeights.Black;
            groupName.Margin = new Thickness(10, 5, 0, 0);
            groupName.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(groupName, 1);
            headerGrid.Children.Add(groupName);

            StackPanel smallInfoSP = new StackPanel();
            smallInfoSP.Orientation = Orientation.Horizontal;
            smallInfoSP.HorizontalAlignment = HorizontalAlignment.Right;

            Image stLableIcon = new Image();
            stLableIcon.Source = new BitmapImage(new Uri(@"/Images/Icons/studentIconW.png", UriKind.Relative));
            stLableIcon.Margin = new Thickness(20, 0, 0, 0);

            TextBlock stCountIcon = new TextBlock();
            stCountIcon.VerticalAlignment = VerticalAlignment.Center;
            stCountIcon.Margin = new Thickness(5, 0, 0, 0);
            stCountIcon.Text = student_count;

            Image TIcon = new Image();
            TIcon.Source = new BitmapImage(new Uri(@"/Images/Icons/teacherIconW.png", UriKind.Relative));
            TIcon.Margin = new Thickness(20, 0, 0, 0);

            TextBlock TLableIcon = new TextBlock();
            TLableIcon.VerticalAlignment = VerticalAlignment.Center;
            TLableIcon.Margin = new Thickness(5, 0, 0, 0);
            TLableIcon.Text = teacher_name;

            Image finIcon = new Image();
            finIcon.Source = new BitmapImage(new Uri(@"/Images/Icons/financeIconW.png", UriKind.Relative));
            finIcon.Margin = new Thickness(20, 0, 0, 0);

            TextBlock finLableIcon = new TextBlock();
            finLableIcon.VerticalAlignment = VerticalAlignment.Center;
            finLableIcon.Margin = new Thickness(5, 0, 20, 0);
            finLableIcon.Text = global_income + " ₽";

            smallInfoSP.Children.Add(stLableIcon);
            smallInfoSP.Children.Add(stCountIcon);
            smallInfoSP.Children.Add(TIcon);
            smallInfoSP.Children.Add(TLableIcon);
            smallInfoSP.Children.Add(finIcon);
            smallInfoSP.Children.Add(finLableIcon);
            headerGrid.Children.Add(smallInfoSP);
            Grid.SetColumn(smallInfoSP, 2);

            StatisticExpander.Header = headerGrid;
            
            // Content

            Grid InsideExpander = new Grid();
            ColumnDefinition InsidecolDef1 = new ColumnDefinition();
            ColumnDefinition InsidecolDef2 = new ColumnDefinition();
            ColumnDefinition InsidecolDef3 = new ColumnDefinition();
            InsidecolDef1.Width = GridLength.Auto;
            InsidecolDef2.Width = new GridLength(200, GridUnitType.Pixel);
            InsidecolDef3.Width = new GridLength(1, GridUnitType.Star);

            RowDefinition InsideRow1 = new RowDefinition();
            RowDefinition InsideRow2 = new RowDefinition();
            RowDefinition InsideRow3 = new RowDefinition();
            RowDefinition InsideRow4 = new RowDefinition();
            RowDefinition InsideRow5 = new RowDefinition();
            RowDefinition InsideRow6 = new RowDefinition();
            InsideRow1.Height = GridLength.Auto;
            InsideRow2.Height = GridLength.Auto;
            InsideRow3.Height = GridLength.Auto;
            InsideRow4.Height = GridLength.Auto;
            InsideRow5.Height = GridLength.Auto;
            InsideRow6.Height = GridLength.Auto;

            InsideExpander.ColumnDefinitions.Add(InsidecolDef1);
            InsideExpander.ColumnDefinitions.Add(InsidecolDef2);
            InsideExpander.ColumnDefinitions.Add(InsidecolDef3);
            InsideExpander.RowDefinitions.Add(InsideRow1);
            InsideExpander.RowDefinitions.Add(InsideRow2);
            InsideExpander.RowDefinitions.Add(InsideRow3);
            InsideExpander.RowDefinitions.Add(InsideRow4);
            InsideExpander.RowDefinitions.Add(InsideRow5);
            InsideExpander.RowDefinitions.Add(InsideRow6);

            Border backgroud = new Border();
            backgroud.Background = new SolidColorBrush(Color.FromRgb(202, 210, 197));
            Grid.SetRow(backgroud, 0);
            Grid.SetColumn(backgroud, 0);
            Grid.SetRowSpan(backgroud, 6);
            Grid.SetColumnSpan(backgroud, 2);
            backgroud.CornerRadius = new CornerRadius(10);
            InsideExpander.Children.Add(backgroud);
            StatisticExpander.Content = InsideExpander;
            ExpanderHolder.Children.Add(StatisticExpander);

            TextBlock group = new TextBlock();
            group.Text = "Группа";
            group.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(group, 0);
            Grid.SetColumn(group, 0);
            InsideExpander.Children.Add(group);

            TextBlock teacher = new TextBlock();
            teacher.Text = "Преподаватель";
            teacher.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(teacher, 1);
            Grid.SetColumn(teacher, 0);
            InsideExpander.Children.Add(teacher);

            TextBlock income = new TextBlock();
            income.Text = "Прибыль";
            income.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(income, 2);
            Grid.SetColumn(income, 0);
            InsideExpander.Children.Add(income);

            TextBlock debt = new TextBlock();
            debt.Text = "Общая сумма долга";
            debt.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(debt, 3);
            Grid.SetColumn(debt, 0);
            InsideExpander.Children.Add(debt);

            TextBlock count = new TextBlock();
            count.Text = "Количество учеников";
            count.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(count, 4);
            Grid.SetColumn(count, 0);
            InsideExpander.Children.Add(count);

            TextBlock subject = new TextBlock();
            subject.Text = "Предмет";
            subject.Style = this.FindResource("NameTB") as Style;
            Grid.SetRow(subject, 6);
            Grid.SetColumn(subject, 0);
            InsideExpander.Children.Add(subject);

            //info

            TextBlock students = new TextBlock();
            students.Text = "Ученики";
            students.Style = this.FindResource("NameTB") as Style;
            students.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(students, 0);
            Grid.SetColumn(students, 2);
            InsideExpander.Children.Add(students);

            TextBlock groupInfo = new TextBlock();
            groupInfo.Text = group_name;
            groupInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(groupInfo, 0);
            Grid.SetColumn(groupInfo, 1);
            InsideExpander.Children.Add(groupInfo);

            TextBlock teacherInfo = new TextBlock();
            teacherInfo.Text = teacher_name;
            teacherInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(teacherInfo, 1);
            Grid.SetColumn(teacherInfo, 1);
            InsideExpander.Children.Add(teacherInfo);

            TextBlock incomeInfo = new TextBlock();
            incomeInfo.Text = global_income + " ₽/месяц";
            incomeInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(incomeInfo, 2);
            Grid.SetColumn(incomeInfo, 1);
            InsideExpander.Children.Add(incomeInfo);

            TextBlock debtInfo = new TextBlock();
            debtInfo.Text = global_debt + " ₽";
            debtInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(debtInfo, 3);
            Grid.SetColumn(debtInfo, 1);
            InsideExpander.Children.Add(debtInfo);

            TextBlock countInfo = new TextBlock();
            countInfo.Text = student_count;
            countInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(countInfo, 4);
            Grid.SetColumn(countInfo, 1);
            InsideExpander.Children.Add(countInfo);

            TextBlock subjectInfo = new TextBlock();
            subjectInfo.Text = name_subject;
            subjectInfo.Style = this.FindResource("InfoTextTB") as Style;
            Grid.SetRow(subjectInfo, 5);
            Grid.SetColumn(subjectInfo, 1);
            InsideExpander.Children.Add(subjectInfo);

            // column 2

            Border studentBorder = new Border();
            studentBorder.Margin = new Thickness(10, 10, 10, 10);
            studentBorder.Background = new SolidColorBrush(Color.FromRgb(132, 169, 140));
            studentBorder.CornerRadius = new CornerRadius(10);
            studentBorder.MaxHeight = 130;
            Grid.SetRow(studentBorder, 1);
            Grid.SetColumn(studentBorder, 2);
            Grid.SetRowSpan(studentBorder, 6);


            ScrollViewer scroll = new ScrollViewer();
            scroll.Content = students_grid;
            studentBorder.Child = scroll;
            InsideExpander.Children.Add(studentBorder);
        }
    }
}
