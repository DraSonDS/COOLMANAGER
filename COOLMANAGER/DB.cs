using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace COOLMANAGER
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root;password=root;database=coolschool");
      
        public DataTable commandTable(string commandText)
        {
            try
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand(commandText, getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                return table;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при работе с базой данных. Просьба повторить попытку позже ");
                DataTable table = new DataTable();
                return table;
            }
            
        }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
