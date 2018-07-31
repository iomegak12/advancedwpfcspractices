using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomAttachedProps
{
    public static class AttachedPropertiesProvider
    {
        public static int GetMinimumCharacters(DependencyObject obj)
        {
            return (int)obj.GetValue(MinimumCharactersProperty);
        }

        public static void SetMinimumCharacters(DependencyObject obj, int value)
        {
            obj.SetValue(MinimumCharactersProperty, value);
        }

        public static readonly DependencyProperty MinimumCharactersProperty =
            DependencyProperty.RegisterAttached("MinimumCharacters",
                typeof(int), typeof(AttachedPropertiesProvider),
                new PropertyMetadata(0, new PropertyChangedCallback(HandlePropertyChanged)));

        private static void HandlePropertyChanged(
            DependencyObject dependencyObject, DependencyPropertyChangedEventArgs changedEventArgs)
        {
            var sourceTextBox = dependencyObject as TextBox;

            if (sourceTextBox != default(TextBox))
            {
                sourceTextBox.TextChanged += (sender, args) =>
                {
                    var noOfCharactersEntered = sourceTextBox.Text.Length;
                    var noOfExpectedCharacters = (int)sourceTextBox.GetValue(MinimumCharactersProperty);

                    var isValid = noOfCharactersEntered >= noOfExpectedCharacters;

                    if (!isValid)
                        sourceTextBox.Background = new SolidColorBrush(Colors.Red);
                    else sourceTextBox.Background =
                        new SolidColorBrush(Colors.LightGreen);
                };
            }
        }
    }
}
