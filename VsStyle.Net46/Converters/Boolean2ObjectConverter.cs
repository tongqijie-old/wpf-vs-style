namespace VsStyle.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    class Boolean2ObjectConverter : IValueConverter
    {
        public object ValueIfTrue { get; set; }

        public object ValueIfFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ValueIfTrue : ValueIfFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
