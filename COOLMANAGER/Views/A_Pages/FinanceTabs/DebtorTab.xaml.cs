using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
namespace COOLMANAGER.Views.A_Pages.FinanceTabs
{
    /// <summary>
    /// Interaction logic for DebtorTab.xaml
    /// </summary>
    public partial class DebtorTab : UserControl
    {
        List<Debtor> debtors;
        string debtorName;
        public DebtorTab()
        {
            InitializeComponent();
            fillDebtorDG();
        }
        public void fillDebtorDG()
        {
            Student_PurseViewModel student_PurseViewModel = new Student_PurseViewModel();
            GroupViewModel groupViewModel = new GroupViewModel();
            SubjectViewModel subjectViewModel = new SubjectViewModel();
            List<Student_Purse> student_Purses = student_PurseViewModel.fillStudentPurse();
            List<Group> groups = groupViewModel.fillGroupGrid();
            List<Subject> subjects = subjectViewModel.fillSubject();
            List<Groups_and_Students> groups_And_Students = groupViewModel.fillGRoup_and_student();
            debtors = new List<Debtor>();

            DB db = new DB();
            int id_student;
            int id_group;
            foreach (DataRow row in db.commandTable("SELECT *, st.name as SName, st.surname as SSurname, st.lastname as SLastname, g.id_group as idgroup, st.id_student as idstudent, g.group_name as GroupName " +
                "FROM students AS st JOIN groups_and_students AS g_s ON st.id_student = g_s.id_student JOIN groups as g ON g_s.id_group  = g.id_group ORDER BY `st`.`id_student` ASC ").Rows)
            {
                id_student = Convert.ToInt32(row["idstudent"]);
                id_group = Convert.ToInt32(row["idgroup"]);
                decimal paidSumm = 0;
                decimal debt = 0;
                int payMonths = 0;
                decimal globalDebt = 0;
                string dateOfLastReceipt = "";

                if (db.commandTable("SELECT *, g_s.date_of_enrollment as DateOfEnrollment, s_p.sum as PaidSumm, s.prise AS SPrise, s_p.date_of_receipt AS LastReceipt " +
                                                         "FROM student_purse as s_p " +
                                                         "JOIN groups as g ON s_p.id_group = g.id_group " +
                                                         "JOIN subjects as s ON g.name_subject = s.name_subject " +
                                                         "JOIN groups_and_students as g_s ON s_p.id_student = g_S.id_student " +
                                                         "WHERE g_s.id_group = s_p.id_group AND s_p.id_student = " + id_student + " AND s_p.id_group = " + id_group + " " +
                                                         "ORDER BY `s_p`.`date_of_receipt` ASC").Rows.Count == 0)
                {
                    foreach (DataRow row0 in db.commandTable("SELECT * FROM groups_and_students as g_s " +
                        "JOIN groups AS g ON g_s.id_group = g.id_group " +
                        "JOIN subjects AS subj ON g.name_subject = subj.name_subject " +
                        "WHERE g_s.id_student = "+ id_student + " AND g_s.id_group = " + id_group + " ").Rows)
                    {
                        payMonths = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(row0["date_of_enrollment"])).TotalDays) / 30;
                        debt = payMonths * Convert.ToDecimal(row0["prise"]);
                        dateOfLastReceipt = "Платежей не обнаружено";
                    }
                    if (debt > 0)
                    {
                        debtors.Add(new Debtor
                        {
    
                            name = Convert.ToString(row["SName"]),
                            surname = Convert.ToString(row["SSurname"]),
                            lastname = Convert.ToString(row["SLastname"]) ,
                            debt = debt,
                            DateLastReceipt = dateOfLastReceipt,
                            groupName = Convert.ToString(row["GroupName"])
                        });
                    }
                }
                else
                {
                     foreach (DataRow row1 in db.commandTable("SELECT *, g_s.date_of_enrollment as DateOfEnrollment, s_p.sum as PaidSumm, s.prise AS SPrise, s_p.date_of_receipt AS LastReceipt from student_purse as s_p " +
                                                              "JOIN groups as g ON s_p.id_group = g.id_group " +
                                                              "JOIN subjects as s ON g.name_subject = s.name_subject " +
                                                              "JOIN groups_and_students as g_s ON s_p.id_student = g_S.id_student " +
                                                              "WHERE g_s.id_group = s_p.id_group AND s_p.id_student = " + id_student + " AND s_p.id_group = " + id_group + " " +
                                                              "ORDER BY `s_p`.`date_of_receipt` ASC").Rows)
                     {
                         payMonths = Convert.ToInt32((DateTime.Today - Convert.ToDateTime(row1["DateOfEnrollment"])).TotalDays) / 30;
                         paidSumm += Convert.ToDecimal(row1["PaidSumm"]); 
                         globalDebt = payMonths * Convert.ToDecimal(row1["SPrise"]);
                         debt = globalDebt - paidSumm;
                         dateOfLastReceipt = Convert.ToDateTime(row1["LastReceipt"]).ToString("dd.MM.yyyy");

                     }
                     if(debt > 0)
                     {
                         debtors.Add(new Debtor {
                             name = Convert.ToString(row["SName"]),
                             surname = Convert.ToString(row["SSurname"]),
                             lastname = Convert.ToString(row["SLastname"]),
                             debt = debt, 
                             DateLastReceipt = dateOfLastReceipt,
                             groupName = Convert.ToString(row["GroupName"])
                         });
                     }
                }
                
            }
            DebtorDG.ItemsSource = debtors;
            }

        private void DebtorTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DebtorTB.Text == "Имя, фамилия, отчество")
            {
                DebtorTB.Text = "";
            }
        }

        private void DebtorTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DebtorTB.Text == "")
            {
                DebtorTB.Text = "Имя, фамилия, отчество";
            }
        }

        private void DebtorTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DebtorTB.Text == "Имя, фамилия, отчество")
            {
                debtorName = "";
            }
            else
            {
                debtorName = DebtorTB.Text;
                Filtring(debtorName);
            }
        }
        private void Filtring(string value)
        {
            var search = debtors.Where(x => (x.name.ToLower().StartsWith(value.ToLower()) || x.surname.ToLower().StartsWith(value.ToLower()) ||
            x.lastname.ToLower().StartsWith(value.ToLower())));

            DebtorDG.ItemsSource = search;
        }

    }
    }
public class Debtor
{
    public string name { get; set; }
    public string surname { get; set; }
    public string lastname { get; set; }

    public decimal debt { get; set; }
    public string DateLastReceipt { get; set; }
    public string groupName { get; set; }

    public string Name 
    {
        get
        {
            return surname + " " + name + "\n" + lastname;
        }
    }

    public string Debt
    {
        get
        {
            return debt + " ₽";
        }
    }
    public string GroupDebt
        {
        get
        {
            return "Долг за группу\n" + groupName;
        }
        }

    }