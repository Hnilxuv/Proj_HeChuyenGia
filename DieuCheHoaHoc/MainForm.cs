using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DieuCheHoaHoc
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        private bool checkFileTriThuc() {
            if (DataTriThuc.triThucPath == null || (!File.Exists(DataTriThuc.triThucPath))) {
                return false;
            }
            return true;
        }

        private void cauHinhFileTriThuc() {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "Chọn tệp chứa tri thức";
            openDlg.InitialDirectory = @"C:\";
            openDlg.Filter = "File văn bản (*.txt) | *.txt";

            if (openDlg.ShowDialog() == DialogResult.OK) {
                DataTriThuc.triThucPath = openDlg.FileName;
            }
        }

        private void btnDieuChe_Click(object sender, EventArgs e) {
            if (checkFileTriThuc()) {
                DieuCheForm dieuChe = new DieuCheForm();
                this.Hide();
                dieuChe.Show();
            }
            else {
                MessageBox.Show("Cần chọn tệp chứa tri thức trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cauHinhFileTriThuc();
            }
        }

        private void btnThem_Click(object sender, EventArgs e) {
            if (checkFileTriThuc()) {
                ThemForm them = new ThemForm();
                this.Hide();
                them.Show();
            }
            else {
                MessageBox.Show("Cần chọn tệp chứa tri thức trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cauHinhFileTriThuc();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e) {
            TroGiupForm help = new TroGiupForm();
            help.Show();
        }

        private void lblCauHinh_Click(object sender, EventArgs e) {
            cauHinhFileTriThuc();
        }
    }
}