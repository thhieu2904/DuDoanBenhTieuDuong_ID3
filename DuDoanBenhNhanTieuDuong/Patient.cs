using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuDoanBenhNhanTieuDuong
{
    public class Patient
    {
        public double Pregnancies { get; set; }
        public double Glucose { get; set; }
        public double BloodPressure { get; set; }
        public double SkinThickness { get; set; }
        public double Insulin { get; set; }
        public double BMI { get; set; }
        public double DiabetesPedigreeFunction { get; set; }
        public double Age { get; set; }
        public int Outcome { get; set; } // 0 = Không bệnh, 1 = Có bệnh
    }
}
