using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DieuCheHoaHoc
{
    public partial class KetQua : Form
    {
        public KetQua() {
            InitializeComponent();
        }

        private void KetQua_Load(object sender, EventArgs e) {
            int n = Program.res.Count;
            if (n == 0) {
                lblThongBao.ForeColor = Color.Red;
                lblThongBao.Text = "Không thể điều chế!";
                tlpA.ColumnCount = 1;
                lbxKetQua.Visible = false;
            }
            else {
                lblThongBao.ForeColor = Color.Green;
                lblThongBao.Text = "Cần " + n + " phản ứng để điều chế như sau:";
                lbxKetQua.DataSource = Program.res;
            }
        }

        private void lbxKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}