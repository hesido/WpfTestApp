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
        public static readonly DependencyProperty EnterKeyToCommandProperty =
            DependencyProperty.RegisterAttached("EnterKeyToCommand", typeof(ICommand), typeof(KeyToCommand), new FrameworkPropertyMetadata((ICommand)null, new PropertyChangedCallback(OnEnterKeyToCommandPropertyChanged)));

        public static void SetEnterKeyToCommand(DependencyObject d, ICommand c)
        {
            d.SetValue(EnterKeyToCommandProperty, c);
        }

        public static ICommand GetEnterKeyToCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(EnterKeyToCommandProperty);
        }

        public static readonly DependencyProperty WhichKeyProperty =
            DependencyProperty.RegisterAttached("WhichKey", typeof(Key?), typeof(KeyToCommand), new FrameworkPropertyMetadata((Key?)null));

        public static void SetWhichKey(DependencyObject d, Key? k)
        {
            d.SetValue(WhichKeyProperty, k);
        }

        public static Key? GetWhichKey(DependencyObject d)
        {
            return (Key?)d.GetValue(WhichKeyProperty);
        }

        private static void OnEnterKeyToCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiEl = (UIElement)d;
            uiEl.KeyDown -= invokeCommand;
            if(e.NewValue != null)
            uiEl.KeyDown += invokeCommand;
        }

        private static void invokeCommand(object source, KeyEventArgs e)
        {
            DependencyObject d = (DependencyObject)source;
            ICommand toExecute = GetEnterKeyToCommand(d);
            if (e.Key == GetWhichKey(d))
            toExecute?.Execute(null);
        }
    }
}
