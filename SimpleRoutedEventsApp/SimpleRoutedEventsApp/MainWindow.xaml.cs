using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleRoutedEventsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var sourceTextBox = e.OriginalSource as TextBox;

            if (sourceTextBox != default(TextBox))
            {
                sourceTextBox.Text = sourceTextBox.Text.ToUpper();
                sourceTextBox.Select(sourceTextBox.Text.Length, 0);

                e.Handled = sourceTextBox.Text.Length <= 5;
            }
        }

        private void HandleTextChangedAtWindow(object sender, TextChangedEventArgs e)
        {
            var sourceTextBox = e.OriginalSource as TextBox;

            if (sourceTextBox != default(TextBox))
            {
                var random = new Random();

                sourceTextBox.Foreground = new SolidColorBrush(
                    Color.FromRgb(
                        (byte)random.Next(1, 255),
                        (byte)random.Next(1, 255),
                        (byte)random.Next(1, 255)));
            }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Preview Mouse Down @ Button!");
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Preview Mouse Down @ Grid!");

            //e.Handled = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Preview Mouse Down @ Window!");
        }
    }
}
