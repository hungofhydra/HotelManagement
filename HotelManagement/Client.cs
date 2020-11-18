using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.Versioning;

namespace HotelManagement
{
    //class chiu trach nhiem cho viec : them,sua,xoa,lay thong tin khach hang tu MySQL
    class Client
    {
        Connect conn = new Connect();


        //nhap khach hang
        public bool addClient(string firstName, string lastName,
            string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "INSERT INTO `clients`(`first_name`, `last_name`, `phone`, `country`) " +
                "VALUES (@fnm,@lnm,@phn,@cnt)";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

            conn.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }

            
        }


        //xuat thong tin khach hang
        public DataTable getClient()
        {
            MySqlCommand command = new MySqlCommand("Select * From clients",conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            return table;
        }


        //chinh sua thong tin khach hang
        public bool editClient(int id,string firstName, string lastName,
          string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "UPDATE `clients` " +
                "SET `first_name`=@fnm,`last_name`=@lnm,`phone`=@phn,`country`=@cnt " +
                "WHERE `id` = @cid";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }


        }

        //xoa thong tin khach hang
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "Delete From `clients` Where `id` = @cid";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }

        }
    }
}
