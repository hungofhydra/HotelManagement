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
    public partial class ManageRoomForm : Form
    {
       
        Room room = new Room();
        public ManageRoomForm()
        {
            InitializeComponent();
        }

        private void ManageRoomForm_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";
            dataGridView1.DataSource = room.getRoom();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string free = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (free.Equals("YES"))
            {
                radioButtonYes.Checked = true;
            }
            else if (free.Equals("NO"))
            {
                radioButtonNo.Checked = true;
            }
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {

            string free = "";
            string phone = textBoxPhone.Text;
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());

            if (radioButtonYes.Checked)
                free = "YES";
            else if (radioButtonNo.Checked)
                free = "NO";
            try
            {
               
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (number.ToString().Trim().Equals("") || type.ToString().Trim().Equals("") || phone.Trim().Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng", "Thêm phòng",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (room.addRoom(number, type, phone, free) == true)
                    {
                        MessageBox.Show("Thêm phòng thành công", "Thêm phòng",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = room.getRoom();
                        buttonClearRoom.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Thêm phòng thất bại", "Thêm phòng",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi số phòng", "Lỗi ID",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }


        private void buttonEditRoom_Click(object sender, EventArgs e)
        {

            int type = Convert.ToInt32(comboBoxRoomType.SelectedIndex.ToString());
            string phone = textBoxPhone.Text;
            string free = "";

            try
            {
                
                int number = Convert.ToInt32(textBoxNumber.Text);
                if (radioButtonYes.Checked)
                    free = "YES";
                else if (radioButtonNo.Checked)
                    free = "NO";

                if (room.editRoom(number, type, phone, free) == true)
                {
                    MessageBox.Show("Chỉnh sửa phòng thành công", "Sửa phòng",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = room.getRoom();
                    buttonClearRoom.PerformClick();
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa phòng thất bại", "Sửa phòng",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Vui lòng chọn một phòng", "Lỗi ID",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void buttonRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(textBoxNumber.Text);

                if (room.removeRoom(number) == true)
                {
                    MessageBox.Show("Xoá phòng thành công", "Xoá phòng",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = room.getRoom();
                    buttonClearRoom.PerformClick();
                }
                else
                {
                    MessageBox.Show("Xoá phòng thất bại", "Xoá phòng",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hãy chọn một phòng", "Lỗi ID",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void buttonClearRoom_Click(object sender, EventArgs e)
        {
            textBoxNumber.Text = "";
            comboBoxRoomType.SelectedIndex = 0;
            textBoxPhone.Text = "";
            radioButtonYes.Checked = true;
        }
    }
}
