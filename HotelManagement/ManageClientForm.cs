using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class ManageClientForm : Form
    {

        Client client = new Client();
        public ManageClientForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void ManageClientForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClient();
        }

        private void buttonClearClient_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxPhone.Text = "";
            textBoxCountry.Text = "";
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string phone = textBoxPhone.Text;
            string country = textBoxCountry.Text;

            if (firstname.Trim().Equals("") || lastname.Trim().Equals("") || phone.Trim().Equals("") || country.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng trừ ID", "Thêm khách hành",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Boolean addClient = client.addClient(firstname, lastname, phone, country);
                if (addClient == true)
                {

                    MessageBox.Show("Thêm khách hàng mới thành công", "Thêm khách hành",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonClearClient.PerformClick();
                    dataGridView1.DataSource = client.getClient();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại", "Thêm khách hành",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void buttonEditClien_Click(object sender, EventArgs e)
        {
           

            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string phone = textBoxPhone.Text;
                string country = textBoxCountry.Text;

                if (Convert.ToString(id).Equals("") || firstname.Trim().Equals("")
               || lastname.Trim().Equals("") || phone.Trim().Equals("") || country.Trim().Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần cập nhật ", "Cập nhật",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    Boolean editClient = client.editClient(id, firstname, lastname, phone, country);
                    if (editClient == true)
                    {

                        MessageBox.Show("Cập nhật thành công", "Cập nhật",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonClearClient.PerformClick();
                        dataGridView1.DataSource = client.getClient();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Cập nhật",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hãy chọn một khách hàng", "Lỗi ID",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void buttonRemoveClient_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if(client.removeClient(id) == true)
                {
                    MessageBox.Show("Xoá khách hàng thành công", "Xoá khách hành",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = client.getClient();
                    buttonClearClient.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xoá khách hàng thất bại", "Xoá khách hành",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hãy chọn một khách hàng", "Lỗi ID",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}
