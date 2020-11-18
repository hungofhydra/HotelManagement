using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace HotelManagement
{

    //Ket noi den co so du lieu (MySql)
    class Connect
    { 
        private MySqlConnection connection = new MySqlConnection(
            "datasource=localhost;port=3306;username=root;database=hotel_db");

        //Return connection
        public MySqlConnection getConnection()
        {
            return connection;
        }

        //Mo connection
        public void openConnection()
        {
            connection.Open();
        }

        //Dong connection
        public void closeConnection()
        {
            connection.Close();
        }


    }
}
