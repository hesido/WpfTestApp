using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTestApp
{
    class CheckBoxHelper
    {
        public static readonly DependencyProperty checkedItemProperty =
            DependencyProperty.RegisterAttached("CheckedItem", typeof(object), typeof(CheckBoxHelper),
        new FrameworkPropertyMetadata(null,
            new PropertyChangedCallback(onInteract)));

        public static object GetCheckedItem(DependencyObject d)
        {
            return d.GetValue(checkedItemProperty);
        }

        public static void SetCheckedItem(DependencyObject d, object value)
        {
            d.SetValue(checkedItemProperty, value);
        }

        private static void onInteract(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var _checkBox = (CheckBox)d;
            Console.WriteLine("{0} |||| {1}", _checkBox.DataContext, _checkBox.DataContext.GetType());
            _checkBox.Checked += checkControl;
            _checkBox.Unchecked += unCheckControl;
        }

        private static void checkControl(object sender, RoutedEventArgs e)
        {
        //    Console.WriteLine(((CheckBox)e.Source).IsChecked);
            var _checkBox = (CheckBox)e.Source;
            //Broken
            //((ListBox)((StackPanel)_checkBox.Parent).Parent).SelectedItems.Add(_checkBox.DataContext);
        }

        private static void unCheckControl(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(((CheckBox)e.Source).IsChecked);
        }
    }

}
