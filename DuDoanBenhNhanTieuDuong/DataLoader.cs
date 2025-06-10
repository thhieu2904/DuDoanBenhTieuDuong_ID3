

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DuDoanBenhNhanTieuDuong
{
    public class DataLoader
    {
        // --- Bắt đầu phần Singleton ---
        // Thể hiện (instance) duy nhất của DataLoader
        private static readonly DataLoader _instance = new DataLoader();

        // Dữ liệu bệnh nhân được lưu trữ ở đây
        public List<Patient> AllPatients { get; private set; }

        // Hàm khởi tạo private để không ai có thể tạo instance mới từ bên ngoài
        private DataLoader()
        {
            // Tải dữ liệu ngay khi instance được tạo
            LoadDataFromFile("diabetes.csv");
        }

        // Phương thức public để truy cập vào instance duy nhất
        public static DataLoader Instance => _instance;
        // --- Kết thúc phần Singleton ---

        // Đổi tên hàm thành private, nó sẽ được gọi nội bộ
        private void LoadDataFromFile(string fileName)
        {
            // Phải đảm bảo file "diabetes.csv" được thiết lập "Copy to Output Directory"
            // trong Visual Studio (chọn file -> Properties -> Copy to Output Directory -> Copy if newer)
            string filePath = Path.Combine(Application.StartupPath, fileName);
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Không tìm thấy tệp dữ liệu tại: {filePath}. Vui lòng kiểm tra lại.", "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AllPatients = new List<Patient>(); // Khởi tạo danh sách rỗng để tránh lỗi
                return;
            }

            this.AllPatients = new List<Patient>();
            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                try
                {
                    // Đọc giá trị dạng chữ từ cột cuối
                    string outcomeText = values[8].Trim().ToLower();

                    // Chuyển đổi giá trị chữ thành số (1 hoặc 0)
                    int outcomeValue = (outcomeText == "tested_positive") ? 1 : 0;

                    var patient = new Patient
                    {
                        Pregnancies = double.Parse(values[0]),
                        Glucose = double.Parse(values[1]),
                        BloodPressure = double.Parse(values[2]),
                        SkinThickness = double.Parse(values[3]),
                        Insulin = double.Parse(values[4]),
                        BMI = double.Parse(values[5]),
                        DiabetesPedigreeFunction = double.Parse(values[6]),
                        Age = double.Parse(values[7]),
                        // Gán giá trị đã được chuyển đổi
                        Outcome = outcomeValue
                    };
                    this.AllPatients.Add(patient);
                }
                catch (Exception ex)
                {
                    // Thêm một MessageBox vào đây để gỡ lỗi trong tương lai!
                    MessageBox.Show($"Xảy ra lỗi khi xử lý dòng: '{line}'\nChi tiết lỗi: {ex.Message}", "Lỗi Parse Dữ Liệu");
                }
            }
        }
        
    }
}