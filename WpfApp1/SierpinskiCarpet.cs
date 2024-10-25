using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace prac4ISRPO
{
    internal class SierpinskiCarpet
    {
        public void Draw(Canvas canvas, double x, double y, double size, int depth)
        {
            if (depth == 0)
            {
                Rectangle rect = new Rectangle
                {
                    Width = size,
                    Height = size,
                    Fill = Brushes.Black
                };
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas.Children.Add(rect);
                return;
            }

            double newSize = size / 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1) continue; // Пропускаем центральную ячейку
                    Draw(canvas, x + i * newSize, y + j * newSize, newSize, depth - 1);
                }
            }
        }
    }
}
