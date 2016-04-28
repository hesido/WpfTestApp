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
    class ListBoxHelper
    {
        //Code from: https://dzone.com/articles/sync-multi-select-listbox
        #region SelectedItems

        /// <summary>
        /// SelectedItems Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(ListBoxHelper),
                new FrameworkPropertyMetadata((IList)null,
                    new PropertyChangedCallback(OnSelectedItemsChanged)));

        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        /// <summary>
        /// Handles changes to the SelectedItems property.
        /// </summary>
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox)d;
            ReSetSelectedItems(listBox);
            listBox.SelectionChanged += delegate
            {
                ReSetSelectedItems(listBox);
            };
        }

        #endregion

        private static void ReSetSelectedItems(ListBox listBox)
        {
            IList selectedItems = GetSelectedItems(listBox);
            selectedItems.Clear();
            if (listBox.SelectedItems != null)
            {
                foreach (var item in listBox.SelectedItems)
                    selectedItems.Add(item);
            }
        }

    }

    class DataGridColumnControl
    {
        //Code from: https://dzone.com/articles/sync-multi-select-listbox
        public static readonly DependencyProperty ColumnControlProperty =
            DependencyProperty.RegisterAttached("ColumnControl", typeof(string[]), typeof(DataGridColumnControl),
                new FrameworkPropertyMetadata((string[])null,
                    new PropertyChangedCallback(Setup)));

        public static string[] GetColumnControl(DependencyObject d)
        {
            return (string[])d.GetValue(ColumnControlProperty);
        }

        public static void SetColumnControl(DependencyObject d, string[] value)
        {
            d.SetValue(ColumnControlProperty, value);
        }

        /// <summary>
        /// Handles changes to the SelectedItems property.
        /// </summary>
        //private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var listBox = (ListBox)d;
        //    ReSetSelectedItems(listBox);
        //    listBox.SelectionChanged += delegate
        //    {
        //        ReSetSelectedItems(listBox);
        //    };
        //}


        private static void Setup(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("Setup yo {0}", e.NewValue);
            DataGrid DataGr = (DataGrid)d;
            DataGr.Height = 75;
            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "Hohoho";
            MyAttachedString.SetAttachedString(DataGr, "changed that string");
            DataGr.Columns.Add(textColumn);

        }

   


        //private static void ReSetSelectedItems(ListBox listBox)
        //{
        //    IList selectedItems = GetColumnNames(listBox);
        //    selectedItems.Clear();
        //    if (listBox.SelectedItems != null)
        //    {
        //        foreach (var item in listBox.SelectedItems)
        //            selectedItems.Add(item);
        //    }
        //}


    }

    class MyAttachedString
    {
        public static readonly DependencyProperty AttachedStringProperty =
            DependencyProperty.RegisterAttached("AttachedString", typeof(string), typeof(MyAttachedString), new PropertyMetadata(null));

        public static string GetAttachedString(DependencyObject d)
        {
            return (string)d.GetValue(AttachedStringProperty);
        }

        public static void SetAttachedString(DependencyObject d, string value)
        {
            d.SetValue(AttachedStringProperty, value);
        }

    }
}
