using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsForm_QLTV.CustomControls
{
    public enum BubbleType { Incoming, Outgoing }

    public partial class ChatBubble : UserControl
    {
        private string _message;
        private BubbleType _type;

        public ChatBubble(string message, BubbleType type)
        {
            _message = message;
            _type = type;
            this.DoubleBuffered = true; // Giảm giật hình
            this.Padding = new Padding(10);
            this.BackColor = Color.Transparent;

            // Tự động tính toán chiều cao dựa trên độ dài tin nhắn
            ResizeBubble();
        }

        private void ResizeBubble()
        {
            // Tạo label ảo để đo kích thước text
            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(_message, this.Font, this.Width - 30);
                this.Height = (int)size.Height + 25; // Padding trên dưới
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Màu sắc dựa trên mẫu thiết kế: Xanh dương (User) và Xám trắng (Bot)
            Color backColor = _type == BubbleType.Outgoing ? Color.FromArgb(52, 152, 219) : Color.FromArgb(236, 240, 241);
            Color foreColor = _type == BubbleType.Outgoing ? Color.White : Color.Black;

            // Vẽ nền bo tròn
            int arc = 15;
            Rectangle rect = new Rectangle(5, 5, this.Width - 10, this.Height - 10);

            // Nếu là tin nhắn đi (User) -> Nằm bên phải, tin đến (Bot) -> Nằm bên trái
            // Ở đây ta vẽ background full width user control, text sẽ được căn lề
            using (GraphicsPath path = GetRoundedPath(rect, arc))
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            // Vẽ Text
            TextRenderer.DrawText(e.Graphics, _message, this.Font, rect, foreColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak |
                (_type == BubbleType.Outgoing ? TextFormatFlags.Right : TextFormatFlags.Left));
        }

        // Hàm vẽ hình bo tròn
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}