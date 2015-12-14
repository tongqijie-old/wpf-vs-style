namespace VsStyle.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    class Boolean2VisibilityConverter : IValueConverter
    {
        public bool Inverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!Inverse)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
