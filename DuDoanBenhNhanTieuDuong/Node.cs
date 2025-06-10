using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuDoanBenhNhanTieuDuong
{
    public class Node
    {
        // Dùng cho nút quyết định (không phải lá)
        public string AttributeName { get; set; } // Tên thuộc tính để chia, vd: "Glucose"
        public double Threshold { get; set; }      // Ngưỡng để so sánh, vd: 120.5

        // Dùng cho nút lá (kết quả cuối cùng)
        public int PredictedClass { get; set; } = -1; // -1 nếu không phải lá. 0 hoặc 1 nếu là lá.
        public bool IsLeaf => LeftChild == null && RightChild == null;

        // Các nút con
        public Node LeftChild { get; set; }        // Nút con nếu điều kiện <= Threshold
        public Node RightChild { get; set; }       // Nút con nếu điều kiện > Threshold

        // Thuộc tính thêm cho việc Giải thích AI (XAI)
        public int TotalSamples { get; set; }
        public int PositiveSamples { get; set; }
    }
}
