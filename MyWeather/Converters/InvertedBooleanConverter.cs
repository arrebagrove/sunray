using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class InvertedBooleanConverter : IValueConverter
	{
		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(bool))
			{
				throw new Exception ("Value is not a bool");
			}

			var booleValue = (bool)value;
			return !booleValue;
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

