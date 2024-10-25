using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace prac4ISRPO
{
    internal class SierpinskiTriangle
    {
        public void Draw(Canvas canvas, Point p1, Point p2, Point p3, int depth)
        {
            if (depth == 0)
            {
                Polygon triangle = new Polygon
                {
                    Fill = Brushes.Black,
                    Points = new PointCollection { p1, p2, p3 }
                };
                canvas.Children.Add(triangle);
                return;
            }

            // Находим середины сторон
            Point mid12 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            Point mid23 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
            Point mid31 = new Point((p3.X + p1.X) / 2, (p3.Y + p1.Y) / 2);

            // Рекурсивные вызовы
            Draw(canvas, p1, mid12, mid31, depth - 1);
            Draw(canvas, mid12, p2, mid23, depth - 1);
            Draw(canvas, mid31, mid23, p3, depth - 1);
        }
    }
}
