namespace DuDoanBenhNhanTieuDuong
{
    partial class Form_KetQua
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
            lb_Tieude = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            panel_bieudo = new Panel();
            groupBox1 = new GroupBox();
            button1 = new Button();
            dgv_ThongTinBN = new DataGridView();
            rtb_LoiKhuyen = new RichTextBox();
            btn_DongY = new Button();
            lb_XacSuat = new Label();
            label1 = new Label();
            label10 = new Label();
            lb_NguyCo = new Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ThongTinBN).BeginInit();
            SuspendLayout();
            // 
            // lb_Tieude
            // 
            lb_Tieude.AutoSize = true;
            lb_Tieude.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Tieude.Location = new Point(495, 9);
            lb_Tieude.Name = "lb_Tieude";
            lb_Tieude.Size = new Size(457, 45);
            lb_Tieude.TabIndex = 8;
            lb_Tieude.Text = "CHI TIẾT KẾT QUẢ DỰ ĐOÁN";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.17647F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.82353F));
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Location = new Point(240, 75);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1000, 700);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panel_bieudo);
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(414, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(583, 694);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Biểu đồ và mô tả";
            // 
            // panel_bieudo
            // 
            panel_bieudo.Location = new Point(6, 28);
            panel_bieudo.Name = "panel_bieudo";
            panel_bieudo.Size = new Size(577, 660);
            panel_bieudo.TabIndex = 14;
            panel_bieudo.Paint += Panel_bieudo_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(dgv_ThongTinBN);
            groupBox1.Controls.Add(rtb_LoiKhuyen);
            groupBox1.Controls.Add(btn_DongY);
            groupBox1.Controls.Add(lb_XacSuat);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(lb_NguyCo);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 694);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kết quả";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(221, 635);
            button1.Name = "button1";
            button1.Size = new Size(126, 43);
            button1.TabIndex = 17;
            button1.Text = "Cây Quyết Định";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btn_XemCay_Click;
            // 
            // dgv_ThongTinBN
            // 
            dgv_ThongTinBN.AllowUserToAddRows = false;
            dgv_ThongTinBN.AllowUserToDeleteRows = false;
            dgv_ThongTinBN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ThongTinBN.Location = new Point(9, 416);
            dgv_ThongTinBN.Name = "dgv_ThongTinBN";
            dgv_ThongTinBN.ReadOnly = true;
            dgv_ThongTinBN.Size = new Size(385, 192);
            dgv_ThongTinBN.TabIndex = 13;
            // 
            // rtb_LoiKhuyen
            // 
            rtb_LoiKhuyen.Location = new Point(9, 137);
            rtb_LoiKhuyen.Name = "rtb_LoiKhuyen";
            rtb_LoiKhuyen.ReadOnly = true;
            rtb_LoiKhuyen.Size = new Size(385, 250);
            rtb_LoiKhuyen.TabIndex = 17;
            rtb_LoiKhuyen.Text = "";
            // 
            // btn_DongY
            // 
            btn_DongY.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DongY.Location = new Point(54, 636);
            btn_DongY.Name = "btn_DongY";
            btn_DongY.Size = new Size(110, 43);
            btn_DongY.TabIndex = 16;
            btn_DongY.Text = "Đồng ý";
            btn_DongY.UseVisualStyleBackColor = true;
            btn_DongY.Click += btn_DongY_Click;
            // 
            // lb_XacSuat
            // 
            lb_XacSuat.AutoSize = true;
            lb_XacSuat.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_XacSuat.Location = new Point(119, 92);
            lb_XacSuat.Name = "lb_XacSuat";
            lb_XacSuat.Size = new Size(36, 25);
            lb_XacSuat.TabIndex = 15;
            lb_XacSuat.Text = "---";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 92);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 14;
            label1.Text = "Xác suất:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(23, 50);
            label10.Name = "label10";
            label10.Size = new Size(90, 25);
            label10.TabIndex = 9;
            label10.Text = "Nguy cơ:";
            // 
            // lb_NguyCo
            // 
            lb_NguyCo.AutoSize = true;
            lb_NguyCo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_NguyCo.Location = new Point(119, 50);
            lb_NguyCo.Name = "lb_NguyCo";
            lb_NguyCo.Size = new Size(36, 25);
            lb_NguyCo.TabIndex = 10;
            lb_NguyCo.Text = "---";
            // 
            // Form_KetQua
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 811);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lb_Tieude);
            Name = "Form_KetQua";
            Text = "KetQua";
            Click += btn_XemCay_Click;
            tableLayoutPanel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ThongTinBN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lb_Tieude;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Button button1;
        private DataGridView dgv_ThongTinBN;
        private RichTextBox rtb_LoiKhuyen;
        private Button btn_DongY;
        private Label lb_XacSuat;
        private Label label1;
        private Label label10;
        private Label lb_NguyCo;
        private GroupBox groupBox2;
        private Panel panel_bieudo;
    }
}