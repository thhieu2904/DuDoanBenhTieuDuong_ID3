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
    public partial class Form_GiaoDien : Form
    {
        private List<Patient> trainingData;
        private Node decisionTreeRoot;

        public Form_GiaoDien()
        {
            InitializeComponent();
        }

        private void GiaoDien_Load(object sender, EventArgs e)
        {
            SetHuongDan(rtb_HuongDan);
            CustomizeUI();

            // Vô hiệu hóa nút Dự đoán khi chưa có mô hình
            //btnDuDoan.Enabled = false;
            lb_TrangThai.Text = "Chưa huấn luyện";
        }

        // =================================================================
        // PHẦN 3: LOGIC NÚT HUẤN LUYỆN ĐÃ ĐƯỢC CẬP NHẬT
        // =================================================================
        private async void btn_HuanLuyen_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa các nút để tránh người dùng nhấn lại
            btn_HuanLuyen.Enabled = false;
            btnDuDoan.Enabled = false;

            // Đặt lại giao diện trạng thái
            lb_TrangThai.ForeColor = Color.Black;
            lb_TrangThai.Text = "Bắt đầu quá trình...";
            proBar_HuanLuyen.Value = 0;

            try
            {
                // Bước 1: Tải dữ liệu
                lb_TrangThai.Text = "Đang tải dữ liệu huấn luyện...";

                // Sử dụng Task.Run để chạy trên luồng khác, tránh treo UI
                bool isDataLoaded = await Task.Run(() => LoadTrainingData());

                if (!isDataLoaded)
                {
                    lb_TrangThai.Text = "Lỗi: Tải dữ liệu thất bại!";
                    lb_TrangThai.ForeColor = Color.Red;
                    proBar_HuanLuyen.Value = 0; // Reset progress bar
                    return; // Dừng lại nếu lỗi
                }

                proBar_HuanLuyen.Value = 50; // Cập nhật tiến trình
                lb_TrangThai.Text = "Tải dữ liệu thành công. Training...";

                // Bước 2: Huấn luyện cây quyết định
                bool isTreeTrained = await Task.Run(() => TrainDecisionTree());

                if (!isTreeTrained)
                {
                    lb_TrangThai.Text = "Huấn luyện mô hình thất bại!";
                    lb_TrangThai.ForeColor = Color.Red;
                    return; // Dừng lại nếu lỗi
                }

                proBar_HuanLuyen.Value = 100; // Hoàn thành
                lb_TrangThai.Text = "Huấn luyện thành công!";
                lb_TrangThai.ForeColor = Color.Green;
                btnDuDoan.Enabled = true; // Bật nút dự đoán khi đã có mô hình
            }
            catch (Exception ex)
            {
                lb_TrangThai.Text = $"Lỗi hệ thống: {ex.Message}";
                lb_TrangThai.ForeColor = Color.Red;
            }
            finally
            {
                // Bất kể thành công hay thất bại, bật lại nút huấn luyện
                btn_HuanLuyen.Enabled = true;
            }
        }

        // =================================================================
        // PHẦN 2: CÁC HÀM TẢI VÀ HUẤN LUYỆN ĐÃ ĐƯỢC REFACTOR
        // =================================================================
        private bool LoadTrainingData()
        {
            try
            {
                this.trainingData = DataLoader.Instance.AllPatients;

                if (this.trainingData == null || this.trainingData.Count == 0)
                {
                    // Lỗi xảy ra nếu file không tìm thấy hoặc file rỗng
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                // Nếu có lỗi nghiêm trọng khi tải, trả về false
                return false;
            }
        }

        private bool TrainDecisionTree()
        {
            if (this.trainingData == null || this.trainingData.Count == 0)
            {
                return false;
            }

            try
            {
                var treeBuilder = new DecisionTreeBuilder();
                var features = new List<string> { "Pregnancies", "Glucose", "BloodPressure", "SkinThickness", "Insulin", "BMI", "DiabetesPedigreeFunction", "Age" };
                this.decisionTreeRoot = treeBuilder.BuildTree(this.trainingData, features);

                // Trả về true nếu cây được tạo thành công, ngược lại false
                return this.decisionTreeRoot != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btn_DuDoan(object sender, EventArgs e)
        {
            // Bước 1: Kiểm tra xem mô hình đã được huấn luyện chưa
            if (decisionTreeRoot == null)
            {
                MessageBox.Show("Mô hình chưa được huấn luyện. Vui lòng nhấn nút 'Huấn luyện' trước.",
                                "Chưa sẵn sàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bước 2: Thu thập dữ liệu từ các điều khiển NumericUpDown trên giao diện
            var patientToPredict = new Patient
            {
                Pregnancies = (double)ud_mangthai.Value,
                Glucose = (double)ud_Glucose.Value,
                BloodPressure = (double)ud_mmHg.Value,
                SkinThickness = (double)ud_dayNepda.Value,
                Insulin = (double)ud_Insulin.Value,
                BMI = (double)ud_BMI.Value,
                DiabetesPedigreeFunction = (double)ud_diTruyen.Value,
                Age = (double)ud_Tuoi.Value
                // Outcome sẽ được dự đoán, không cần gán ở đây
            };

            // Bước 3: Sử dụng Predictor để đưa ra dự đoán
            var predictor = new Predictor();
            // Hàm Predict sẽ trả về một tuple chứa: kết quả dự đoán, xác suất, và nút lá cuối cùng
            var (prediction, probability, leafNode) = predictor.Predict(patientToPredict, this.decisionTreeRoot);

            // Bước 4: Tạo form KetQua, truyền dữ liệu qua và hiển thị
            // Chúng ta sẽ tạo một constructor đặc biệt cho form KetQua để nhận dữ liệu
            var formKetQua = new Form_KetQua(patientToPredict, prediction, probability, leafNode,this.decisionTreeRoot);
            formKetQua.ShowDialog(); // Sử dụng ShowDialog để form kết quả nổi lên trên và phải được đóng trước khi quay lại form chính
        }




        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi thoát
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát ứng dụng
            }
        }


        private void btn_DatLai(object sender, EventArgs e)
        {
            ud_mangthai.Value = 0;
            ud_Glucose.Value = 120;
            ud_mmHg.Value = 70;
            ud_dayNepda.Value = 20;
            ud_Insulin.Value = 80;
            ud_BMI.Value = 22;
            ud_diTruyen.Value = 0.4m;
            ud_Tuoi.Value = 35;
        }

        // =================================================================
        // PHẦN 1: GIAO DIỆN ĐÃ ĐƯỢC CẬP NHẬT
        // =================================================================


        private void StyleModernButton(Button btn, Color backColor, Font font = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = font ?? new Font("Segoe UI", 11, FontStyle.Bold);
        }



        private void CustomizeUI()
        {
            // 1. Nền Form
            this.BackColor = Color.FromArgb(244, 248, 252); // Xanh dương rất nhạt

            // 2. Tiêu đề chính
            labelTitle.Font = new Font("Segoe UI Black", 26, FontStyle.Bold);
            labelTitle.ForeColor = Color.DarkSlateBlue;
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 3. GroupBox nhập liệu
            groupBoxNhapLieu.BackColor = Color.White;
            groupBoxNhapLieu.ForeColor = Color.DarkSlateBlue;
            groupBoxNhapLieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);

            // 4. Áp dụng style hiện đại cho các nút
            var primaryColor = Color.FromArgb(0, 123, 255); // Xanh dương hiện đại (Bootstrap)
            var secondaryColor = Color.DarkOliveGreen;
            var thirColor = Color.LightGreen;// Màu phụ nếu cần

            StyleModernButton(btnDuDoan, primaryColor);
            StyleModernButton(btn_HuanLuyen, secondaryColor);
            //StyleModernButton(btnDatLai, secondaryColor, new Font("Segoe UI", 11, FontStyle.Regular));
            StyleModernButton(btn_Thoat, Color.FromArgb(220, 53, 69)); // Màu đỏ nhạt (như nút danger)
        }


        private void SetHuongDan(RichTextBox rtb)
        {
            rtb.Clear();
            rtb.BackColor = Color.White; // Đặt nền cho RichTextBox

            // --- Font và màu sắc định nghĩa sẵn ---
            var titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            var headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            var regularFont = new Font("Segoe UI", 10, FontStyle.Regular);
            var boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            var italicFont = new Font("Segoe UI", 10, FontStyle.Italic);
            var codeFont = new Font("Consolas", 10, FontStyle.Regular);

            var titleColor = Color.DarkSlateBlue;
            var headerColor = Color.Black;
            var textColor = Color.FromArgb(50, 50, 50);
            var highlightColor = Color.SeaGreen;
            var buttonColor = Color.FromArgb(0, 123, 255);
            var noteColor = Color.Gray;

            // --- Hàm tiện ích để giảm lặp code ---
            Action<string, Font, Color, bool> appendText = (text, font, color, newLine) =>
            {
                rtb.SelectionStart = rtb.TextLength;
                rtb.SelectionLength = 0;
                rtb.SelectionFont = font;
                rtb.SelectionColor = color;
                rtb.AppendText(text + (newLine ? "\n" : ""));
            };

            // === BẮT ĐẦU NỘI DUNG HƯỚNG DẪN ===

            // 1. TIÊU ĐỀ
            appendText("HƯỚNG DẪN SỬ DỤNG ỨNG DỤNG\n", titleFont, titleColor, true);

            // 2. GIỚI THIỆU
            appendText("Chào mừng bạn đến với ứng dụng dự đoán nguy cơ tiểu đường. Vui lòng làm theo các bước dưới đây để có kết quả chính xác nhất.\n\n",
                       regularFont, textColor, true);

            // 3. BƯỚC 1: HUẤN LUYỆN MÔ HÌNH
            appendText("Bước 1: Huấn luyện Mô hình\n", headerFont, headerColor, true);
            appendText("Đây là bước đầu tiên và quan trọng nhất. Máy tính sẽ học các mẫu từ dữ liệu có sẵn để có thể đưa ra dự đoán.\n",
                       regularFont, textColor, true);
            appendText("   • Nhấn vào nút ", regularFont, textColor, false);
            appendText("\"Huấn luyện\"", new Font("Segoe UI", 10, FontStyle.Bold), highlightColor, false);
            appendText(" ở góc trên bên phải.\n", regularFont, textColor, false);
            appendText("   • Quan sát thanh tiến trình và dòng trạng thái để biết quá trình hoàn tất.\n", regularFont, textColor, true);
            appendText("   • Khi có thông báo ", regularFont, textColor, false);
            appendText("\"Huấn luyện thành công!\"", new Font("Segoe UI", 10, FontStyle.Italic), highlightColor, false);
            appendText(", nút ", regularFont, textColor, false);
            appendText("\"Dự đoán\"", boldFont, buttonColor, false);
            appendText(" sẽ sáng lên, báo hiệu mô hình đã sẵn sàng.\n\n", regularFont, textColor, false);

            // 4. BƯỚC 2: NHẬP THÔNG TIN
            appendText("Bước 2: Nhập các chỉ số của Bệnh nhân\n", headerFont, headerColor, true);
            appendText("Sử dụng các ô nhập liệu ở khung bên trái để cung cấp thông tin cho mô hình:\n", regularFont, textColor, true);

            // Dùng List và Loop để dễ quản lý
            var fields = new List<Tuple<string, string>>
            {
                Tuple.Create("Số lần mang thai:", "Tổng số lần đã từng mang thai."),
                Tuple.Create("Nồng độ Glucose:", "Nồng độ đường trong máu (mg/dL)."),
                Tuple.Create("Huyết áp:", "Huyết áp tâm trương (mmHg)."),
                Tuple.Create("Độ dày nếp gấp da:", "Đo tại cơ tam đầu (mm)."),
                Tuple.Create("Nồng độ Insulin:", "Nồng độ insulin trong 2 giờ (mu U/ml)."),
                Tuple.Create("Chỉ số BMI:", "Chỉ số khối cơ thể (cân nặng / chiều cao^2)."),
                Tuple.Create("Chỉ số di truyền:", "Hàm phả hệ tiểu đường, thể hiện yếu tố di truyền."),
                Tuple.Create("Tuổi:", "Tuổi của bệnh nhân (năm).")
            };

            foreach (var field in fields)
            {
                rtb.SelectionBullet = true;
                rtb.SelectionIndent = 20;
                appendText(field.Item1, boldFont, titleColor, false);
                appendText(" " + field.Item2 + "\n", regularFont, textColor, false);
                rtb.SelectionBullet = false;
                rtb.SelectionIndent = 0;
            }
            appendText("   • Bạn có thể nhấn nút ", regularFont, textColor, false);
            appendText("\"Đặt lại\"", boldFont, Color.Black, false);
            appendText(" để xóa nhanh các giá trị đã nhập về mặc định.\n\n", regularFont, textColor, false);


            // 5. BƯỚC 3: XEM KẾT QUẢ
            appendText("Bước 3: Thực hiện Dự đoán và Diễn giải Kết quả\n", headerFont, headerColor, true);
            appendText("Sau khi nhập đủ thông tin, hãy nhấn nút ", regularFont, textColor, false);
            appendText("\"Dự đoán\"", boldFont, buttonColor, false);
            appendText(".\nMột cửa sổ kết quả sẽ hiện ra, cung cấp các thông tin chi tiết:\n", regularFont, textColor, true);

            rtb.SelectionBullet = true;
            rtb.SelectionIndent = 20;
            appendText("Mức độ nguy cơ:", boldFont, titleColor, false);
            appendText(" (CAO, CÓ NGUY CƠ, KHÔNG CÓ NGUY CƠ) cùng với độ chắc chắn của dự đoán.\n", regularFont, textColor, false);
            rtb.SelectionBullet = true;
            appendText("Lời khuyên sức khỏe:", boldFont, titleColor, false);
            appendText(" Dựa trên mức độ nguy cơ của bạn.\n", regularFont, textColor, false);
            rtb.SelectionBullet = true;
            appendText("Biểu đồ trực quan:", boldFont, titleColor, false);
            appendText(" So sánh tỷ lệ 'Có nguy cơ' và 'Không có nguy cơ' trong nhóm bệnh nhân tương tự bạn.\n", regularFont, textColor, false);
            rtb.SelectionBullet = true;
            appendText("Nút \"Xem Cây Quyết Định\":", boldFont, titleColor, false);
            appendText(" Đây là một tính năng nâng cao! Nhấn vào đây để xem chính xác con đường mà mô hình đã đi qua để đưa ra kết luận cho trường hợp của bạn. Mỗi bước đi là một quyết định dựa trên một chỉ số cụ thể.\n\n", regularFont, textColor, false);
            rtb.SelectionBullet = false;
            rtb.SelectionIndent = 0;


            // 6. LỜI KẾT
            appendText("Chúc bạn có một trải nghiệm tốt và nhận được thông tin hữu ích cho sức khỏe!",
                       italicFont, noteColor, true);
        }
    }
}