using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Alstom.Libraries.UI.Extensibility
{
    public static class AttachedPropertiesProvider
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(AttachedPropertiesProvider),
                new PropertyMetadata(
                    default(ICommand),
                    new PropertyChangedCallback(HandleCommandChanged)));

        public static void HandleCommandChanged(
            DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var uiElement = dependencyObject as UIElement;

            if (uiElement != default(UIElement))
            {
                uiElement.MouseDown += (sender, args) =>
                {
                    var command = uiElement.GetValue(CommandProperty) as ICommand;
                    var commandParameter = uiElement.GetValue(CommandParameterProperty);

                    if (command != default(ICommand) &&
                        command.CanExecute(commandParameter))
                        command.Execute(commandParameter);
                };
            }
        }


        public static object GetCommandParameter(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "CommandParameter",
                typeof(object),
                typeof(AttachedPropertiesProvider),
                new PropertyMetadata(
                    default(object)));
    }
}
