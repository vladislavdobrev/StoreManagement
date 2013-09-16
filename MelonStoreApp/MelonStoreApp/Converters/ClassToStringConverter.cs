using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Data;

namespace MelonStoreApp.Converters
{
    public class ClassToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value==null? "": value.GetType().Name.ToString();
       } 

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
