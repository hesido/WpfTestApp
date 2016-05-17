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

        private static void OnEnterKeyToCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiEl = (UIElement)d;
            uiEl.KeyDown -= invokeCommand;
            if(e.NewValue != null)
            uiEl.KeyDown += invokeCommand;
        }

        private static void invokeCommand(object source, KeyEventArgs e)
        {
            ICommand toExecute = GetEnterKeyToCommand((DependencyObject)source);
            if (e.Key == Key.Enter)
            toExecute?.Execute(null);
        }
    }
}
