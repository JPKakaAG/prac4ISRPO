using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using prac4ISRPO;



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Media.Color startColor;
        private System.Windows.Media.Color endColor;

        public MainWindow()
        {
            InitializeComponent();
            // Установка начальных цветов
            startColor = Colors.Yellow;
            endColor = Colors.Blue;
        }

        private void FractalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FractalComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedFractal = selectedItem.Content.ToString();

                // Изменение видимости элементов на основании выбора
                if (selectedFractal == "Фрактальное дерево" || selectedFractal == "Кривая Коха")
                {
                    StartColorButton.Visibility = Visibility.Visible;
                    EndColorButton.Visibility = Visibility.Visible;
                }
                else
                {
                    StartColorButton.Visibility = Visibility.Collapsed;
                    EndColorButton.Visibility = Visibility.Collapsed;
                }

                StartColorLabel.Content = "Выберите цвет начальной итерации:";
                EndColorLabel.Content = "Выберите цвет конечной итерации:";
            }
        }

        private void IncreaseIterationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IterationsTextBox.Text, out int currentValue))
            {
                IterationsTextBox.Text = (currentValue + 1).ToString();
            }
        }

        private void DecreaseIterationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IterationsTextBox.Text, out int currentValue) && currentValue > 1)
            {
                IterationsTextBox.Text = (currentValue - 1).ToString();
            }
        }

        private void StartColorButton_Click(object sender, RoutedEventArgs e)
        {
            var color = ShowColorDialog(startColor);
            if (color != null)
            {
                startColor = (System.Windows.Media.Color)color;
                StartColorLabel.Content = startColor.ToString();
            }
        }

        private void EndColorButton_Click(object sender, RoutedEventArgs e)
        {
            var color = ShowColorDialog(endColor);
            if (color != null)
            {
                endColor = (System.Windows.Media.Color)color;
                EndColorLabel.Content = endColor.ToString();
            }
        }

        private System.Windows.Media.Color? ShowColorDialog(System.Windows.Media.Color initialColor)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog
            {
                Color = System.Drawing.Color.FromArgb(initialColor.A, initialColor.R, initialColor.G, initialColor.B)
            };

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return System.Windows.Media.Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
            return null;
        }

        private void DrawFractalButton_Click(object sender, RoutedEventArgs e)
        {
            FractalCanvas.Children.Clear();

            if (int.TryParse(IterationsTextBox.Text, out int iterations))
            {
                switch (FractalComboBox.SelectedItem)
                {
                    case ComboBoxItem item when item.Content.ToString() == "Фрактальное дерево":
                        FractalTree fractalTree = new FractalTree(Math.PI / 2, startColor, endColor);
                        fractalTree.Draw(FractalCanvas, FractalCanvas.Width / 2, FractalCanvas.Height, 100, iterations);
                        break;

                    case ComboBoxItem item when item.Content.ToString() == "Кривая Коха":
                        KochCurve kochCurve = new KochCurve();
                        kochCurve.Draw(FractalCanvas, new System.Windows.Point(100, 300), new System.Windows.Point(700, 300), iterations);
                        break;

                    case ComboBoxItem item when item.Content.ToString() == "Ковер Серпинского":
                        SierpinskiCarpet carpet = new SierpinskiCarpet();
                        carpet.Draw(FractalCanvas, 0, 0, FractalCanvas.Width, iterations);
                        break;

                    case ComboBoxItem item when item.Content.ToString() == "Треугольник Серпинского":
                        SierpinskiTriangle triangle = new SierpinskiTriangle();
                        triangle.Draw(FractalCanvas, new System.Windows.Point(400, 50), new System.Windows.Point(50, 600), new System.Windows.Point(750, 600), iterations);
                        break;

                    case ComboBoxItem item when item.Content.ToString() == "Множество Кантора":
                        CantorSet cantor = new CantorSet();
                        cantor.Draw(FractalCanvas, 50, 100, FractalCanvas.Width - 100, iterations);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Введите корректное количество итераций.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
