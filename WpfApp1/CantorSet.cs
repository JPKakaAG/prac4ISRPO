using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace prac4ISRPO
{
    internal class CantorSet
    {
        public void Draw(Canvas canvas, double x, double y, double length, int depth)
        {
            if (depth == 0) return;

            // Рисуем отрезок
            Line line = new Line
            {
                X1 = x,
                Y1 = y,
                X2 = x + length,
                Y2 = y,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(line);

            // Рекурсивные вызовы для двух оставшихся частей
            Draw(canvas, x, y + 20, length / 3, depth - 1); // смещение по высоте
            Draw(canvas, x + 2 * length / 3, y + 20, length / 3, depth - 1);
        }
    }
}
