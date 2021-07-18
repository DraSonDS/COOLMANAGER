using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Data;
using COOLMANAGER.Views.A_Pages.GroupTabs;

namespace COOLMANAGER.Views.GroupEditForms
{
    /// <summary>
    /// Interaction logic for GroupDetailForm.xaml
    /// </summary>
    public partial class GroupDetailForm : UserControl
    {
        GroupDetailViewModel groupDetailViewModel = new GroupDetailViewModel();

        DB db = new DB();
        Group groupInfo = new Group();
        string groupName;
        int groupID;
        public GroupDetailForm(string grName)
        {
            InitializeComponent();
            Schedule_empty.Visibility = Visibility.Hidden;
            groupName = grName;
            //insert group info

            groupInfo = groupDetailViewModel.fillGroup(grName);

            groupID = groupInfo.id_group;
            GroupNameTextBlock.Text = groupInfo.group_name;
            GroupStatusTextBlock.Text = groupInfo.status;
            TeachersNameTextBlock.Text = groupInfo.teachers_fullname;
            
            List<Student> student = new List<Student>();
            student = groupDetailViewModel.fillStudents_in_group(grName);
            StInsideGroupDG.ItemsSource = student;

            //insert schedue info
            Schedue schedueInfo = new Schedue();
            schedueInfo = groupDetailViewModel.fillSchedue(grName);

            if (schedueInfo.monday == 1)
            {
                Monday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.tuesday == 1)
            {
                Tuesday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.wednesday == 1)
            {
                Wednesday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.thursday == 1)
            {
                Thursday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.friday == 1)
            {
                Friday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.saturday == 1)
            {
                Satudrday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if (schedueInfo.sunday == 1)
            {
                Sunday.Background = new SolidColorBrush(Color.FromRgb(165, 255, 99));
            }
            if(schedueInfo.monday == 0 && schedueInfo.tuesday == 0 && schedueInfo.thursday == 0 &&
                schedueInfo.wednesday == 0 && schedueInfo.friday == 0 && schedueInfo.saturday == 0 && schedueInfo.sunday == 0)
            {
                Schedule_label.Visibility = Visibility.Hidden;
                Schedule_empty.Visibility = Visibility.Visible;
            }
            StartTime.Text = Convert.ToString(schedueInfo.time_start_lession.ToShortTimeString()) + " ";
            EndTime.Text = Convert.ToString(schedueInfo.time_end_lession.ToShortTimeString());
        }

        private void PrintB_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            
            
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range headerRange = xlWorkSheet.Range[xlWorkSheet.Cells[1,1], xlWorkSheet.Cells[1,3]];
            headerRange.Merge();
            headerRange.Value = "Группы";
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.Font.Size = 18;
            headerRange.Font.Bold = true;

            xlWorkSheet.Cells[2, 1] = "Список учеников: ";
            
            int row_i = 3;
            int student_count = 0;
            foreach (DataRow rows in db.commandTable("SELECT * FROM groups AS g " +
                "JOIN groups_and_students AS g_s ON g.id_group = g_s.id_group " +
                "JOIN students AS s ON g_s.id_student = s.id_student " +
                "JOIN users AS u ON s.id_user = u.id_user " +
                "WHERE g.id_group = 2").Rows)
            {
                xlWorkSheet.Cells[row_i, 2] = Convert.ToString(rows["name"]) + " " + Convert.ToString(rows["surname"]) + " " + Convert.ToString(rows["lastname"]);
                row_i++;
                student_count++;
            }
            xlWorkSheet.Cells[row_i, 1] = "Количество учеников:";
            xlWorkSheet.Cells[row_i, 2] = student_count;
            row_i++;
            xlWorkSheet.Cells[row_i, 1] = "Предмет:";
            xlWorkSheet.Cells[row_i, 2] = groupInfo.name_subject;
            row_i++; 
            xlWorkSheet.Cells[row_i, 1] = "Преподаватель:";
            xlWorkSheet.Cells[row_i, 2] = groupInfo.teachers_name;
            row_i++;
            xlWorkSheet.Cells[row_i, 1] = "Статус:";
            xlWorkSheet.Cells[row_i, 2] = groupInfo.status;
            row_i++; 
            xlWorkSheet.Cells[row_i, 2] = "Дата формирования отчёта:";
            xlWorkSheet.Cells[row_i, 3] = DateTime.Now;
            row_i++;

            xlApp.Visible = true;


        }

        private void AddToGroupB_Click(object sender, RoutedEventArgs e)
        {
            AddStudentToGroupForm addStudentToGroupForm = new AddStudentToGroupForm(groupID);
            addStudentToGroupForm.ShowDialog();
        }
    }
}
