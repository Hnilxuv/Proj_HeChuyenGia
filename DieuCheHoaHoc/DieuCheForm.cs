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
    public partial class DieuCheForm : Form
    {
        private DataTriThuc data;
        private MotoSuyDien moToSuyDien;
        private List<ChatHoaHoc> duocChon;

        public DieuCheForm() {
            InitializeComponent();
        }

        private void DieuCheForm_Load(object sender, EventArgs e) {
            data = new DataTriThuc();
            moToSuyDien = new MotoSuyDien(data);
            duocChon = data.GetChatHoaHocs();
            lbxSavedChemical.DataSource = duocChon;
            initCurChemical();
        }

        private void initCurChemical() {
            lbxCurChemical.Items.Add("H2O");
            lbxCurChemical.Items.Add("O2");
        }

        private void btnSolve_Click(object sender, EventArgs e) {
            HashSet<ChatHoaHoc> chatCo = new HashSet<ChatHoaHoc>();
            foreach (var item in lbxCurChemical.Items) {
                chatCo.Add(new ChatHoaHoc(item.ToString()));
            }
            ChatHoaHoc chatCan = new ChatHoaHoc(txtNeed.Text);

            Program.res = moToSuyDien.suyDien(chatCo, chatCan);

            KetQua kq = new KetQua();
            kq.Show();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void DieuCheForm_FormClosing(object sender, FormClosingEventArgs e) {
            Program.main.Show();
        }

        private void btnDel_Click(object sender, EventArgs e) {
            if (lbxCurChemical.SelectedItem != null) {
                lbxCurChemical.Items.Remove(lbxCurChemical.SelectedItem);
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e) {
            lbxCurChemical.Items.Clear();
            initCurChemical();
        }

        private void btnGet_Click(object sender, EventArgs e) {
            if (lbxSavedChemical.SelectedItem != null) {
                lbxCurChemical.Items.Add(lbxSavedChemical.SelectedItem);
            }
        }

        private void btnSet_Click(object sender, EventArgs e) {
            if (lbxSavedChemical.SelectedItem != null) {
                txtNeed.Text = lbxSavedChemical.SelectedItem.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            string text = txtSearch.Text;
            List<ChatHoaHoc> selected = new List<ChatHoaHoc>();
            foreach (ChatHoaHoc chh in duocChon) {
                if (chh.ToString().ToLower().Contains(text.ToLower())) {
                    selected.Add(chh);
                }
            }
            lbxSavedChemical.DataSource = selected;
        }

        private void button5_Click(object sender, EventArgs e)
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