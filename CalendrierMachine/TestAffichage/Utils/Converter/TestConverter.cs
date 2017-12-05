using System;
using System.Globalization;
using System.Windows.Data;

namespace TestAffichage.Utils.Converter
{
    public class TestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Contains(".5"))
            {
                return value.ToString().Replace(".5", "h30");
            }
            else
            {
                return value.ToString()+"h00";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float res;
            string _value = value.ToString().ToLower();
            if (_value.Contains("h30") && (_value.Length == 4 || _value.Length == 5))
            {
                float.TryParse(_value.Replace("h30", ".5"), out res);
                return res;
            }
            else if (!_value.Contains("h30"))
            {
                if (_value.Contains("h00"))
                {
                    float.TryParse(_value.Replace("h00", ""), out res);
                    return res;
                }
                if (_value.Length == 1)
                {
                    float.TryParse(_value.Substring(0, 1), out res);
                    return res;
                }
                else if (_value.Length == 2)
                {
                    float.TryParse(_value.Substring(0, 2), out res);
                    return res;
                }
            }
            return "";
        }
    }
}

