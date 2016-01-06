namespace VsStyle.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    class Nullable2ObjectConverter : IValueConverter
    {
        public object ValueIfNull { get; set; }

        public object ValueIfNotNull { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? ValueIfNull : ValueIfNotNull;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
