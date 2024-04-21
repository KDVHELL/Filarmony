using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Filarmony
{
    internal class DatabaseConnection
    {
        MySqlConnection conn;
        MySqlDataReader reader;
        public DatabaseConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "filarmonia";
            string username = "root";
            string password = "";

            string connStr = $"server={host};user={username};database={database};password={password}";
            conn = new MySqlConnection(connStr);
        }

        /// <summary>
        /// Чтение результата запроса из таблицы
        /// </summary>
        /// <param name="sqlQuery">Запрос SQl в string</param>
        /// <returns></returns>
        public MySqlDataReader data(string sqlQuery)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlQuery, conn);

                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show($"База данных недоступна!\n{e.Message}");
            }
            return reader;

        }

        public void close()
        {
            reader.Close();
            conn.Close();
        }
    }
}
