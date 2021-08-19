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
    public partial class ThemForm : Form
    {
        private List<PhanUng> phanUngs;
        private PhanUng pu;
        private Stack<int> delList;

        public ThemForm() {
            InitializeComponent();
        }

        private void ThemForm_FormClosing(object sender, FormClosingEventArgs e) {
            // nhat ra nhung phan ung co
            List<PhanUng> selected = new List<PhanUng>();
            for (int i = 0; i < phanUngs.Count; i++) {
                if (!delList.Contains(i + 1)) {
                    selected.Add(phanUngs[i]);
                }
            }

            //viet lai file
            DataTriThuc.toFile(selected);

            //mo lai main
            Program.main.Show();
        }

        private void ThemForm_Load(object sender, EventArgs e) {
            
            btnThem.Enabled = false;
            lblChuY.ForeColor = Color.Red;
            lblChuY.Text = "Chú ý: Vui lòng xuống dòng hoặc cách sau mỗi chất hóa học" +
                "\nKhông thêm dấu phẩy, viết các chất đúng cách " +
                "\nNếu không có điều kiện thì bỏ trống điều kiện" +
                "\nBấm vào ô xem trước trước khi thêm để kiểm tra trước khi thêm phản ứng";

            DataTriThuc data = new DataTriThuc();
            phanUngs = data.GetPhanUngs();
            delList = new Stack<int>();

            capNhatCacPhanUng();
        }

        private void capNhatCacPhanUng() {
            lbxPhanUng.Items.Clear();
            int n = phanUngs.Count;
            for (int i = 0; i < n; i++) {
                if (!delList.Contains(i + 1)) {
                    lbxPhanUng.Items.Add((i + 1) + " _ " + phanUngs[i].ToString());
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e) {
            if (!phanUngs.Contains(pu)) {
                phanUngs.Add(pu);
                capNhatCacPhanUng();
            }
            else {
                MessageBox.Show("Phản ứng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e) {
            if (lbxPhanUng.SelectedItem != null) {
                DialogResult forSure = MessageBox.Show("Bạn có muốn xóa " + lbxPhanUng.SelectedItem.ToString(), "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (forSure == DialogResult.OK) {
                    int i = int.Parse(lbxPhanUng.SelectedItem.ToString().Split(' ')[0]);
                    delList.Push(i);
                    capNhatCacPhanUng();
                    //Console.WriteLine("Xoa: " + i);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            lbxPhanUng.Items.Clear();
            string text = txtSearch.Text;
            int n = phanUngs.Count;
            for (int i = 0; i < n; i++) {
                if (!delList.Contains(i) && phanUngs[i].ToString().ToLower().Contains(text.ToLower())) {
                    lbxPhanUng.Items.Add((i + 1) + " _ " + phanUngs[i].ToString());
                }
            }
        }

        private void txtXemTruoc_Enter(object sender, EventArgs e) {
            List<ChatHoaHoc> vt = new List<ChatHoaHoc>();
            List<ChatHoaHoc> vp = new List<ChatHoaHoc>();
            string dk = txtDieuKien.Text;
            Console.WriteLine(txtVeTrai.Text);
            string[] st = txtVeTrai.Text.Split();
            foreach (string s in st) {
                Console.WriteLine(s);
                if (s.Length > 0) vt.Add(new ChatHoaHoc(s));
            }
            string[] sp = txtVePhai.Text.Split();
            foreach (string s in sp) {
                if (s.Length > 0) vp.Add(new ChatHoaHoc(s));
            }
            if (vt.Count == 0 || vp.Count == 0) {
                MessageBox.Show("Vui lòng nhập đủ 2 vế của phản ứng");
            }
            else {
                pu = new PhanUng(vt, vp, dk);

                string str = pu.ToString();
                txtXemTruoc.Text = str;
                btnThem.Enabled = true;
            }
        }

        private void btnBoXoa_Click(object sender, EventArgs e) {
            DialogResult forSure = MessageBox.Show("Bạn có muốn bỏ xóa phản ứng vừa xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (forSure == DialogResult.OK) {
                if (delList.Count == 0) {
                    MessageBox.Show("Không còn phản ứng cần hoàn tác!");
                }
                else {
                    delList.Pop();
                    capNhatCacPhanUng();
                }
            }
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