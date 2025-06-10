using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuDoanBenhNhanTieuDuong
{
    public partial class Form_KetQua : Form
    {
        // Lưu lại các giá trị để dùng cho việc vẽ biểu đồ
        private int _prediction;
        private double _probability;
        private Node _leafNode;
        private Node _decisionTree;

        // Thêm một biến để lưu bệnh nhân
        private Patient _patient;

        // Constructor mặc định (để designer không bị lỗi)
        public Form_KetQua()
        {
            InitializeComponent();
        }

        // === CONSTRUCTOR CHÍNH ĐỂ NHẬN DỮ LIỆU TỪ GIAO DIỆN ===
        public Form_KetQua(Patient patient, int prediction, double probability, Node leafNode, Node decisionTree) // Thêm tham số decisionTree
        {
            InitializeComponent();

            CustomizeKetQuaUI(); // Gọi hàm tùy chỉnh giao diện
            // Lưu lại thông tin bệnh nhân
            _patient = patient;


            // Lưu các giá trị lại
            _prediction = prediction;
            _probability = probability;
            _leafNode = leafNode;
            _decisionTree = decisionTree;
            // Gọi các hàm để hiển thị thông tin lên giao diện
            DisplayPredictionResult();
            DisplayPatientInfo(patient);

            
        }

        private void DisplayPredictionResult()
        {
            // _prediction là kết quả phân loại (1 = Có bệnh, 0 = Không có bệnh)
            // _probability là độ chắc chắn của kết quả phân loại đó

            if (_prediction == 1)
            {
                // === TRƯỜNG HỢP DỰ ĐOÁN LÀ "CÓ BỆNH" ===
                // _probability ở đây là P(Có bệnh)

                if (_probability >= 0.75)
                {
                    // Mức độ chắc chắn cao -> Nguy cơ cao
                    lb_NguyCo.Text = "NGUY CƠ CAO";
                    lb_NguyCo.ForeColor = Color.Red;
                    SetAdvice(rtb_LoiKhuyen, "CAO"); // Gọi hàm đưa ra lời khuyên
                }
                else // 0.5 <= _probability < 0.75
                {
                    // Mức độ chắc chắn không quá cao -> Có nguy cơ
                    lb_NguyCo.Text = "CÓ NGUY CƠ";
                    lb_NguyCo.ForeColor = Color.DarkOrange;
                    SetAdvice(rtb_LoiKhuyen, "TRUNG_BINH"); // Gọi hàm đưa ra lời khuyên
                }
            }
            else // _prediction == 0
            {
                // === TRƯỜNG HỢP DỰ ĐOÁN LÀ "KHÔNG CÓ BỆNH" ===
                lb_NguyCo.Text = "KHÔNG CÓ NGUY CƠ";
                lb_NguyCo.ForeColor = Color.Green;
                SetAdvice(rtb_LoiKhuyen, "KHONG"); // Gọi hàm đưa ra lời khuyên
            }

            // Hiển thị xác suất (độ chắc chắn) của dự đoán đã đưa ra
            lb_XacSuat.Text = $"{_probability:P1}";
            
        }


        // Hàm để đưa ra lời khuyên dựa trên mức độ nguy cơ
        private void SetAdvice(RichTextBox rtb, string riskLevel)
        {
            rtb.Clear();
            rtb.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            rtb.SelectionColor = Color.DarkSlateBlue;
            rtb.AppendText("Lời khuyên dành cho bạn:\n");

            rtb.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            rtb.SelectionColor = Color.Black;

            switch (riskLevel)
            {
                case "CAO":
                    rtb.AppendText("Kết quả cho thấy bạn có nguy cơ cao mắc bệnh tiểu đường. Vui lòng:\n");
                    rtb.AppendText("• ");
                    rtb.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    rtb.AppendText("Tham khảo ý kiến bác sĩ ngay lập tức");
                    rtb.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
                    rtb.AppendText(" để được chẩn đoán và tư vấn chuyên sâu.\n");
                    rtb.AppendText("• Thực hiện các xét nghiệm cần thiết theo chỉ định của bác sĩ.\n");
                    rtb.AppendText("• Thay đổi lối sống một cách nghiêm túc: điều chỉnh chế độ ăn, tăng cường vận động thể chất.\n");
                    break;

                case "TRUNG_BINH":
                    rtb.AppendText("Kết quả cho thấy bạn có dấu hiệu nguy cơ mắc bệnh tiểu đường. Bạn nên:\n");
                    rtb.AppendText("• Lên lịch hẹn với bác sĩ để thảo luận về kết quả này.\n");
                    rtb.AppendText("• Chú ý hơn đến chế độ ăn uống: giảm đường, tinh bột và chất béo không tốt.\n");
                    rtb.AppendText("• Bắt đầu một chương trình tập thể dục đều đặn (đi bộ, đạp xe, yoga...).\n");
                    rtb.AppendText("• Theo dõi các chỉ số sức khỏe định kỳ.\n");
                    break;

                case "KHONG":
                    rtb.AppendText("Kết quả hiện tại cho thấy bạn không có nguy cơ mắc bệnh. Đây là một tin tốt!\n");
                    rtb.AppendText("• Hãy tiếp tục duy trì lối sống lành mạnh để bảo vệ sức khỏe.\n");
                    rtb.AppendText("• Duy trì chế độ ăn uống cân bằng và tập thể dục thường xuyên.\n");
                    rtb.AppendText("• Thực hiện khám sức khỏe định kỳ hàng năm để theo dõi.\n");
                    break;
            }
        }



        private void DisplayPatientInfo(Patient patient)
        {
            // Tạo một danh sách tạm để hiển thị lên DataGridView cho đẹp
            var displayList = new List<object>
            {
                new { ThuocTinh = "Số lần mang thai", GiaTri = patient.Pregnancies },
                new { ThuocTinh = "Nồng độ Glucose", GiaTri = patient.Glucose },
                new { ThuocTinh = "Huyết áp", GiaTri = patient.BloodPressure },
                new { ThuocTinh = "Độ dày nếp gấp da", GiaTri = patient.SkinThickness },
                new { ThuocTinh = "Nồng độ Insulin", GiaTri = patient.Insulin },
                new { ThuocTinh = "Chỉ số BMI", GiaTri = patient.BMI },
                new { ThuocTinh = "Chỉ số di truyền", GiaTri = patient.DiabetesPedigreeFunction },
                new { ThuocTinh = "Tuổi", GiaTri = patient.Age }
            };

            dgv_ThongTinBN.DataSource = displayList;

            // Gán DataSource (giữ nguyên)
            dgv_ThongTinBN.DataSource = displayList;

            // ====================================================================
            // === PHẦN CĂN CHỈNH GIAO DIỆN DATAGRIDVIEW ĐÃ ĐƯỢC NÂNG CẤP ===
            // ====================================================================

            // 1. Cấu hình cơ bản
            dgv_ThongTinBN.ReadOnly = true;
            dgv_ThongTinBN.AllowUserToAddRows = false;
            dgv_ThongTinBN.AllowUserToDeleteRows = false;
            dgv_ThongTinBN.AllowUserToResizeRows = false;
            dgv_ThongTinBN.RowHeadersVisible = false; // Ẩn cột header bên trái
            dgv_ThongTinBN.MultiSelect = false;
            dgv_ThongTinBN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ThongTinBN.BackgroundColor = Color.White; // Nền trắng sạch sẽ

            // 2. Tùy chỉnh Header (Tiêu đề cột)
            // Dòng này RẤT QUAN TRỌNG để các tùy chỉnh màu sắc có hiệu lực
            dgv_ThongTinBN.EnableHeadersVisualStyles = false;
            dgv_ThongTinBN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_ThongTinBN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 66, 91); // Màu xanh đậm
            dgv_ThongTinBN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Chữ trắng
            dgv_ThongTinBN.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv_ThongTinBN.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 3. Tùy chỉnh các dòng và ô
            dgv_ThongTinBN.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv_ThongTinBN.RowsDefaultCellStyle.BackColor = Color.White;
            // Làm cho các dòng chẵn/lẻ có màu khác nhau để dễ đọc
            dgv_ThongTinBN.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
            // Màu khi chọn một dòng
            dgv_ThongTinBN.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dgv_ThongTinBN.DefaultCellStyle.SelectionForeColor = Color.White;

            // 4. Tùy chỉnh các cột (quan trọng để khớp với khung)
            var thongTinCol = dgv_ThongTinBN.Columns[0];
            var giaTriCol = dgv_ThongTinBN.Columns[1];

            thongTinCol.HeaderText = "Thông tin";
            giaTriCol.HeaderText = "Giá trị";

            // Chế độ Fill sẽ tự động chia chiều rộng cho các cột
            thongTinCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            giaTriCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Nhưng ta có thể phân bổ tỉ lệ để cột "Thông tin" rộng hơn
            thongTinCol.FillWeight = 70; // Chiếm 70% không gian
            giaTriCol.FillWeight = 30; // Chiếm 30% không gian

            // Căn giữa cho cột giá trị
            giaTriCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // 5. Tùy chỉnh đường viền
            dgv_ThongTinBN.BorderStyle = BorderStyle.None;
            // Chỉ hiển thị đường kẻ ngang, tạo cảm giác thoáng đãng
            dgv_ThongTinBN.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_ThongTinBN.GridColor = Color.LightGray;
        }

        // Thay thế toàn bộ hàm Panel_bieudo_Paint trong file KetQua.cs

        private void Panel_bieudo_Paint(object sender, PaintEventArgs e)
        {
            // --- 1. KHỞI TẠO ---
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font regularFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font explanationFont = new Font("Segoe UI", 11, FontStyle.Italic);
            Brush textBrush = Brushes.Black;
            Brush explanationBrush = Brushes.DarkSlateGray;

            int panelWidth = panel_bieudo.Width;
            int panelHeight = panel_bieudo.Height;

            // --- 2. HIỂN THỊ DIỄN GIẢI BẰNG CHỮ Ở TRÊN ---
            int positiveEvidence = _leafNode.PositiveSamples;
            int totalEvidence = _leafNode.TotalSamples;
            int negativeEvidence = totalEvidence - positiveEvidence;

            string explanation = $"Dự đoán này dựa trên nhóm {totalEvidence} bệnh nhân có chỉ số tương tự.";
            string evidenceDetails = $"Trong đó: {positiveEvidence} người có nguy cơ và {negativeEvidence} người không có nguy cơ.";
            TextRenderer.DrawText(g, explanation, explanationFont, new Rectangle(10, 10, panelWidth - 20, 40), Color.DarkSlateGray, TextFormatFlags.WordBreak);
            TextRenderer.DrawText(g, evidenceDetails, explanationFont, new Rectangle(10, 50, panelWidth - 20, 40), Color.DarkSlateGray, TextFormatFlags.WordBreak);

            // --- 3. THIẾT LẬP THÔNG SỐ CHO BIỂU ĐỒ ---
            double probPositive = (totalEvidence > 0) ? (double)positiveEvidence / totalEvidence : 0;
            double probNegative = 1.0 - probPositive;

            int topMargin = 150;
            int bottomMargin = 50;
            int barWidth = 100;
            int spacing = 60;
            int labelPadding = 5;

            int chartAreaHeight = panelHeight - topMargin - bottomMargin;
            int totalChartWidth = (barWidth * 2) + spacing;
            int startX = (panelWidth - totalChartWidth) / 2;
            int startY = panelHeight - bottomMargin;

            // --- 4. VẼ CÁC THÀNH PHẦN CỦA BIỂU ĐỒ ---
            // VẼ CỘT 1: "KHÔNG CÓ NGUY CƠ" (Màu xanh)
            int barNegativeHeight = (int)(probNegative * chartAreaHeight);
            Rectangle rectNegative = new Rectangle(startX, startY - barNegativeHeight, barWidth, barNegativeHeight);
            g.FillRectangle(Brushes.SeaGreen, rectNegative);

            // VẼ CỘT 2: "CÓ NGUY CƠ" (Màu đỏ)
            int xPositive = startX + barWidth + spacing;
            int barPositiveHeight = (int)(probPositive * chartAreaHeight);
            Rectangle rectPositive = new Rectangle(xPositive, startY - barPositiveHeight, barWidth, barPositiveHeight);
            g.FillRectangle(Brushes.Tomato, rectPositive);

            // =========================================================================
            // === PHẦN SỬA LỖI: VẼ NHÃN (TÊN CỘT VÀ SỐ %) ĐÃ ĐƯỢC CĂN GIỮA CHÍNH XÁC ===
            // =========================================================================

            // --- Nhãn cho cột "Không có nguy cơ" ---
            // Vẽ % trên đỉnh cột
            string percentNeg = $"{probNegative:P0}";
            SizeF percentNegSize = g.MeasureString(percentNeg, titleFont);
            float percentNegY = rectNegative.Y - percentNegSize.Height - labelPadding;
            g.DrawString(percentNeg, titleFont, textBrush, startX + (barWidth - percentNegSize.Width) / 2, percentNegY);

            // **SỬA LỖI Ở ĐÂY**: Vẽ tên cột và căn giữa theo chiều ngang
            string labelNeg = "Không có nguy cơ";
            SizeF labelNegSize = g.MeasureString(labelNeg, regularFont);
            float labelNegX = startX + (barWidth - labelNegSize.Width) / 2; // <-- Tự động căn giữa
            g.DrawString(labelNeg, regularFont, textBrush, labelNegX, startY + 5);

            // --- Nhãn cho cột "Có nguy cơ" ---
            // Vẽ % trên đỉnh cột
            string percentPos = $"{probPositive:P0}";
            SizeF percentPosSize = g.MeasureString(percentPos, titleFont);
            float percentPosY = rectPositive.Y - percentPosSize.Height - labelPadding;
            g.DrawString(percentPos, titleFont, textBrush, xPositive + (barWidth - percentPosSize.Width) / 2, percentPosY);

            // **SỬA LỖI Ở ĐÂY**: Vẽ tên cột và căn giữa theo chiều ngang
            string labelPos = "Có nguy cơ";
            SizeF labelPosSize = g.MeasureString(labelPos, regularFont);
            float labelPosX = xPositive + (barWidth - labelPosSize.Width) / 2; // <-- Tự động căn giữa
            g.DrawString(labelPos, regularFont, textBrush, labelPosX, startY + 5);

            // --- 5. TÔ ĐẬM CỘT ĐƯỢC DỰ ĐOÁN ---
            using (Pen borderPen = new Pen(Color.FromArgb(50, 50, 50), 4))
            {
                g.DrawRectangle(borderPen, _prediction == 0 ? rectNegative : rectPositive);
            }
        }



        private void btn_DongY_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btn_XemCay_Click(object sender, EventArgs e)
        {
            if (_decisionTree != null && _patient != null)
            {
                // 1. Lấy con đường dự đoán
                var predictor = new Predictor();
                List<Node> predictionPath = predictor.GetPredictionPath(_patient, _decisionTree);

                // 2. Truyền cả cây và con đường qua form mới
                Form_CayQuyetDinh treeForm = new Form_CayQuyetDinh(_decisionTree, predictionPath, _patient);
                treeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu cây quyết định hoặc thông tin bệnh nhân để hiển thị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CustomizeKetQuaUI()
        {
            // === Bảng màu và Font chữ chung ===
            var formBgColor = Color.FromArgb(244, 248, 252);
            var cardBgColor = Color.White;
            var titleColor = Color.FromArgb(33, 37, 41); // Gần đen
            var primaryActionColor = Color.FromArgb(40, 167, 69); // Xanh lá cây
            var hoverPrimaryColor = Color.FromArgb(33, 136, 56);
            var secondaryActionColor = Color.FromArgb(108, 117, 125); // Xám
            var hoverSecondaryColor = Color.FromArgb(242, 242, 242);

            // 1. Form chính
            this.BackColor = formBgColor;
            this.Text = "Chi Tiết Kết Quả Dự Đoán";

            // 2. Tiêu đề chính
            lb_Tieude.Font = new Font("Segoe UI", 24F, FontStyle.Bold); // Sửa tên từ lbTieuDe thành lb_Tieude
            lb_Tieude.ForeColor = titleColor;
            lb_Tieude.TextAlign = ContentAlignment.MiddleCenter;
            // Căn giữa tiêu đề theo chiều ngang của form
            lb_Tieude.Left = (this.ClientSize.Width - lb_Tieude.Width) / 2;

            // 3. Các vùng nội dung (GroupBox)
            // Áp dụng nền trắng cho các GroupBox để tạo hiệu ứng "card"
            groupBox1.BackColor = cardBgColor;
            groupBox2.BackColor = cardBgColor;
            panel_bieudo.BackColor = cardBgColor; // Panel biểu đồ cũng có nền trắng
            rtb_LoiKhuyen.BackColor = cardBgColor; // RichTextBox cũng có nền trắng
            rtb_LoiKhuyen.BorderStyle = BorderStyle.None;
            dgv_ThongTinBN.BackgroundColor = cardBgColor;

            // 4. Các Label quan trọng trong groupBox1
            lb_NguyCo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            // Màu sắc của lb_NguyCo được đặt tự động dựa trên kết quả nên không cần chỉnh ở đây

            label10.Font = new Font("Segoe UI", 14F); // Chữ "Nguy cơ:"
            label1.Font = new Font("Segoe UI", 14F);  // Chữ "Xác suất:"
            lb_XacSuat.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

            // 5. Các nút bấm
            // Nút "Cây Quyết Định" (tên trong designer là button1) - Hành động chính
            button1.Text = "Cây Quyết Định"; // Đổi tên cho rõ ràng hơn
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = primaryActionColor;
            button1.ForeColor = Color.White;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.MouseEnter += (s, e) => { button1.BackColor = hoverPrimaryColor; };
            button1.MouseLeave += (s, e) => { button1.BackColor = primaryActionColor; };

            // Nút "Đồng ý" - Hành động phụ
            btn_DongY.FlatStyle = FlatStyle.Flat;
            btn_DongY.BackColor = cardBgColor;
            btn_DongY.ForeColor = secondaryActionColor;
            btn_DongY.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_DongY.FlatAppearance.BorderSize = 1;
            btn_DongY.FlatAppearance.BorderColor = Color.Gainsboro;
            btn_DongY.MouseEnter += (s, e) => { btn_DongY.BackColor = hoverSecondaryColor; };
            btn_DongY.MouseLeave += (s, e) => { btn_DongY.BackColor = cardBgColor; };
        }


    }
}