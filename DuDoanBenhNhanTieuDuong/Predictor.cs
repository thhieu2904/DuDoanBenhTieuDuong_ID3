using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuDoanBenhNhanTieuDuong
{
    public class Predictor
    {
        public (int prediction, double probability, Node leafNode) Predict(Patient patient, Node node)
        {
            // Nếu là nút lá, trả về kết quả
            if (node.IsLeaf)
            {
                double probability = 0;
                if (node.TotalSamples > 0)
                {
                    // Tính xác suất dựa trên số mẫu "dương tính" trong nút lá
                    probability = (double)node.PositiveSamples / node.TotalSamples;
                }
                // Nếu dự đoán là 0 (không bệnh), xác suất sẽ là (1 - probability)
                if (node.PredictedClass == 0)
                {
                    probability = 1 - probability;
                }

                return (node.PredictedClass, probability, node);
            }

            // Lấy giá trị của thuộc tính cần xét
            var treeBuilder = new DecisionTreeBuilder(); // 
            double value = treeBuilder.GetValue(patient, node.AttributeName);

            // Đệ quy xuống nhánh trái hoặc phải
            if (value <= node.Threshold)
            {
                return Predict(patient, node.LeftChild);
            }
            else
            {
                return Predict(patient, node.RightChild);
            }
        }



        // === HÀM MỚI: Lấy danh sách các node trên đường đi ===
        public List<Node> GetPredictionPath(Patient patient, Node root)
        {
            var path = new List<Node>();
            var currentNode = root;

            while (!currentNode.IsLeaf)
            {
                path.Add(currentNode);

                var treeBuilder = new DecisionTreeBuilder(); // Cần để dùng GetValue
                double value = treeBuilder.GetValue(patient, currentNode.AttributeName);

                if (value <= currentNode.Threshold)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }
            path.Add(currentNode); // Thêm nút lá cuối cùng vào
            return path;
        }
    }
}
