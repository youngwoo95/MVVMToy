using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace SlideMenuBarExample.Helpers
{
    public static class DataGridRowDoubleClickBehavior
    {
        public static readonly DependencyProperty DoubleClickCommandProperty =
        DependencyProperty.RegisterAttached(
           "DoubleClickCommand",
           typeof(ICommand),
           typeof(DataGridRowDoubleClickBehavior),
           new UIPropertyMetadata(null, OnDoubleClickCommandChanged));

        public static ICommand GetDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DoubleClickCommandProperty);
        }
        public static void SetDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DoubleClickCommandProperty, value);
        }

        private static void OnDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGridRow row)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    row.MouseDoubleClick += Row_MouseDoubleClick;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    row.MouseDoubleClick -= Row_MouseDoubleClick;
                }
            }
        }

        private static void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                var command = GetDoubleClickCommand(row);
                if (command != null && command.CanExecute(row.Item))
                {
                    command.Execute(row.Item);
                }
            }
        }
    }
}
