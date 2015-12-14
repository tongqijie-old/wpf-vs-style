namespace VsStyle.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    class TreeNodeLevel2LeadingConverter : IValueConverter
    {
        public int Level { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var level = (int)value;

            if (level <= 1)
            {
                return new Thickness(level * 8, 0, 0, 0);
            }
            else
            {
                return new Thickness(8 + (level - 1) * 20, 0, 0, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
