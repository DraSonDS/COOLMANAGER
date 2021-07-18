using COOLMANAGER.Views;
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

namespace COOLMANAGER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        DB db = new DB();
        public LoginForm()
        {
            InitializeComponent(); 
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginUser();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void LoginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "Логин")
            {
                LoginTextBox.Text = "";
            }
        }

        private void LoginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "")
            {
                LoginTextBox.Text = "Логин";
            }
        }

        private void PasswordPassBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordPassBox.Password == "Пароль")
            {
                PasswordPassBox.Password = "";
            }
        }

        private void PasswordPassBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordPassBox.Password == "")
            {
                PasswordPassBox.Password = "Пароль";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Close();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginUser()
        {
            String loginUser = LoginTextBox.Text;
            String passwordUser = PasswordPassBox.Password;

            if (db.commandTable("SELECT `login`, `pass`, `id_post` FROM `users` " +
                "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post != '4' AND id_post != '3' ").Rows.Count > 0)
            {
                MainForm mainForm = new MainForm();
                mainForm.UserNameTB.Text = loginUser;
                mainForm.Show();
                this.Close();
            }
            else if (db.commandTable("SELECT `login`, `pass`, `id_post`, `id_user` FROM `users` " +
              "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '3' ").Rows.Count > 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT id_user FROM users " +
                    "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '3' ", db.getConnection());

                MySqlCommand command1 = new MySqlCommand("SELECT concat(`users`.`name`, ' ', `users`.`surname`) FROM `users` " +
                "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '3' ", db.getConnection());

                db.openConnection();
                int teacherId = Convert.ToInt32(command.ExecuteScalar());
                Views.T_Pages.TMainForm teacherForm = new Views.T_Pages.TMainForm(teacherId);
                teacherForm.NameTextBlock.Text = Convert.ToString(command1.ExecuteScalar());
                db.closeConnection();


                teacherForm.Show();
                this.Close();
            }

            else if (db.commandTable("SELECT `login`, `pass`, `id_post`, `students`.`id_student` FROM `users` " +
                "JOIN `students` ON `users`.`id_user` = `students`.`id_user` " +
                "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '4' ").Rows.Count > 0)
            {
                ST_StudentMainWindow studentMainWindow = new ST_StudentMainWindow();

                MySqlCommand command = new MySqlCommand("SELECT `students`.`id_student`, `users`.`name`, `users`.`surname`, `users`.`lastname` FROM `users` " +
                "JOIN `students` ON `users`.`id_user` = `students`.`id_user` " +
                "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '4' ", db.getConnection());

                MySqlCommand command1 = new MySqlCommand("SELECT concat(`users`.`name`, ' ', `users`.`surname`) FROM `users` " +
                "JOIN `students` ON `users`.`id_user` = `students`.`id_user` " +
                "WHERE `login` = '" + loginUser + "' AND `pass` = '" + passwordUser + "' AND id_post = '4' ", db.getConnection());

                db.openConnection();
                studentMainWindow.StudentId = Convert.ToString(command.ExecuteScalar());
                studentMainWindow.StudentName = Convert.ToString(command1.ExecuteScalar());
                db.closeConnection();

                studentMainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }
    }
}
