using COOLMANAGER.ViewModels;
using COOLMANAGER.Views;
using COOLMANAGER.Views.A_Pages.FinanceTabs;
using COOLMANAGER.Views.A_Pages.FInanceTabs;
using COOLMANAGER.Views.A_Pages.LidPage;
using COOLMANAGER.Views.A_Pages.StatisticTabs;
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

namespace COOLMANAGER
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public ContentControl ContPlace
        {
            get { return ContentPlace; }
            set { ContentPlace = value; }
        }
        StudentForm studentForm = new StudentForm();
        TeacherForm teacherForm = new TeacherForm();
        LidTab lidTab = new LidTab();
        GroupForm groupForm;
        FinanceTab financeTab = new FinanceTab();
        DebtorTab debtorTab = new DebtorTab();
        StatisticTabs statistic = new StatisticTabs();
       
        public MainForm()
        {
            InitializeComponent();
            groupForm = new GroupForm(this);
            ContentPlace.Content = studentForm;
            
        }
        private void Toggle_Button_Checked(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text = "CM";
        }
        private void Toggle_Button_Unchecked(object sender, RoutedEventArgs e)
        {
            MainTextBlock.Text = "COOLMANAGER";
        }
        private void LeftPanelB_Click(object sender, RoutedEventArgs e)
        {
            String TextBlockText;
            foreach (var child in ((sender as Button).Content as StackPanel).Children)
            {
                if (child.GetType().ToString() == "System.Windows.Controls.TextBlock")

                {
                    TextBlockText = (((TextBlock)child).Text).ToString();

                    //left panel button treatment 
                    switch (TextBlockText)
                    {
                        case "Студенты":
                            ContPlace.Content = studentForm;
                            break;
                        case "Преподаватели":
                            ContPlace.Content = teacherForm;
                            break;
                    
                        case "Группы":
                            ContPlace.Content = groupForm;
                            break;
                   
                        case "Лиды":
                            ContPlace.Content = lidTab;
                            break;
                        case "Поступления и счета":
                            ContPlace.Content = financeTab;
                            break;
                        case "Должники":
                            ContPlace.Content = debtorTab;
                            break;
                        case "Статистика":
                            ContPlace.Content = statistic;
                            break;
                    }
                }
            }     
        }
        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserNameTB_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string sMessageBoxText = "Вы действительно хотите выйти из аккаунта?";
            string sCaption = "Выход";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:

                    break;

            }
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
