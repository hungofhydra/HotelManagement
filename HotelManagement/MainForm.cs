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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
        private void manageClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientForm manageCF = new ManageClientForm();
            manageCF.ShowDialog();
        }

        private void manageRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoomForm manageRF = new ManageRoomForm();
            manageRF.ShowDialog();
        }

        private void manageReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReservationForm manageRSVF = new ManageReservationForm();
            manageRSVF.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
