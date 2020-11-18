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
    class Reservation
    {
        Connect conn = new Connect();

        //hien thi
        public DataTable getReserv()
        {
            MySqlCommand command = new MySqlCommand("Select * From reservations", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        //them
        public bool addReserv(int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "INSERT INTO `reservations`(`roomnumber`, `clientid`, `datein`, `dateout`) " +
                "VALUES (@rnm,@cid,@din,@dout)";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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

        //edit
        public bool editReserv(int reservID, int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "UPDATE `reservations` " +
                "SET `roomnumber`=@rnm,`clientid`=@cid,`datein`=@din, `dateout`=@dout WHERE `reservid` = @rvid";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservID;
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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


        //delete
        public bool removeReserv(int rsv_id)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "Delete From `reservations` Where `reservid` = @rvid";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = rsv_id;

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
