using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class DateStringConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;
			// take first three letters and convert to whole word
			// put whole word back into string and cut off everything after date
			return "";
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

