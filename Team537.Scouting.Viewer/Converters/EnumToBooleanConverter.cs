using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.Converters
{
    using Windows.UI.Xaml.Data;

    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fullValue = System.Convert.ToInt32(value);
            var checkvalue = System.Convert.ToInt32(parameter);

            return (checkvalue & fullValue) > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var fullValue = System.Convert.ToInt32(value);
            var checkvalue = System.Convert.ToInt32(parameter);

            return fullValue | checkvalue;
        }
    }
}
