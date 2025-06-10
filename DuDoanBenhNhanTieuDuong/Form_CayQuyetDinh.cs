using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DuDoanBenhNhanTieuDuong
{
    public partial class Form_CayQuyetDinh : Form
    {
        // Các biến cần thiết cho việc vẽ và hiển thị
        private Node _rootNode;
        private List<Node> _highlightedPath;
        private Patient _patient;

        // Các hằng số để vẽ
        private const int NodeWidth = 150;
        private const int NodeHeight = 80;
        private const int VertSpacing = 70;
        private const int HorizSpacing = 30;

        // Cấu trúc để lưu vị trí các node trước khi vẽ
        private readonly Dictionary<Node, Point> _nodePositions = new Dictionary<Node, Point>();




        public Form_CayQuyetDinh(Node root, List<Node> path, Patient patient)
        {
            InitializeComponent();
            _rootNode = root;
            _highlightedPath = path;
            _patient = patient;


        }

        private void Form_CayQuyetDinh_Load(object sender, EventArgs e)
        {
            CustomizeCayUI();
            if (_rootNode == null || _highlightedPath == null || !_highlightedPath.Any())
            {
                // Hiển thị thông báo nếu không có dữ liệu
                rtb_MoTa.Text = "Không có dữ liệu cây quyết định hoặc đường đi dự đoán.";
                panelCay.Visible = false; // Ẩn panel vẽ đi
                return;
            }

            // 1. Tính toán vị trí cho các node trên đường đi cần hiển thị
            CalculatePathNodePositions();

            //// 2. Tính toán kích thước cần thiết cho panel và bật AutoScroll
            //if (_nodePositions.Any())
            //{
            //    int treeWidth = _nodePositions.Values.Max(p => p.X) + NodeWidth + HorizSpacing;
            //    int treeHeight = _nodePositions.Values.Max(p => p.Y) + NodeHeight + VertSpacing;
            //    panelCay.AutoScrollMinSize = new Size(treeWidth, treeHeight);
            //}

            // 3. Tạo mô tả văn bản
            GenerateDescription();

            // 4. Yêu cầu vẽ lại panel (không cần thiết vì form mới load sẽ tự vẽ, nhưng để cho chắc chắn)
            panelCay.Invalidate();

        }

        private void PanelCay_Paint(object sender, PaintEventArgs e)
        {
            // --- Phần khởi tạo ---
            if (_highlightedPath == null || !_nodePositions.Any()) return;

            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // --- BƯỚC 1: TÍNH TOÁN KÍCH THƯỚC THỰC CỦA CÂY ---
            // Tìm ra các tọa độ biên của cây ở tỷ lệ 100%
            float minX = _nodePositions.Values.Min(p => p.X);
            float maxX = _nodePositions.Values.Max(p => p.X);
            float minY = _nodePositions.Values.Min(p => p.Y); // Thường là VertSpacing
            float maxY = _nodePositions.Values.Max(p => p.Y);

            // Tính toán chiều rộng và chiều cao thực của nội dung cây
            float contentWidth = (maxX - minX) + NodeWidth;
            float contentHeight = (maxY - minY) + NodeHeight;

            if (contentWidth <= 0 || contentHeight <= 0) return; // Tránh lỗi chia cho 0

            // --- BƯỚC 2: TÍNH TOÁN TỶ LỆ THU PHÓNG (ZOOM) ---
            // Lấy kích thước của khung nhìn (panel), trừ đi một chút padding
            float padding = 20f;
            float viewWidth = panelCay.ClientSize.Width - padding * 2;
            float viewHeight = panelCay.ClientSize.Height - padding * 2;

            if (viewWidth <= 0 || viewHeight <= 0) return; // Panel quá nhỏ để vẽ

            // Tính tỷ lệ zoom theo chiều ngang và dọc
            float zoomX = viewWidth / contentWidth;
            float zoomY = viewHeight / contentHeight;

            // Chọn tỷ lệ nhỏ hơn để đảm bảo cây vừa vặn theo cả 2 chiều (giữ đúng tỷ lệ)
            float zoom = Math.Min(zoomX, zoomY);

            // --- BƯỚC 3: ÁP DỤNG BIẾN ĐỔI (TRANSFORMATION) ---
            // Các phép biến đổi này sẽ áp dụng cho TẤT CẢ các lệnh vẽ theo sau.
            // Thứ tự thực hiện rất quan trọng!

            // 1. Dịch chuyển để căn giữa khung nhìn sau khi đã zoom
            float scaledContentWidth = contentWidth * zoom;
            float scaledContentHeight = contentHeight * zoom;
            float offsetX = (panelCay.ClientSize.Width - scaledContentWidth) / 2;
            float offsetY = (panelCay.ClientSize.Height - scaledContentHeight) / 2;
            e.Graphics.TranslateTransform(offsetX, offsetY);

            // 2. Áp dụng thu phóng
            e.Graphics.ScaleTransform(zoom, zoom);

            // 3. Dịch chuyển gốc tọa độ của cây về (0,0)
            // Để điểm trên-trái nhất của cây được coi là gốc trước khi zoom và căn giữa
            e.Graphics.TranslateTransform(-minX, -minY);

            // --- BƯỚC 4: VẼ CÂY NHƯ BÌNH THƯỜNG ---
            // Các hàm DrawEdge và DrawSingleNode không cần thay đổi gì cả.
            // Chúng vẫn vẽ với tọa độ gốc, GDI+ sẽ tự động áp dụng các biến đổi ở trên.

            // Vẽ các đường nối (Edges)
            for (int i = 0; i < _highlightedPath.Count - 1; i++)
            {
                Node currentNode = _highlightedPath[i];
                if (!_nodePositions.ContainsKey(currentNode)) continue;
                Point startPos = _nodePositions[currentNode];
                if (currentNode.LeftChild != null && _nodePositions.ContainsKey(currentNode.LeftChild))
                {
                    DrawEdge(e.Graphics, startPos, _nodePositions[currentNode.LeftChild], $"<= {currentNode.Threshold:F2}", _highlightedPath.Contains(currentNode.LeftChild));
                }
                if (currentNode.RightChild != null && _nodePositions.ContainsKey(currentNode.RightChild))
                {
                    DrawEdge(e.Graphics, startPos, _nodePositions[currentNode.RightChild], $"> {currentNode.Threshold:F2}", _highlightedPath.Contains(currentNode.RightChild));
                }
            }

            // Vẽ các Node
            foreach (var kvp in _nodePositions)
            {
                DrawSingleNode(e.Graphics, kvp.Key, kvp.Value);
            }
        }




        // Tính toán vị trí của các node trong đường đi đã được highlight
        /// <summary>
        /// Hàm được viết lại: Tính toán vị trí cho các node trên đường đi chính
        /// và cả node con đầu tiên của nhánh phụ tại mỗi bước.
        /// </summary>
        private void CalculatePathNodePositions()
        {
            _nodePositions.Clear();
            if (_highlightedPath == null || !_highlightedPath.Any()) return;

            // BƯỚC 1: TÍNH TOÁN VỊ TRÍ TƯƠNG ĐỐI
            // Đặt trục chính của cây tại X = 0, không phụ thuộc vào kích thước panel.
            int mainPathX = 0;
            int startY = VertSpacing;

            for (int i = 0; i < _highlightedPath.Count - 1; i++)
            {
                Node currentNode = _highlightedPath[i];
                Node nextNodeOnPath = _highlightedPath[i + 1];

                int currentY = startY + i * (NodeHeight + VertSpacing);
                if (!_nodePositions.ContainsKey(currentNode))
                {
                    _nodePositions[currentNode] = new Point(mainPathX, currentY);
                }

                Node alternativeNode;
                int alternativeX;

                if (nextNodeOnPath == currentNode.LeftChild)
                {
                    alternativeNode = currentNode.RightChild;
                    // Nhánh phụ bên PHẢI (tọa độ X dương)
                    alternativeX = mainPathX + NodeWidth + HorizSpacing;
                }
                else
                {
                    alternativeNode = currentNode.LeftChild;
                    // Nhánh phụ bên TRÁI (tọa độ X âm)
                    alternativeX = mainPathX - NodeWidth - HorizSpacing;
                }

                if (alternativeNode != null)
                {
                    int alternativeY = startY + (i + 1) * (NodeHeight + VertSpacing);
                    if (!_nodePositions.ContainsKey(alternativeNode))
                    {
                        _nodePositions[alternativeNode] = new Point(alternativeX, alternativeY);
                    }
                }
            }

            Node lastNode = _highlightedPath.Last();
            if (!_nodePositions.ContainsKey(lastNode))
            {
                int lastNodeY = startY + (_highlightedPath.Count - 1) * (NodeHeight + VertSpacing);
                _nodePositions[lastNode] = new Point(mainPathX, lastNodeY);
            }
        }



        private void DrawSingleNode(Graphics g, Node node, Point position)
        {
            // isPath sẽ quyết định node có được tô sáng hay không
            bool isPath = _highlightedPath.Contains(node);

            // Chọn màu sắc dựa trên việc node có thuộc đường đi chính hay không
            Brush nodeBrush;
            Pen nodeBorder;
            Brush textBrush;

            if (isPath)
            {
                // Node trên đường đi chính: Màu xanh sáng, viền đậm, chữ đen
                nodeBrush = node.IsLeaf ? Brushes.LightGreen : Brushes.LightBlue;
                nodeBorder = new Pen(Color.Black, 2);
                textBrush = Brushes.Black;
            }
            else
            {
                // Node ở nhánh phụ: Màu xám nhạt, viền mờ, chữ xám
                nodeBrush = Brushes.WhiteSmoke;
                nodeBorder = new Pen(Color.LightGray, 1);
                textBrush = Brushes.DimGray;
            }

            Rectangle rect = new Rectangle(position.X, position.Y, NodeWidth, NodeHeight);
            g.FillRectangle(nodeBrush, rect);
            g.DrawRectangle(nodeBorder, rect);

            string nodeText = GetNodeText(node);
            StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(nodeText, new Font("Segoe UI", 8), textBrush, rect, format);
        }

        private void DrawEdge(Graphics g, Point start, Point end, string text, bool isPath)
        {
            Point startPoint = new Point(start.X + NodeWidth / 2, start.Y + NodeHeight);
            Point endPoint = new Point(end.X + NodeWidth / 2, end.Y);
            Pen linePen = isPath ? new Pen(Color.Black, 2) : new Pen(Color.LightGray, 1);
            g.DrawLine(linePen, startPoint, endPoint);
            Point midPoint = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            Brush textBrush = isPath ? Brushes.DarkBlue : Brushes.Gray;
            g.DrawString(text, new Font("Segoe UI", 8, FontStyle.Italic), textBrush, midPoint);
        }

        private string GetNodeText(Node node)
        {
            if (node.IsLeaf)
            {
                string result = node.PredictedClass == 1 ? "Bị bệnh" : "Không bệnh";
                return $"Kết quả: {result}\n({node.PositiveSamples}/{node.TotalSamples})";
            }
            else
            {
                return $"{node.AttributeName}\n({node.PositiveSamples}/{node.TotalSamples})";
            }
        }

        private void GenerateDescription()
        {
            // Code hàm này giữ nguyên
            if (_highlightedPath == null || _patient == null)
            {
                rtb_MoTa.Text = "Không có dữ liệu để tạo mô tả.";
                return;
            }
            rtb_MoTa.Clear();
            var treeBuilder = new DecisionTreeBuilder();
            Action<string, Font, Color> appendText = (text, font, color) =>
            {
                rtb_MoTa.SelectionStart = rtb_MoTa.TextLength;
                rtb_MoTa.SelectionLength = 0;
                rtb_MoTa.SelectionFont = font;
                rtb_MoTa.SelectionColor = color;
                rtb_MoTa.AppendText(text);
            };
            Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font regularFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font italicFont = new Font("Segoe UI", 10, FontStyle.Italic);
            appendText("DIỄN GIẢI QUÁ TRÌNH DỰ ĐOÁN\n\n", titleFont, Color.DarkSlateBlue);
            for (int i = 0; i < _highlightedPath.Count - 1; i++)
            {
                Node node = _highlightedPath[i];
                double value = treeBuilder.GetValue(_patient, node.AttributeName);
                string comparison = value <= node.Threshold ? "NHỎ HƠN HOẶC BẰNG" : "LỚN HƠN";
                string direction = value <= node.Threshold ? "TRÁI" : "PHẢI";
                appendText($"Bước {i + 1}: ", boldFont, Color.Black);
                appendText($"Xét thuộc tính ", regularFont, Color.Black);
                appendText($"{node.AttributeName}\n", boldFont, Color.Teal);
                appendText($"   • Giá trị của bệnh nhân: ", regularFont, Color.Black);
                appendText($"{value:F2}\n", boldFont, Color.Black);
                appendText($"   • So sánh với ngưỡng: ", regularFont, Color.Black);
                appendText($"{node.Threshold:F2}\n", boldFont, Color.Black);
                appendText($"   • Kết quả: ", regularFont, Color.Black);
                appendText($"{value:F2} {comparison} {node.Threshold:F2}. ", italicFont, Color.Gray);
                appendText($"Đi theo nhánh {direction}.\n\n", boldFont, Color.DarkBlue);
            }
            Node leafNode = _highlightedPath.Last();
            string result = leafNode.PredictedClass == 1 ? "CÓ NGUY CƠ BỆNH" : "KHÔNG CÓ NGUY CƠ";
            Color resultColor = leafNode.PredictedClass == 1 ? Color.DarkRed : Color.DarkGreen;
            appendText("KẾT LUẬN CUỐI CÙNG:\n", titleFont, Color.DarkSlateBlue);
            appendText($"   • Dựa trên các điều kiện trên, mô hình đi đến nút lá và dự đoán kết quả là: ", regularFont, Color.Black);
            appendText($"{result}\n", new Font("Segoe UI", 11, FontStyle.Bold), resultColor);
            appendText($"   • Căn cứ: ", regularFont, Color.Black);
            appendText($"Nút lá này được tạo từ một nhóm ", regularFont, Color.Black);
            appendText($"{leafNode.TotalSamples}", boldFont, Color.Black);
            appendText($" bệnh nhân tương tự trong tập huấn luyện, trong đó có ", regularFont, Color.Black);
            appendText($"{leafNode.PositiveSamples}", boldFont, Color.DarkRed);
            appendText($" người mắc bệnh.\n", regularFont, Color.Black);
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CustomizeCayUI()
        {
            // === Bảng màu và Font chữ chung ===
            var formBgColor = Color.FromArgb(244, 248, 252);
            var cardBgColor = Color.White;
            var titleColor = Color.FromArgb(33, 37, 41);

            // 1. Form chính
            this.BackColor = formBgColor;
            this.Text = "Trực Quan Hóa Cây Quyết Định";

            // 2. Tiêu đề chính
            lb_TieuDe.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lb_TieuDe.ForeColor = titleColor;
            // Căn giữa tiêu đề theo chiều ngang của form
            lb_TieuDe.Left = (this.ClientSize.Width - lb_TieuDe.Width) / 2;

            // 3. Các vùng nội dung
            // Đặt nền trắng cho các GroupBox và các control bên trong nó
            groupBox1.BackColor = cardBgColor;
            panelCay.BackColor = cardBgColor;
            groupBox2.BackColor = cardBgColor;
            rtb_MoTa.BackColor = cardBgColor;
            rtb_MoTa.BorderStyle = BorderStyle.None;

            // 4. Nút "Đồng ý" (btn_DongY)
            btn_DongY.FlatStyle = FlatStyle.Flat;
            btn_DongY.BackColor = Color.Gainsboro;
            btn_DongY.ForeColor = Color.Black;
            btn_DongY.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_DongY.Text = "Đóng"; // Sửa tên nút cho ngắn gọn
        }
    }
}