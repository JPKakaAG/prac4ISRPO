using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace prac4ISRPO
{
    public class KochCurve
    {
        public void Draw(Canvas canvas, Point p1, Point p2, int depth)
        {
            if (depth == 0)
            {
                Line line = new Line
                {
                    X1 = p1.X,
                    Y1 = p1.Y,
                    X2 = p2.X,
                    Y2 = p2.Y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                canvas.Children.Add(line);
                return;
            }

            // Вычисление трёх новых точек для кривой Коха
            Point p3 = new Point((2 * p1.X + p2.X) / 3, (2 * p1.Y + p2.Y) / 3);
            Point p4 = new Point((p1.X + 2 * p2.X) / 3, (p1.Y + 2 * p2.Y) / 3);
            Point peak = new Point((p1.X + p2.X) / 2 + Math.Sqrt(3) * (p1.Y - p2.Y) / 6,
                                   (p1.Y + p2.Y) / 2 + Math.Sqrt(3) * (p2.X - p1.X) / 6);

            // Рекурсивный вызов
            Draw(canvas, p1, p3, depth - 1);
            Draw(canvas, p3, peak, depth - 1);
            Draw(canvas, peak, p4, depth - 1);
            Draw(canvas, p4, p2, depth - 1);
        }
    }
}
