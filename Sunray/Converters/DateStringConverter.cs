using System;
using Xamarin.Forms;

namespace Sunray
{
	public class DateStringConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// TODO: Check if this converter is working
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;
			string day = "";
			var abbrevDay = stringValue.Substring(0,3);
			if (String.Equals (abbrevDay, "Sun"))
			{
				day = "Sunday";
			}
			if (String.Equals (abbrevDay, "Mon"))
			{
				day = "Monday";
			}
			if (String.Equals (abbrevDay, "Tue"))
			{
				day = "Tuesday";
			}
			if (String.Equals (abbrevDay, "Wed"))
			{
				day = "Wednesday";
			}
			if (String.Equals (abbrevDay, "Thu"))
			{
				day = "Thursday";
			}
			if (String.Equals (abbrevDay, "Fri"))
			{
				day = "Friday";
			}
			if (String.Equals (abbrevDay, "Sat"))
			{
				day = "Saturday";
			}
			var date = stringValue.Substring (3, 8);

			return string.Format("{0}{1}", day, date);
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

