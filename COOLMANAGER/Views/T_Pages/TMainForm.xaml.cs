using COOLMANAGER.Views.T_Pages.TGroupTabs;
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

namespace COOLMANAGER.Views.T_Pages
{
    /// <summary>
    /// Interaction logic for TMainForm.xaml
    /// </summary>
    public partial class TMainForm : Window
    {
        GroupChooseTab group;
        int TeacherId;
        public TMainForm(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            group = new GroupChooseTab(TeacherId, this);

        }
      
        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TContentPlace.Content = group;
        }

        private void NameTextBlock_MouseUp(object sender, MouseButtonEventArgs e)
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
    }
}
