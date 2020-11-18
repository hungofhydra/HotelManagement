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
    class Room
    {
        Connect conn = new Connect();


        //hien thi loại phong trong combobox
        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("Select * From rooms_category", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        //hien thi danh sach phong theo loai phong
        public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("Select * From rooms Where `type` = @typ and `free` = 'YES'", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@typ", MySqlDbType.Int32).Value = type;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        //lay kieu cua phong bang room number
        public int getRoomType(int number)
        {
            MySqlCommand command = new MySqlCommand("Select `type` From `rooms` Where `number` = @num", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        //chinh phong thanh KHONG khi da co dat phong
        public bool setRoomFree(int roomnumber, string yesOrNo)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "UPDATE `rooms` SET `free`=@yes_no WHERE `number`= @num";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = roomnumber;
            command.Parameters.Add("@yes_no", MySqlDbType.VarChar).Value = yesOrNo;

            conn.openConnection();

            if (command.ExecuteNonQuery() >= 1)
            {
                return true;
                conn.closeConnection();
            }
            else
            {
                return false;
                conn.closeConnection();
            }
            
        }

        //them phong
        public bool addRoom(int number, int type,
            string phone, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "INSERT INTO `rooms`(`number`, `type`, `phone`, `free`) " +
                "VALUES (@num,@tp,@phn,@fr)";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

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

        //hien thi phong
        public DataTable getRoom()
        {
            MySqlCommand command = new MySqlCommand("Select * From rooms", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        //edit phong
        public bool editRoom(int number, int type,
            string phone, string free)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "UPDATE `rooms` " +
                "SET `type`=@tp,`phone`=@phn,`free`=@fr WHERE `number` = @num";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

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


        //xoa phong
        public bool removeRoom(int number)
        {
            MySqlCommand command = new MySqlCommand();
            string query = "Delete From `rooms` Where `number` = @num";

            command.Connection = conn.getConnection();
            command.CommandText = query;

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

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
