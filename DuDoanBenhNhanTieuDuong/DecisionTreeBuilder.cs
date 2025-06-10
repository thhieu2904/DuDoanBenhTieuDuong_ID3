using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuDoanBenhNhanTieuDuong
{
    public class DecisionTreeBuilder
    {
        // Tính toán Entropy của một tập dữ liệu  
        private double CalculateEntropy(List<Patient> data)
        {
            if (data.Count == 0) return 0;

            double probPositive = (double)data.Count(p => p.Outcome == 1) / data.Count;
            double probNegative = 1 - probPositive;

            if (probPositive == 0 || probNegative == 0) return 0;

            return -probPositive * Math.Log(probPositive, 2) - probNegative * Math.Log(probNegative, 2);
        }

        // Tìm thuộc tính và ngưỡng phân chia tốt nhất (có Information Gain cao nhất)  
        private (string AttributeName, double Threshold, double Gain) FindBestSplit(List<Patient> data, List<string> features)
        {
            double bestInfoGain = 0;
            string bestFeature = null;
            double bestThreshold = 0;

            double parentEntropy = CalculateEntropy(data);

            foreach (var feature in features)
            {
                var uniqueValues = data.Select(p => GetValue(p, feature)).Distinct().OrderBy(v => v).ToList();

                if (uniqueValues.Count < 2) continue;

                for (int i = 0; i < uniqueValues.Count - 1; i++)
                {
                    double threshold = (uniqueValues[i] + uniqueValues[i + 1]) / 2;
                    var leftSplit = data.Where(p => GetValue(p, feature) <= threshold).ToList();
                    var rightSplit = data.Where(p => GetValue(p, feature) > threshold).ToList();

                    if (leftSplit.Count == 0 || rightSplit.Count == 0) continue;

                    double weightedEntropy = ((double)leftSplit.Count / data.Count) * CalculateEntropy(leftSplit) +
                                             ((double)rightSplit.Count / data.Count) * CalculateEntropy(rightSplit);

                    double infoGain = parentEntropy - weightedEntropy;

                    if (infoGain > bestInfoGain)
                    {
                        bestInfoGain = infoGain;
                        bestFeature = feature;
                        bestThreshold = threshold;
                    }
                }
            }
            return (bestFeature, bestThreshold, bestInfoGain);
        }

        // Xây dựng cây một cách đệ quy  
        public Node BuildTree(List<Patient> data, List<string> features, int maxDepth = 75, int minSamplesSplit = 15)
        {
            var node = new Node
            {
                TotalSamples = data.Count,
                PositiveSamples = data.Count(p => p.Outcome == 1)
            };

            // Điều kiện dừng đệ quy  
            if (data.All(p => p.Outcome == 1) || data.All(p => p.Outcome == 0) || features.Count == 0 || maxDepth == 0 || data.Count < minSamplesSplit)
            {
                node.PredictedClass = GetMajorityClass(data);
                return node;
            }

            var (bestFeature, bestThreshold, bestGain) = FindBestSplit(data, features);

            if (bestGain <= 0)
            {
                node.PredictedClass = GetMajorityClass(data);
                return node;
            }

            node.AttributeName = bestFeature;
            node.Threshold = bestThreshold;

            var leftData = data.Where(p => GetValue(p, bestFeature) <= bestThreshold).ToList();
            var rightData = data.Where(p => GetValue(p, bestFeature) > bestThreshold).ToList();

            node.LeftChild = BuildTree(leftData, features, maxDepth - 1, minSamplesSplit);
            node.RightChild = BuildTree(rightData, features, maxDepth - 1, minSamplesSplit);

            return node;
        }

        // Lấy giá trị của một thuộc tính từ đối tượng Patient bằng tên  
        public double GetValue(Patient p, string featureName)
        {
            switch (featureName)
            {
                case "Pregnancies": return p.Pregnancies;
                case "Glucose": return p.Glucose;
                case "BloodPressure": return p.BloodPressure;
                case "SkinThickness": return p.SkinThickness;
                case "Insulin": return p.Insulin;
                case "BMI": return p.BMI;
                case "DiabetesPedigreeFunction": return p.DiabetesPedigreeFunction;
                case "Age": return p.Age;
                default: throw new ArgumentException("Tên thuộc tính không hợp lệ: " + featureName);
            }
        }

        // Lấy lớp chiếm đa số trong một tập dữ liệu  
        private int GetMajorityClass(List<Patient> data)
        {
            if (data.Count == 0) return 0; // Mặc định là không bệnh nếu không có dữ liệu  
            return data.GroupBy(p => p.Outcome).OrderByDescending(g => g.Count()).First().Key;
        }
    }
}
