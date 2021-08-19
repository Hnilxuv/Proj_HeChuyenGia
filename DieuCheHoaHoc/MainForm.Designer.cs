namespace DieuCheHoaHoc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnDieuChe = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblCauHinh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDieuChe
            // 
            this.btnDieuChe.BackColor = System.Drawing.SystemColors.Control;
            this.btnDieuChe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDieuChe.Image = ((System.Drawing.Image)(resources.GetObject("btnDieuChe.Image")));
            this.btnDieuChe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDieuChe.Location = new System.Drawing.Point(283, 186);
            this.btnDieuChe.Name = "btnDieuChe";
            this.btnDieuChe.Size = new System.Drawing.Size(434, 50);
            this.btnDieuChe.TabIndex = 0;
            this.btnDieuChe.Text = "Điều chế";
            this.btnDieuChe.UseVisualStyleBackColor = false;
            this.btnDieuChe.Click += new System.EventHandler(this.btnDieuChe_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.Control;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(283, 266);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(434, 50);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm chất hóa học/ phản ứng   ";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.Location = new System.Drawing.Point(153, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(714, 46);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Hệ chuyên gia điều chế chất hóa học";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(283, 346);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(434, 50);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Hướng dẫn sử dụng";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblCauHinh
            // 
            this.lblCauHinh.AutoSize = true;
            this.lblCauHinh.BackColor = System.Drawing.SystemColors.Control;
            this.lblCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHinh.ForeColor = System.Drawing.Color.Black;
            this.lblCauHinh.Location = new System.Drawing.Point(285, 425);
            this.lblCauHinh.Name = "lblCauHinh";
            this.lblCauHinh.Size = new System.Drawing.Size(126, 20);
            this.lblCauHinh.TabIndex = 6;
            this.lblCauHinh.Text = "Chọn tệp tri thức";
            this.lblCauHinh.Click += new System.EventHandler(this.lblCauHinh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1015, 618);
            this.Controls.Add(this.lblCauHinh);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDieuChe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Trang chủ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDieuChe;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblCauHinh;
    }
}