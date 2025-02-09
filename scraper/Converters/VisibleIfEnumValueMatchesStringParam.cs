﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Converters
{
   
    /// <summary>
    /// pass a string param to the converter and any Enum based type , returns visible if the string
    ///  representation of the value equals the param
    /// returns visible on any bad usage, exception safe
    /// </summary>
    [ValueConversion(typeof(Enum),typeof(Visibility))]
    public class VisibleIfEnumValueMatchesStringParam : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!((value is Enum  ) &&(parameter is string )))
            {
                return Visibility.Visible;
            }
           
            return (Enum.GetName(value.GetType(), (Enum)value) ==((string)parameter)? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    
  

}
