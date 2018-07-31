using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CommandsLibrary
{
    public static class CommandPropertiesProvider
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(CommandPropertiesProvider),
                new PropertyMetadata(
                    default(ICommand),
                    new PropertyChangedCallback(HandleCommandChanged)));


        public static void HandleCommandChanged(
            DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var selector = dependencyObject as Selector;

            if (selector != default(Selector))
            {
                selector.SelectionChanged += (sender, args) =>
                {
                    var command = selector.GetValue(CommandProperty) as ICommand;
                    var commandParameter = selector.GetValue(CommandParameterProperty);

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
                typeof(CommandPropertiesProvider),
                new PropertyMetadata(
                    default(object)));
    }
}
