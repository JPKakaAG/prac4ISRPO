using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace prac4ISRPO
{
    public class FractalTree
    {
        private double angle;
        private Color startColor;
        private Color endColor;

        public FractalTree(double angle, Color startColor, Color endColor)
        {
            this.angle = angle;
            this.startColor = startColor;
            this.endColor = endColor;
        }

        public void Draw(Canvas canvas, double x, double y, double length, int depth)
        {
            try
            {
                if (depth == 0) return;

                double xEnd = x + length * Math.Cos(angle);
                double yEnd = y - length * Math.Sin(angle);

                Line line = new Line
                {
                    X1 = x,
                    Y1 = y,
                    X2 = xEnd,
                    Y2 = yEnd,
                    Stroke = new SolidColorBrush(GetColor(depth)),  // Преобразование Color в Brush
                    StrokeThickness = depth
                };
                canvas.Children.Add(line);

                FractalTree leftBranch = new FractalTree(angle - Math.PI / 6, startColor, endColor);
                FractalTree rightBranch = new FractalTree(angle + Math.PI / 6, startColor, endColor);

                leftBranch.Draw(canvas, xEnd, yEnd, length * 0.7, depth - 1);
                rightBranch.Draw(canvas, xEnd, yEnd, length * 0.7, depth - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error drawing fractal tree: {ex.Message}");
            }
        }

        private Color GetColor(int depth)
        {
            double ratio = (double)depth / 10;
            byte r = (byte)(startColor.R + (endColor.R - startColor.R) * ratio);
            byte g = (byte)(startColor.G + (endColor.G - startColor.G) * ratio);
            byte b = (byte)(startColor.B + (endColor.B - startColor.B) * ratio);
            return Color.FromArgb(255, r, g, b);
        }
    }

}
