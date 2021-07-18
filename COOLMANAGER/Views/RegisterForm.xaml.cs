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
using System.Windows.Shapes;

namespace COOLMANAGER.Views
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        DB db = new DB();
        LoginForm login = new LoginForm();

        public RegisterForm()
        {
            InitializeComponent();
            WarningLabel.Visibility = Visibility.Hidden;  
        }

        private void NameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBlock.Text == "Введите ваше имя")
            {
                NameTextBlock.Text = "";
            }
        }

        private void NameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBlock.Text == "")
            {
                NameTextBlock.Text = "Введите ваше имя";
            }
        }
        private void SurnameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBlock.Text == "Введите вашу фамилию")
            {
                SurnameTextBlock.Text = "";
            }
        }

        private void SurnameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBlock.Text == "")
            {
                SurnameTextBlock.Text = "Введите вашу фамилию";
            }
        }
        private void LastnameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LastnameTextBlock.Text == "Введите ваше отчество")
            {
                LastnameTextBlock.Text = "";
            }
        }
        private void LastnameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LastnameTextBlock.Text == "")
            {
                LastnameTextBlock.Text = "Введите ваше отчество";
            }
        }

        private void LoginTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if(LoginTextBlock.Text == "Введите ваш логин")
            {
                LoginTextBlock.Text = "";
            }
        }

        private void LoginTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBlock.Text == "")
            {
                LoginTextBlock.Text = "Введите ваш логин";
            }
        }

        private void PasswordTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBlock.Password == "Введите ваш пароль")
            {
                PasswordTextBlock.Password = "";
            }
        }

        private void PasswordTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBlock.Password == "")
            {
                PasswordTextBlock.Password = "Введите ваш пароль";
            }
        }

        private void RepeatPaswordTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if(RepeatPaswordTextBlock.Password == "Повторите пароль")
            {
                RepeatPaswordTextBlock.Password = "";
            }
        }

        private void RepeatPaswordTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPaswordTextBlock.Password == "")
            {
                RepeatPaswordTextBlock.Password = "Повторите пароль";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            WarningLabel.Visibility = Visibility.Hidden;
            
            if(NameTextBlock.Text == "Введите ваше имя" || 
                SurnameTextBlock.Text == "Введите вашу фамилию" || 
                LoginTextBlock.Text == "Введите ваш логин" ||
                PasswordTextBlock.Password == "Введите ваш пароль" ||
                RepeatPaswordTextBlock.Password == "Повторите пароль" ||
                PostCB.SelectedItem.ToString() == "Выберите ваш статус")
            {
                WarningLabel.Text = "Заполните все поля для регистрации";
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            if(PasswordTextBlock.Password != RepeatPaswordTextBlock.Password)
            {
                WarningLabel.Text = "Пароли не соответствуют друг другу";
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            if (isUserExists())
            {
                return;
            }
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`, `lastname`, `id_post`) " +
                "VALUES (@login, @pass, @name, @surname, @lastname, @post)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginTextBlock.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswordTextBlock.Password;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBlock.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBlock.Text;

            if(LastnameTextBlock.Text == "Введите ваше отчество")
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = "";
            }
            else
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = LastnameTextBlock.Text;
            }
            if (PostCB.Text == "Администратор")
            {
                command.Parameters.Add("@post", MySqlDbType.Int32).Value = 5;
            }
            else if(PostCB.Text == "Преподаватель")
            {
                command.Parameters.Add("@post", MySqlDbType.Int32).Value = 3;
            }
            else if(PostCB.Text == "Ученик")
            {
                command.Parameters.Add("@post", MySqlDbType.Int32).Value = 4;
            }

            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                if(PostCB.Text == "Ученик")
                {
                    addStudent();
                }    
                else if (PostCB.Text == "Преподаватель")
                {
                    addTeacher();
                }
                MessageBox.Show("Аккаунт успешно зарегистрирован");
                login.Show();
                this.Close();
            }
            db.closeConnection();
        }

        private void ReturnToLoginButton_Click(object sender, RoutedEventArgs e)
        { 
            login.Show();
            this.Close();
        }

        //Метод для определения есть ли такой пользователь
        public Boolean isUserExists()
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginTextBlock.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                WarningLabel.Text = "*такой пользователь уже зарегистрирован";
                WarningLabel.Visibility = Visibility.Visible;
                return true;
            }
            else
            {
                return false;
            }
        }    
        public void addStudent()
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `students` (`name`, `surname`, `lastname`, `reg_date`, `id_user`) VALUES (@name, @surname, @lastname, @reg_date , @id_user)", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBlock.Text ;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBlock.Text;
            if (LastnameTextBlock.Text == "Введите ваше отчество")
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = "";
            }
            else
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = LastnameTextBlock.Text;
            }
            command.Parameters.Add("@reg_date", MySqlDbType.Date).Value = DateTime.Today;
            command.Parameters.Add("@id_user", MySqlDbType.Int64).Value = getID(LoginTextBlock.Text);
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }   
        public void addTeacher()
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `teachers` ( `date_of_registration`, `id_user`) VALUES (@date_of_registration, @id_user)", db.getConnection());
            command.Parameters.Add("@date_of_registration", MySqlDbType.Date).Value = DateTime.Today;
            command.Parameters.Add("@id_user", MySqlDbType.Int64).Value = getID(LoginTextBlock.Text);
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
        public int getID(string login)
        {
            MySqlCommand command = new MySqlCommand("SELECT id_user FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            db.openConnection();
            int user_id = (int)command.ExecuteScalar();
            db.closeConnection();
            return user_id;
        }
        
    }
}
