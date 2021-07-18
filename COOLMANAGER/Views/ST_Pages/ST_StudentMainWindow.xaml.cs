using System.Windows;

namespace COOLMANAGER.Views
{
    /// <summary>
    /// Interaction logic for ST_StudentMainWindow.xaml
    /// </summary>
    public partial class ST_StudentMainWindow : Window
    {

        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public ST_StudentMainWindow()
        {

            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTextBlock.Text = StudentName;
            ST_Pages.GroupView groupView = new ST_Pages.GroupView(this);
            groupView.StudentGoupId = this.StudentId;
            ContentHolderFrame.Content = groupView;
        }



        private void NameTextBlock_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
