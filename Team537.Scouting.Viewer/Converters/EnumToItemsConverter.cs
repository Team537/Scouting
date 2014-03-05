using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team537.Scouting.Viewer.Converters
{
    using Windows.UI.Xaml.Data;

    public class EnumToItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumType = value as Type;
            var dict = new Dictionary<object, string>();
            foreach (var val in Enum.GetValues(enumType))
            {
                dict.Add(val, Enum.GetName(enumType, val));
            }

            return dict;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
