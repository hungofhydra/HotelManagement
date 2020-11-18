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
    public partial class ManageReservationForm : Form
    {
        Room room = new Room();
        Reservation reservation = new Reservation();
        public ManageReservationForm()
        {
           
            InitializeComponent();
        }


        private void ManageReservationForm_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";

            //hien thi phong trong theo kieu phong da chon
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            comboBoxRoomNumber.DataSource = room.roomByType(type);
            comboBoxRoomNumber.DisplayMember = "number";
            comboBoxRoomNumber.ValueMember = "number";

            dataGridView1.DataSource = reservation.getReserv();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxReservID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //lay roomnumber
            int roomnumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            //lay room type trong combobox
            comboBoxRoomType.SelectedValue = room.getRoomType(roomnumber);

            //chon room number tu trong combobox
            comboBoxRoomNumber.SelectedValue = roomnumber;

            textBoxClientID.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            

        }

        private void buttonClearReserv_Click(object sender, EventArgs e)
        {
            textBoxReservID.Text = "";
            textBoxClientID.Text = "";
            comboBoxRoomType.SelectedIndex = 0;
            dateTimePickerIn.Value = DateTime.Now;
            dateTimePickerIn.Value = DateTime.Now;
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
                comboBoxRoomNumber.DataSource = room.roomByType(type);
                comboBoxRoomNumber.DisplayMember = "number";
                comboBoxRoomNumber.ValueMember = "number";
            }
            catch(Exception ex)
            {

            }
        }

        private void buttonAddReserv_Click(object sender, EventArgs e)
        {
            int clientID = Convert.ToInt32(textBoxClientID.Text);
            try
            {
                int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                DateTime dateIn = dateTimePickerIn.Value;
                DateTime dateOut = dateTimePickerOut.Value;

                if(dateIn< DateTime.Now)
                {
                    MessageBox.Show("Ngày checkin phải lớn hơn ngày hôm nay", "Ngày không hợp lẹ",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateOut < DateTime.Now)
                {
                    MessageBox.Show("Ngày checkout phải lớn hơn ngày hôm nay", "Ngày không hợp lệ",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (reservation.addReserv(roomNumber, clientID, dateIn, dateOut) == true)
                    {
                        room.setRoomFree(roomNumber,"NO");
                        MessageBox.Show("Thêm thông tin đặt phòng thành công", "Đặt phòng",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = reservation.getReserv();
                        ManageReservationForm manageRSVF = new ManageReservationForm();
                        this.Hide();
                        manageRSVF.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thông tin đặt phòng thất bại", "Đặt phòng",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không có khách hàng này trong danh sách khách hàng", "Đặt phòng lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                ManageReservationForm manageRSVF = new ManageReservationForm();
                this.Hide();
                manageRSVF.ShowDialog();
            }
            
        
        }

        private void buttonEditReserv_Click(object sender, EventArgs e)
        {


            try
            {
                int rservID = Convert.ToInt32(textBoxReservID.Text);
                int clientID = Convert.ToInt32(textBoxClientID.Text);
                int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                DateTime dateIn = dateTimePickerIn.Value;
                DateTime dateOut = dateTimePickerOut.Value;

                if (dateIn < DateTime.Now)
                {
                    MessageBox.Show("Ngày checkin phải lớn hơn ngày hôm nay", "Ngày không hợp lẹ",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateOut < DateTime.Now)
                {
                    MessageBox.Show("Ngày checkout phải lớn hơn ngày hôm nay", "Ngày không hợp lệ",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {

                    //reserveid
                    if (reservation.editReserv(rservID,roomNumber, clientID, dateIn, dateOut) == true)
                    {
                        room.setRoomFree(roomNumber,"NO");
                        MessageBox.Show("Cập nhật thông tin đặt phòng thành công", "Đặt phòng",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = reservation.getReserv();
                        ManageReservationForm manageRSVF = new ManageReservationForm();
                        this.Hide();
                        manageRSVF.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin đặt phòng thất bại", "Đặt phòng",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Đặt phòng lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                ManageReservationForm manageRSVF = new ManageReservationForm();
                this.Hide();
                manageRSVF.ShowDialog();
            }


        }

        private void buttonRemoveReserv_Click(object sender, EventArgs e)
        {
            try
            {
                int resrveID = Convert.ToInt32(textBoxReservID.Text);
                int roomnumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                if (reservation.removeReserv(resrveID) == true)
                {

                    room.setRoomFree(roomnumber, "YES");
                    MessageBox.Show("Xoá thành công", "Đặt phòng lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = reservation.getReserv();
                    ManageReservationForm manageRSVF = new ManageReservationForm();
                    this.Hide();
                    manageRSVF.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Xoá thất bại", "Đặt phòng lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Chọn một đơn đặt phòng để xoá", "Đặt phòng lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                ManageReservationForm manageRSVF = new ManageReservationForm();
                this.Hide();
                manageRSVF.ShowDialog();
            }
        }
    }
}
