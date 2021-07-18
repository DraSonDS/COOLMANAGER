using COOLMANAGER.Models;
using COOLMANAGER.ViewModels;
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

namespace COOLMANAGER.Views.A_Pages.TeacherTabs
{
    /// <summary>
    /// Interaction logic for AddTeacherForm.xaml
    /// </summary>
    public partial class AddTeacherForm : Window
    {
        DB db = new DB();
        List<Subject> subjects = new List<Subject>();
        SubjectViewModel fsubjects = new SubjectViewModel();
        int teacherID;
        bool registration;
        public AddTeacherForm()
        {
            InitializeComponent();
            subjects = fsubjects.fillSubject();
            SubjectTB.ItemsSource = subjects.Select(w => w.name_subject).ToList();
            WarningLabel.Visibility = Visibility.Hidden;
            registration = true;

        }
        public AddTeacherForm(int teacherID)
        {
            InitializeComponent();
            this.teacherID = teacherID;
            subjects = fsubjects.fillSubject();
            SubjectTB.ItemsSource = new string[] { "Unity3D", "Подготовка к ЕГЭ", "Фотошоп", "Изучение Python","Компьютерная грамотность", "Видеомонтаж" };
            //SubjectTB.DisplayMemberPath = "name_subject";
            WarningLabel.Visibility = Visibility.Hidden;
            MainLabel.Text = "Редактирование преподавателя";
            RegisterButton.Content = "Редактировать";
            RegisterButton.Width = 140;
            registration = false;


            foreach (DataRow row in db.commandTable("SELECT * FROM teachers as t " +
                "JOIN users as u ON t.id_user = u.id_user WHERE id_teacher = " + teacherID + "").Rows)
            {
                NameTextBlock.Text = Convert.ToString(row["name"]);
                SurnameTextBlock.Text = Convert.ToString(row["surname"]);

               if(Convert.ToString(row["lastname"]) == "")
                {
                    return;
                }
                else
                {
                    LastnameTextBlock.Text = Convert.ToString(row["lastname"]);
                }
                
                
                LoginTextBlock.Text = Convert.ToString(row["login"]);
                PasswordTextBlock.Password = "Введите пароль";
                RepeatPaswordTextBlock.Password = "Повторите пароль";

                foreach (DataRow row2 in db.commandTable("SELECT * FROM subjects_and_teachers as s_t " +
                    "JOIN teachers as t ON t.id_teacher = s_t.id_teacher " +
                    "JOIN subjects as s ON s_t.id_subject = s.id_subject " +
                    "WHERE t.id_teacher = " + teacherID + "").Rows)
                {
                    //foreach (var Subject in subjects.Where(x => x.name_subject == row2["name_subject"].ToString()))
                    //{
                    //        SubjectTB.SelectedItem = Subject;      
                    //} 
                    //int i = 0;
                    //foreach (ComboBoxItem s in SubjectTB.Items)
                    //{
                    //    if(s.Content.ToString() == row2["name_subject"].ToString())
                    //        SubjectTB.SelectedItem = s;
                    //    i++;
                    //}
                    
                    SubjectTB.SelectedItem = row2["name_subject"].ToString();
                }   
            }
        }

        private void NameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBlock.Text == "Введите имя")
            {
                NameTextBlock.Text = "";
            }
        }

        private void NameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBlock.Text == "")
            {
                NameTextBlock.Text = "Введите имя";
            }
        }
        private void SurnameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBlock.Text == "Введите фамилию")
            {
                SurnameTextBlock.Text = "";
            }
        }

        private void SurnameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SurnameTextBlock.Text == "")
            {
                SurnameTextBlock.Text = "Введите фамилию";
            }
        }
        private void LastnameTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LastnameTextBlock.Text == "Введите отчество")
            {
                LastnameTextBlock.Text = "";
            }
        }
        private void LastnameTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LastnameTextBlock.Text == "")
            {
                LastnameTextBlock.Text = "Введите отчество";
            }
        }

        private void LoginTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBlock.Text == "Введите логин")
            {
                LoginTextBlock.Text = "";
            }
        }

        private void LoginTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBlock.Text == "")
            {
                LoginTextBlock.Text = "Введите логин";
            }
        }

        private void PasswordTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBlock.Password == "Введите пароль")
            {
                PasswordTextBlock.Password = "";
            }
        }

        private void PasswordTextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBlock.Password == "")
            {
                PasswordTextBlock.Password = "Введите пароль";
            }
        }

        private void RepeatPaswordTextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPaswordTextBlock.Password == "Повторите пароль")
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
            if (registration)
                Reg();
            else
                Edit();

        }

        private void ReturnToLoginButton_Click(object sender, RoutedEventArgs e)
        {  
            this.Close();
        }

        public void addTeacher()
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `teachers` ( `date_of_registration`, `id_user`) VALUES (@date_of_registration, @id_user)", db.getConnection());
            command.Parameters.Add("@date_of_registration", MySqlDbType.Date).Value = DateTime.Today;
            command.Parameters.Add("@id_user", MySqlDbType.Int64).Value = getID(LoginTextBlock.Text);
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();


            MySqlCommand command1 = new MySqlCommand("INSERT INTO `subjects_and_teachers` ( `id_subject`, `id_teacher`) " +
                "VALUES (@id_subject, @id_teacher)", db.getConnection());

            command1.Parameters.Add("@id_subject", MySqlDbType.Int64).Value = getIDsubject(SubjectTB.SelectedItem.ToString());
            command1.Parameters.Add("@id_teacher", MySqlDbType.Int64).Value = getIDteacher();
           
            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
            {
               
            }
            db.closeConnection();
        }

        void Reg()
        {
            WarningLabel.Visibility = Visibility.Hidden;

            if (NameTextBlock.Text == "Введите имя" ||
                SurnameTextBlock.Text == "Введите фамилию" ||
                LoginTextBlock.Text == "Введите логин" ||
                PasswordTextBlock.Password == "Введите пароль" ||
                RepeatPaswordTextBlock.Password == "Повторите пароль" ||
                SubjectTB.SelectedItem.ToString() is null)
            {
                WarningLabel.Text = "Заполните все поля для регистрации";
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            if (PasswordTextBlock.Password != RepeatPaswordTextBlock.Password)
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

            if (LastnameTextBlock.Text == "Введите ваше отчество")
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = "";
            }
            else
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = LastnameTextBlock.Text;
            }
            command.Parameters.Add("@post", MySqlDbType.Int32).Value = 3;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Преподаватель успешно зарегистрирован");
                addTeacher(); 
                this.Close();
            }
            db.closeConnection();
        }

        void Edit()
        {
            WarningLabel.Visibility = Visibility.Hidden;

            if (NameTextBlock.Text == "Введите имя" ||
                SurnameTextBlock.Text == "Введите фамилию" ||
                LoginTextBlock.Text == "Введите логин" ||
                PasswordTextBlock.Password == "Введите пароль" ||
                RepeatPaswordTextBlock.Password == "Повторите пароль" ||
                SubjectTB.SelectedItem.ToString() is null)
            {
                WarningLabel.Text = "Заполните все поля для регистрации";
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            if (PasswordTextBlock.Password != RepeatPaswordTextBlock.Password)
            {
                WarningLabel.Text = "Пароли не соответствуют друг другу";
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }
            MySqlCommand commandupdate = new MySqlCommand("UPDATE`users` " +
                "SET " +
                "`login` = @login, " +
                "`pass` = @pass, " +
                "`name` = @name, " +
                "`surname` = @surname, " +
                "`lastname` = @lastname, " +
                "`id_post` = @post " +
                "WHERE id_user = "+ getIDUser() + "", db.getConnection());

            commandupdate.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginTextBlock.Text;
            commandupdate.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswordTextBlock.Password;
            commandupdate.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBlock.Text;
            commandupdate.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBlock.Text;

            if (LastnameTextBlock.Text == "Введите ваше отчество")
            {
                commandupdate.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = "";
            }
            else
            {
                commandupdate.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = LastnameTextBlock.Text;
            }
            commandupdate.Parameters.Add("@post", MySqlDbType.Int32).Value = 3;

            db.openConnection();
            if (commandupdate.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Информация о преподавателе изменена");
            }
            db.closeConnection();

            MySqlCommand command1 = new MySqlCommand("UPDATE `subjects_and_teachers` SET " +
                "`id_subject` = @id_subject " +
                "WHERE id_teacher = "+ teacherID +"", db.getConnection());

            command1.Parameters.Add("@id_subject", MySqlDbType.Int64).Value = getIDsubject(SubjectTB.SelectedItem.ToString());

            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
            {
                
                this.Close();
            }
            db.closeConnection();

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

        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        public int getIDteacher()
        {
            MySqlCommand command = new MySqlCommand("SELECT id_teacher FROM `teachers` WHERE `id_user` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.Int32).Value = getID(LoginTextBlock.Text);
            db.openConnection();
            int teacher_id = (int)command.ExecuteScalar();
            db.closeConnection();
            return teacher_id;
        }  
        public int getIDUser()
        {
            MySqlCommand command = new MySqlCommand("SELECT id_user FROM `teachers` WHERE `id_teacher` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.Int32).Value = teacherID;
            db.openConnection();
            int teacher_id = (int)command.ExecuteScalar();
            db.closeConnection();
            return teacher_id;
        } 
        public int getIDsubject(string subject_name)
        {
            MySqlCommand command = new MySqlCommand("SELECT id_subject FROM `subjects` WHERE `name_subject` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = subject_name;
            db.openConnection();
            int subject_id = (int)command.ExecuteScalar();
            db.closeConnection();
            return subject_id;
        }

        private void SubjectTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
