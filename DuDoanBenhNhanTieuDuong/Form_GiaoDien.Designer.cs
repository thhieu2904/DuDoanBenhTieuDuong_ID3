namespace DuDoanBenhNhanTieuDuong
{
    partial class Form_GiaoDien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBoxNhapLieu = new GroupBox();
            btn_Thoat = new Button();
            groupBox2 = new GroupBox();
            btn_HuanLuyen = new Button();
            lb_TrangThai = new Label();
            label1 = new Label();
            proBar_HuanLuyen = new ProgressBar();
            ud_diTruyen = new NumericUpDown();
            ud_Glucose = new NumericUpDown();
            ud_mmHg = new NumericUpDown();
            ud_dayNepda = new NumericUpDown();
            ud_Insulin = new NumericUpDown();
            ud_BMI = new NumericUpDown();
            ud_Tuoi = new NumericUpDown();
            ud_mangthai = new NumericUpDown();
            btnDatLai = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnDuDoan = new Button();
            groupBox1 = new GroupBox();
            rtb_HuongDan = new RichTextBox();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxNhapLieu.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ud_diTruyen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_Glucose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_mmHg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_dayNepda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_Insulin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_BMI).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_Tuoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ud_mangthai).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(100, 75);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBoxNhapLieu);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1400, 700);
            splitContainer1.SplitterDistance = 600;
            splitContainer1.TabIndex = 5;
            // 
            // groupBoxNhapLieu
            // 
            groupBoxNhapLieu.Controls.Add(btn_Thoat);
            groupBoxNhapLieu.Controls.Add(groupBox2);
            groupBoxNhapLieu.Controls.Add(ud_diTruyen);
            groupBoxNhapLieu.Controls.Add(ud_Glucose);
            groupBoxNhapLieu.Controls.Add(ud_mmHg);
            groupBoxNhapLieu.Controls.Add(ud_dayNepda);
            groupBoxNhapLieu.Controls.Add(ud_Insulin);
            groupBoxNhapLieu.Controls.Add(ud_BMI);
            groupBoxNhapLieu.Controls.Add(ud_Tuoi);
            groupBoxNhapLieu.Controls.Add(ud_mangthai);
            groupBoxNhapLieu.Controls.Add(btnDatLai);
            groupBoxNhapLieu.Controls.Add(label9);
            groupBoxNhapLieu.Controls.Add(label8);
            groupBoxNhapLieu.Controls.Add(label7);
            groupBoxNhapLieu.Controls.Add(label6);
            groupBoxNhapLieu.Controls.Add(label5);
            groupBoxNhapLieu.Controls.Add(label4);
            groupBoxNhapLieu.Controls.Add(label3);
            groupBoxNhapLieu.Controls.Add(label2);
            groupBoxNhapLieu.Controls.Add(btnDuDoan);
            groupBoxNhapLieu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxNhapLieu.Location = new Point(3, 3);
            groupBoxNhapLieu.Name = "groupBoxNhapLieu";
            groupBoxNhapLieu.Size = new Size(594, 691);
            groupBoxNhapLieu.TabIndex = 4;
            groupBoxNhapLieu.TabStop = false;
            groupBoxNhapLieu.Text = "Nhập thông tin bệnh nhân";
            // 
            // btn_Thoat
            // 
            btn_Thoat.Location = new Point(410, 610);
            btn_Thoat.Name = "btn_Thoat";
            btn_Thoat.Size = new Size(120, 55);
            btn_Thoat.TabIndex = 25;
            btn_Thoat.Text = "Thoát";
            btn_Thoat.UseVisualStyleBackColor = true;
            btn_Thoat.Click += btn_Thoat_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_HuanLuyen);
            groupBox2.Controls.Add(lb_TrangThai);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(proBar_HuanLuyen);
            groupBox2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(45, 480);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(506, 98);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tải dữ liệu và huấn luyện mô hình";
            // 
            // btn_HuanLuyen
            // 
            btn_HuanLuyen.Location = new Point(362, 62);
            btn_HuanLuyen.Name = "btn_HuanLuyen";
            btn_HuanLuyen.Size = new Size(138, 30);
            btn_HuanLuyen.TabIndex = 27;
            btn_HuanLuyen.Text = "Huấn luyện";
            btn_HuanLuyen.UseVisualStyleBackColor = true;
            btn_HuanLuyen.Click += btn_HuanLuyen_Click;
            // 
            // lb_TrangThai
            // 
            lb_TrangThai.AutoSize = true;
            lb_TrangThai.Location = new Point(98, 64);
            lb_TrangThai.Name = "lb_TrangThai";
            lb_TrangThai.Size = new Size(128, 20);
            lb_TrangThai.TabIndex = 26;
            lb_TrangThai.Text = "Chưa huấn luyện";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 64);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 25;
            label1.Text = "Trạng thái:";
            // 
            // proBar_HuanLuyen
            // 
            proBar_HuanLuyen.Location = new Point(6, 28);
            proBar_HuanLuyen.Name = "proBar_HuanLuyen";
            proBar_HuanLuyen.Size = new Size(494, 23);
            proBar_HuanLuyen.TabIndex = 0;
            // 
            // ud_diTruyen
            // 
            ud_diTruyen.DecimalPlaces = 2;
            ud_diTruyen.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_diTruyen.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            ud_diTruyen.Location = new Point(431, 365);
            ud_diTruyen.Maximum = new decimal(new int[] { 25, 0, 0, 65536 });
            ud_diTruyen.Name = "ud_diTruyen";
            ud_diTruyen.Size = new Size(120, 33);
            ud_diTruyen.TabIndex = 23;
            ud_diTruyen.Value = new decimal(new int[] { 4, 0, 0, 65536 });
            // 
            // ud_Glucose
            // 
            ud_Glucose.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_Glucose.Location = new Point(431, 115);
            ud_Glucose.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            ud_Glucose.Name = "ud_Glucose";
            ud_Glucose.Size = new Size(120, 33);
            ud_Glucose.TabIndex = 22;
            ud_Glucose.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // ud_mmHg
            // 
            ud_mmHg.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_mmHg.Location = new Point(431, 165);
            ud_mmHg.Maximum = new decimal(new int[] { 130, 0, 0, 0 });
            ud_mmHg.Name = "ud_mmHg";
            ud_mmHg.Size = new Size(120, 33);
            ud_mmHg.TabIndex = 21;
            ud_mmHg.Value = new decimal(new int[] { 70, 0, 0, 0 });
            // 
            // ud_dayNepda
            // 
            ud_dayNepda.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_dayNepda.Location = new Point(431, 215);
            ud_dayNepda.Name = "ud_dayNepda";
            ud_dayNepda.Size = new Size(120, 33);
            ud_dayNepda.TabIndex = 20;
            ud_dayNepda.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // ud_Insulin
            // 
            ud_Insulin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_Insulin.Location = new Point(431, 265);
            ud_Insulin.Maximum = new decimal(new int[] { 900, 0, 0, 0 });
            ud_Insulin.Name = "ud_Insulin";
            ud_Insulin.Size = new Size(120, 33);
            ud_Insulin.TabIndex = 19;
            ud_Insulin.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // ud_BMI
            // 
            ud_BMI.DecimalPlaces = 1;
            ud_BMI.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_BMI.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ud_BMI.Location = new Point(431, 315);
            ud_BMI.Maximum = new decimal(new int[] { 67, 0, 0, 0 });
            ud_BMI.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            ud_BMI.Name = "ud_BMI";
            ud_BMI.Size = new Size(120, 33);
            ud_BMI.TabIndex = 18;
            ud_BMI.Value = new decimal(new int[] { 22, 0, 0, 0 });
            // 
            // ud_Tuoi
            // 
            ud_Tuoi.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_Tuoi.Location = new Point(431, 415);
            ud_Tuoi.Name = "ud_Tuoi";
            ud_Tuoi.Size = new Size(120, 33);
            ud_Tuoi.TabIndex = 16;
            ud_Tuoi.Value = new decimal(new int[] { 35, 0, 0, 0 });
            // 
            // ud_mangthai
            // 
            ud_mangthai.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ud_mangthai.Location = new Point(431, 65);
            ud_mangthai.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            ud_mangthai.Name = "ud_mangthai";
            ud_mangthai.Size = new Size(120, 33);
            ud_mangthai.TabIndex = 14;
            // 
            // btnDatLai
            // 
            btnDatLai.Location = new Point(235, 610);
            btnDatLai.Name = "btnDatLai";
            btnDatLai.Size = new Size(120, 55);
            btnDatLai.TabIndex = 13;
            btnDatLai.Text = "Đặt lại";
            btnDatLai.UseVisualStyleBackColor = true;
            btnDatLai.Click += btn_DatLai;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label9.Location = new Point(45, 367);
            label9.Name = "label9";
            label9.Size = new Size(252, 25);
            label9.TabIndex = 12;
            label9.Text = "\tChỉ số di truyền tiểu đường:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label8.Location = new Point(45, 417);
            label8.Name = "label8";
            label8.Size = new Size(53, 25);
            label8.TabIndex = 11;
            label8.Text = "Tuổi:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label7.Location = new Point(45, 317);
            label7.Name = "label7";
            label7.Size = new Size(179, 25);
            label7.TabIndex = 10;
            label7.Text = "Chỉ số BMI (kg/m²):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label6.Location = new Point(45, 167);
            label6.Name = "label6";
            label6.Size = new Size(275, 25);
            label6.TabIndex = 9;
            label6.Text = "Huyết áp tâm trương (mmHg):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label5.Location = new Point(45, 267);
            label5.Name = "label5";
            label5.Size = new Size(248, 25);
            label5.TabIndex = 8;
            label5.Text = "Nồng độ Insulin (mu U/ml):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label4.Location = new Point(45, 217);
            label4.Name = "label4";
            label4.Size = new Size(229, 25);
            label4.TabIndex = 7;
            label4.Text = "Độ dày nếp gấp da (mm):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(45, 117);
            label3.Name = "label3";
            label3.Size = new Size(238, 25);
            label3.TabIndex = 6;
            label3.Text = "Nồng độ Glucose (mg/dL):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(45, 67);
            label2.Name = "label2";
            label2.Size = new Size(161, 25);
            label2.TabIndex = 5;
            label2.Text = "Số lần mang thai:";
            // 
            // btnDuDoan
            // 
            btnDuDoan.Location = new Point(60, 610);
            btnDuDoan.Name = "btnDuDoan";
            btnDuDoan.Size = new Size(120, 55);
            btnDuDoan.TabIndex = 4;
            btnDuDoan.Text = "Dự đoán";
            btnDuDoan.UseVisualStyleBackColor = true;
            btnDuDoan.Click += btn_DuDoan;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtb_HuongDan);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(790, 691);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hướng dẫn sử dụng";
            // 
            // rtb_HuongDan
            // 
            rtb_HuongDan.Location = new Point(8, 30);
            rtb_HuongDan.Margin = new Padding(5);
            rtb_HuongDan.Name = "rtb_HuongDan";
            rtb_HuongDan.ReadOnly = true;
            rtb_HuongDan.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtb_HuongDan.Size = new Size(780, 653);
            rtb_HuongDan.TabIndex = 25;
            rtb_HuongDan.Text = "";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(511, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(614, 50);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "DỰ ĐOÁN NGUY CƠ TIỂU ĐƯỜNG";
            // 
            // Form_GiaoDien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 811);
            Controls.Add(labelTitle);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Form_GiaoDien";
            Text = "GiaoDien";
            Load += GiaoDien_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxNhapLieu.ResumeLayout(false);
            groupBoxNhapLieu.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ud_diTruyen).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_Glucose).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_mmHg).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_dayNepda).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_Insulin).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_BMI).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_Tuoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)ud_mangthai).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SplitContainer splitContainer1;
        private GroupBox groupBoxNhapLieu;
        private Button btnDuDoan;
        private Label labelTitle;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label7;
        private Label label9;
        private Label label8;
        private Button btnDatLai;
        private NumericUpDown ud_mangthai;
        private NumericUpDown ud_Glucose;
        private NumericUpDown ud_mmHg;
        private NumericUpDown ud_dayNepda;
        private NumericUpDown ud_Insulin;
        private NumericUpDown ud_BMI;
        private NumericUpDown ud_Tuoi;
        private NumericUpDown ud_diTruyen;
        private GroupBox groupBox1;
        private RichTextBox rtb_HuongDan;
        private GroupBox groupBox2;
        private ProgressBar proBar_HuanLuyen;
        private Label label1;
        private Button btn_HuanLuyen;
        private Label lb_TrangThai;
        private Button btn_Thoat;
    }
}