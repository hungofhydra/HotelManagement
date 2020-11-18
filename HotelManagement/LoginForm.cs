using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HotelManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            string query = "SELECT * FROM `users` WHERE `username` = @usn AND `password` = @pass";

            command.Connection = conn.getConnection();
            command.CommandText = query;
           

            //them tham so vao command
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;

            //lay du lieu sau khi thuc thi query va luu vao table
            adapter.SelectCommand = command;
            adapter.Fill(table);

            //neu co username va password tuong ung thi dang nhap
            if(table.Rows.Count > 0)
            {
                this.Hide();
                MainForm mForm = new MainForm();
                mForm.Show();
            }
            else
            {
                if (textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập username để đăng nhập", "Username trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                else if (textBoxPassword.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập password để đăng nhập", "Password trống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
