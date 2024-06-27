using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RecipeAppWPF
{
    public static class WatermarkBehavior
    {
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(WatermarkBehavior), new UIPropertyMetadata(null, OnWatermarkChanged));

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.Loaded += TextBox_Loaded;
                textBox.GotFocus += TextBox_GotFocus;
                textBox.LostFocus += TextBox_LostFocus;
            }
        }

        private static void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWatermarkVisibility(sender as TextBox);
        }

        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.ClearValue(TextBox.ForegroundProperty);
                textBox.ClearValue(TextBox.FontWeightProperty);
            }
        }

        private static void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UpdateWatermarkVisibility(sender as TextBox);
        }

        private static void UpdateWatermarkVisibility(TextBox textBox)
        {
            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Foreground = SystemColors.GrayTextBrush;
                    textBox.FontWeight = FontWeights.Light;
                    textBox.Text = GetWatermark(textBox);
                }
                else
                {
                    textBox.Foreground = SystemColors.ControlTextBrush;
                    textBox.FontWeight = FontWeights.Normal;
                }
            }
        }
    }
}
