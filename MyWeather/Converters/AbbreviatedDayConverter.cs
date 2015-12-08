using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class AbbreviatedDayConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;

			if (String.Equals (stringValue, "Tomorrow"))
			{
				return "Tomorrow";
			}
			if (String.Equals (stringValue, "Sun"))
			{
				return "Sunday";
			}
			if (String.Equals (stringValue, "Mon"))
			{
				return "Monday";
			}
			if (String.Equals (stringValue, "Tue"))
			{
				return "Tuesday";
			}
			if (String.Equals (stringValue, "Wed"))
			{
				return "Wednesday";
			}
			if (String.Equals (stringValue, "Thu"))
			{
				return "Thursday";
			}
			if (String.Equals (stringValue, "Fri"))
			{
				return "Friday";
			}
			if (String.Equals (stringValue, "Sat"))
			{
				return "Saturday";
			}
			return "";
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

