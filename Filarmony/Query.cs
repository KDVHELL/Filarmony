using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Filarmony
{
    internal class Query
    {
        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader Upload(string query)
        {
            DatabaseConnection upload = new DatabaseConnection();
            return upload.data(query);
        }
    }
}
