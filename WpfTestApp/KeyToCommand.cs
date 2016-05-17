using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfTestApp
{
    class KeyToCommand
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(KeyToCommand), new FrameworkPropertyMetadata((ICommand)null, new PropertyChangedCallback(OnCommandPropertyChanged)));

        public static void SetCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(CommandProperty, c);
        }

        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        public static readonly DependencyProperty KeyNameProperty =
            DependencyProperty.RegisterAttached("KeyName", typeof(Key?), typeof(KeyToCommand), new FrameworkPropertyMetadata((Key?)null));

        public static void SetKeyName(DependencyObject d, Key? k)
        {
            d.SetValue(KeyNameProperty, k);
        }

        public static Key? GetKeyName(DependencyObject d)
        {
            return (Key?)d.GetValue(KeyNameProperty);
        }

        private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiEl = (UIElement)d;
            uiEl.KeyDown -= invokeCommand;
            if(e.NewValue != null)
            uiEl.KeyDown += invokeCommand;
        }

        private static void invokeCommand(object source, KeyEventArgs e)
        {
            DependencyObject d = (DependencyObject)source;
            ICommand toExecute = GetCommand(d);
            if (e.Key == GetKeyName(d))
            toExecute?.Execute(((FrameworkElement)d).Name);
        }
    }
}
