using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace COOLMANAGER.Views.ST_Pages.HometaskViews
{
    /// <summary>
    /// Interaction logic for HometaskSendView.xaml
    /// </summary>
    public partial class HometaskSendView : Window
    {
        public int StudentID { get; set; }
        public int HomeworkID { get; set; }
        public string FileNameText { get; set; }
        Byte[] FileData;

        public HometaskSendView()
        {
            InitializeComponent();
        }

        private void CommentTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if(CommentTB.Text == "Введите сюда ваш комментарий. . .")
            {
                CommentTB.Text = "";
            }
        }

        private void CommentTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CommentTB.Text == "")
            {
                CommentTB.Text = "Введите сюда ваш комментарий. . .";
            }
        }
        private void FileAddBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    string Filepath;
                    Filepath = System.IO.Path.GetFullPath(filename);
                    string FileName;
                    FileName = System.IO.Path.GetFileName(filename);
                    FileNameText = FileName;
                    FIleNameTB.Text = FileNameText;

                    // преобразование файла в бинарный код
                    String strBLOBFilePath = Filepath;
                    FileStream fsBLOBFile = new FileStream(strBLOBFilePath, FileMode.Open, FileAccess.Read);
                    Byte[] bytBLOBData = new Byte[fsBLOBFile.Length];
                    FileData = bytBLOBData;
                    fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                    fsBLOBFile.Close();
                }
            }
        }

        private void SentB_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO student_homework(id_homework, id_student ,comment, file_name, file_data) " +
                "VALUES(@id_homework,@id_student, @comment ,@FileName, @BLOBData)", db.getConnection());
            // Загрузка данных на базу данных
            MySqlParameter prm = new MySqlParameter("@BLOBData", MySqlDbType.VarBinary, FileData.Length, ParameterDirection.Input, false,
            0, 0, null, DataRowVersion.Current, FileData);
            cmd.Parameters.Add(prm);
            cmd.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = FileNameText;
            cmd.Parameters.Add("@comment", MySqlDbType.VarChar).Value = CommentTB.Text;
            cmd.Parameters.Add("@id_student", MySqlDbType.Int32).Value = StudentID;
            cmd.Parameters.Add("@id_homework", MySqlDbType.Int32).Value = HomeworkID;
            db.openConnection();
            cmd.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Задание отправлено");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
