using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HUCE_DALTUDXD_LOP30_2026_0176667.Converters
{
    public class DecimalInputConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                float floatValue => floatValue.ToString("0.########", CultureInfo.InvariantCulture),
                double doubleValue => doubleValue.ToString("0.########", CultureInfo.InvariantCulture),
                decimal decimalValue => decimalValue.ToString("0.########", CultureInfo.InvariantCulture),
                _ => value?.ToString() ?? string.Empty
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (value as string)?.Trim().Replace(',', '.') ?? string.Empty;
            if (string.IsNullOrWhiteSpace(text) || IsIncompleteDecimal(text))
            {
                return Binding.DoNothing;
            }

            if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
            {
                return DependencyProperty.UnsetValue;
            }

            var type = Nullable.GetUnderlyingType(targetType) ?? targetType;
            if (type == typeof(float))
            {
                return (float)number;
            }

            if (type == typeof(decimal))
            {
                return (decimal)number;
            }

            return number;
        }

        private static bool IsIncompleteDecimal(string text)
        {
            return text is "+" or "-" or "." or "," or "+." or "-." ||
                   text.EndsWith(".", StringComparison.Ordinal);
        }
    }
}
