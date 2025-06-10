namespace DuDoanBenhNhanTieuDuong
{
    partial class Form_CayQuyetDinh
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
            lb_TieuDe = new Label();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            panelCay = new Panel();
            groupBox2 = new GroupBox();
            btn_DongY = new Button();
            rtb_MoTa = new RichTextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lb_TieuDe
            // 
            lb_TieuDe.AutoSize = true;
            lb_TieuDe.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_TieuDe.Location = new Point(482, 9);
            lb_TieuDe.Name = "lb_TieuDe";
            lb_TieuDe.Size = new Size(562, 45);
            lb_TieuDe.TabIndex = 0;
            lb_TieuDe.Text = "TRỰC QUAN HÓA CÂY QUYẾT ĐỊNH";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(120, 75);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1200, 800);
            splitContainer1.SplitterDistance = 750;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelCay);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 769);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cây quyết định";
            // 
            // panelCay
            // 
            panelCay.Location = new Point(6, 28);
            panelCay.Name = "panelCay";
            panelCay.Size = new Size(732, 736);
            panelCay.TabIndex = 0;
            panelCay.Paint += PanelCay_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_DongY);
            groupBox2.Controls.Add(rtb_MoTa);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(440, 764);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mô tả";
            // 
            // btn_DongY
            // 
            btn_DongY.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DongY.Location = new Point(176, 709);
            btn_DongY.Name = "btn_DongY";
            btn_DongY.Size = new Size(110, 40);
            btn_DongY.TabIndex = 17;
            btn_DongY.Text = "Đồng ý";
            btn_DongY.UseVisualStyleBackColor = true;
            btn_DongY.Click += btn_DongY_Click;
            // 
            // rtb_MoTa
            // 
            rtb_MoTa.Location = new Point(6, 49);
            rtb_MoTa.Name = "rtb_MoTa";
            rtb_MoTa.ReadOnly = true;
            rtb_MoTa.Size = new Size(428, 642);
            rtb_MoTa.TabIndex = 1;
            rtb_MoTa.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(180, 25);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 0;
            label1.Text = "Mô tả chi tiết";
            // 
            // Form_CayQuyetDinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1424, 861);
            Controls.Add(splitContainer1);
            Controls.Add(lb_TieuDe);
            Name = "Form_CayQuyetDinh";
            Text = "Form_CayQuyetDinh";
            Load += Form_CayQuyetDinh_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_TieuDe;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private Panel panelCay;
        private GroupBox groupBox2;
        private RichTextBox rtb_MoTa;
        private Label label1;
        private Button btn_DongY;
    }
}