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

namespace COOLMANAGER.Views.T_Pages
{
    /// <summary>
    /// Interaction logic for StudentAddForm.xaml
    /// </summary>
    public partial class StudentAddForm : Window
    {
        DB db = new DB();
        List<Group> groups = new List<Group>();
        GroupViewModel groupViewModel = new GroupViewModel();
        int studentID;
        bool registate;


        public StudentAddForm()
        {
            InitializeComponent();
            groups = groupViewModel.fillGroupGrid();
            groupCB.ItemsSource = groups.Select(w => w.group_name).ToList();
            WarningLabel.Visibility = Visibility.Hidden;
            registate = true;
        }
        public StudentAddForm(int studentID)
        {
            InitializeComponent();
            registate = false;
            this.studentID = studentID;
            MainLabel.Text = "Редактирование ученика";
            SRegistrateB.Content = "Редактировать";
            groupCB.Visibility = Visibility.Collapsed;
            GroupLabel.Visibility = Visibility.Collapsed;
            SRegistrateB.Width = 120;
            groups = groupViewModel.fillGroupGrid();
            groupCB.ItemsSource = groups.Select(w => w.group_name).ToList();
            WarningLabel.Visibility = Visibility.Hidden;

            foreach (DataRow students in db.commandTable("SELECT * FROM students WHERE id_student = " + studentID + "").Rows)
            {
                name.Text = Convert.ToString(students["name"]);
                surnameame.Text = Convert.ToString(students["surname"]);
                lastname.Text = Convert.ToString(students["lastname"]);
                LBirthDP.SelectedDate = Convert.ToDateTime(students["birth_date"]);

                foreach (var item in advert.Items)
                {
                    if ((item as ComboBoxItem).Content.ToString() == Convert.ToString(students["advert_type"]))
                    {
                        advert.SelectedItem = (item as ComboBoxItem);
                    }
                }
                foreach (var item in type.Items)
                {
                    if ((item as ComboBoxItem).Content.ToString() == Convert.ToString(students["request_type"]))
                    {
                        type.SelectedItem = (item as ComboBoxItem);
                    }
                }
            }
            foreach (DataRow students in db.commandTable("SELECT * FROM contacts WHERE id_student = " + studentID + "").Rows)
            {
                mobile.Text = Convert.ToString(students["phone_number"]);
                email.Text = Convert.ToString(students["email"]);
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "Введите имя")
            {
                name.Text = "";
            }
        }

        private void name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите имя";
            }
        }

        private void surnameame_GotFocus(object sender, RoutedEventArgs e)
        {
            if (surnameame.Text == "Введите фамилию")
            {
                surnameame.Text = "";
            }
        }

        private void surnameame_LostFocus(object sender, RoutedEventArgs e)
        {
            if (surnameame.Text == "")
            {
                name.Text = "Введите фамилию";
            }
        }

        private void lastname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lastname.Text == "Введите отчество")
            {
                lastname.Text = "";
            }
        }

        private void lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (lastname.Text == "")
            {
                lastname.Text = "Введите отчество";
            }
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "Email")
            {
                email.Text = "";
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Email";
            }
        }

        private void mobile_GotFocus(object sender, RoutedEventArgs e)
        {
            if (mobile.Text == "Моб. телефон")
            {
                mobile.Text = "";
            }
        }

        private void mobile_LostFocus(object sender, RoutedEventArgs e)
        {
            if (mobile.Text == "")
            {
                mobile.Text = "Моб. телефон";
            }
        }

        private void SRegistrateB_Click(object sender, RoutedEventArgs e)
        {
            if (registate)
                Registrate();
            else
                Edit();
        }


        void Registrate()
        {
            ComboBoxItem selectedItem0 = (ComboBoxItem)(advert.SelectedValue);
            ComboBoxItem selectedItem1 = (ComboBoxItem)(type.SelectedValue);

            WarningLabel.Visibility = Visibility.Hidden;
            if (name.Text == "Введите имя" || surnameame.Text == "Введите фамилию" || email.Text == "Email" ||
                mobile.Text == "Моб. nелефон" || (string)(selectedItem0.Content) == "Рекламный источник..." ||
                (string)(selectedItem1.Content) == "Тип обращения..." || (string)(groupCB.SelectedItem) == "")
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO `students` (`name`, `surname`, `lastname`, `birth_date`, `reg_date`, `advert_type`, `request_type`, `is_student`) " +
                "VALUES (@name, @surname, @lastname, @birth_date, @reg_date, @advert_type, @request_type, @is_student)", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnameame.Text;

            if (lastname.Text == "Введите отчество")
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname.Text;
            }


            command.Parameters.Add("@birth_date", MySqlDbType.Date).Value = LBirthDP.SelectedDate.Value.Date;
            command.Parameters.Add("@reg_date", MySqlDbType.Date).Value = DateTime.Now;

            ComboBoxItem selectedItem = (ComboBoxItem)(advert.SelectedValue);

            command.Parameters.Add("@advert_type", MySqlDbType.VarChar).Value = (string)(selectedItem.Content);

            selectedItem = (ComboBoxItem)(type.SelectedValue);
            command.Parameters.Add("@request_type", MySqlDbType.VarChar).Value = (string)(selectedItem.Content);
            command.Parameters.Add("@is_student", MySqlDbType.Int32).Value = 1;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }

            int id_student;
            int id_group;

            MySqlCommand command1 = new MySqlCommand("SELECT id_student FROM students WHERE name = @name AND surname = @surname AND " +
                "birth_date = @birth_date", db.getConnection());

            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command1.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnameame.Text;
            command1.Parameters.Add("@birth_date", MySqlDbType.Date).Value = LBirthDP.SelectedDate.Value.Date;

            db.openConnection();
            id_student = Convert.ToInt32(command1.ExecuteScalar());
            db.closeConnection();

            MySqlCommand command4 = new MySqlCommand("SELECT id_group FROM groups WHERE group_name = @group_name", db.getConnection());

            command4.Parameters.Add("@group_name", MySqlDbType.VarChar).Value = (string)(groupCB.SelectedItem);

            db.openConnection();
            id_group = Convert.ToInt32(command4.ExecuteScalar());
            db.closeConnection();

            MySqlCommand command3 = new MySqlCommand("INSERT INTO `groups_and_students` (`id_student`, `id_group`, `date_of_enrollment`) " +
                "VALUES (@id_student, @id_group, @date_of_enrollment)", db.getConnection());

            command3.Parameters.Add("@id_student", MySqlDbType.Int32).Value = id_student;
            command3.Parameters.Add("@id_group", MySqlDbType.Int32).Value = id_group;
            command3.Parameters.Add("@date_of_enrollment", MySqlDbType.Date).Value = DateTime.Now;

            db.openConnection();
            if (command3.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
            }
            db.closeConnection();

            MySqlCommand command2 = new MySqlCommand("INSERT INTO `contacts` (`id_student`, `phone_number`, `email`) " +
                "VALUES (@id_student, @phone_number, @email)", db.getConnection());

            command2.Parameters.Add("@id_student", MySqlDbType.Int32).Value = id_student;
            command2.Parameters.Add("@phone_number", MySqlDbType.Double).Value = Convert.ToDouble(mobile.Text);
            command2.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;

            db.openConnection();
            if (command2.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Ученик успешно зарегистрирован");
                db.closeConnection();
                this.Close();
            }
        }

        void Edit()
        {
            ComboBoxItem selectedItem0 = (ComboBoxItem)(advert.SelectedValue);
            ComboBoxItem selectedItem1 = (ComboBoxItem)(type.SelectedValue);

            if (name.Text == "Введите имя" || surnameame.Text == "Введите фамилию" || email.Text == "Email" ||
                mobile.Text == "Моб. nелефон" || LBirthDP.SelectedDate is null || (string)(selectedItem0.Content) == "Рекламный источник..." ||
                (string)(selectedItem1.Content) == "Тип обращения...")
            {
                WarningLabel.Visibility = Visibility.Visible;
                return;
            }

            MySqlCommand command = new MySqlCommand("UPDATE `students` " +
                "SET name = @name, " +
                "surname = @surname, " +
                "lastname = @lastname, " +
                "birth_date = @birth_date, " +
                "advert_type = @advert_type, " +
                "request_type = @request_type " +
                "WHERE `students`.`id_student` = " + studentID + "; ", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnameame.Text;

            if (lastname.Text == "Введите отчество")
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname.Text;
            }

            command.Parameters.Add("@birth_date", MySqlDbType.Date).Value = LBirthDP.SelectedDate.Value.Date;
            command.Parameters.Add("@reg_date", MySqlDbType.Date).Value = DateTime.Now;

            ComboBoxItem selectedItem = (ComboBoxItem)(advert.SelectedValue);

            command.Parameters.Add("@advert_type", MySqlDbType.VarChar).Value = (string)(selectedItem.Content);

            selectedItem = (ComboBoxItem)(type.SelectedValue);
            command.Parameters.Add("@request_type", MySqlDbType.VarChar).Value = (string)(selectedItem.Content);
            command.Parameters.Add("@is_student", MySqlDbType.Int32).Value = 1;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Информация об ученике изменена");
                db.closeConnection();
            }

                if(db.commandTable("SELECT * from contacts WHERE id_student = "+ studentID +"").Rows.Count == 0)
                {
                    MySqlCommand command3 = new MySqlCommand("INSERT INTO `contacts` (`id_student`,`phone_number`, `email`) " +
               "VALUES (@id_student, @phone_number, @email)", db.getConnection());

                    command3.Parameters.Add("@id_student", MySqlDbType.Int32).Value = studentID;
                    command3.Parameters.Add("@phone_number", MySqlDbType.Double).Value = Convert.ToDouble(mobile.Text);
                    command3.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;

                    db.openConnection();
                    if (command3.ExecuteNonQuery() == 1)
                    {
                        
                        db.closeConnection();
                        this.Close();
                    }
                }
                else
                {
                    MySqlCommand command2 = new MySqlCommand("UPDATE `contacts` " +
                    "SET phone_number = @phone_number, " +
                    "email = @email " +
                    "WHERE `id_student` = @id_student", db.getConnection());
                    command2.Parameters.Add("@id_student", MySqlDbType.Int32).Value = studentID;
                    command2.Parameters.Add("@phone_number", MySqlDbType.Double).Value = Convert.ToDouble(mobile.Text);
                    command2.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;

                    db.openConnection();
                    if (command2.ExecuteNonQuery() == 1)
                    {  
                        db.closeConnection();
                        this.Close();
                    }
                } 

        }

        private void mobile_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        
        private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
    }
}
