using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class CodeToDarkImageStringConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;

			int code;
			bool result = Int32.TryParse(stringValue, out code);
			if (!result)
			{
				throw new Exception ("String could not be parsed to int");
			}

			if (code == 0 || code == 1 || code == 2 ||
			    code == 3 || code == 17)
			{
				return "warning-dark.png";
			}
			if (code == 4 || code == 37 ||code == 38 || 
				code == 39 || code == 45 || code == 47)
			{
				return "thunderstorms-dark.png";
			}
			if (code == 5 || code == 6 ||code == 10 || 
				code == 11 || code == 12 || code == 18 ||
				code == 35 || code == 40)
			{
				return "rain-dark.png";
			}
			if (code == 8 || code == 9)
			{
				return "light-rain-dark.png";
			}
			if (code == 7 || code == 13 ||code == 14 || 
				code == 15 || code == 16 || code == 25 ||
				code == 41 || code == 42 || code == 43 || code == 46)
			{
				return "snow-dark.png";
			}
			if (code == 19 || code == 20 ||code == 21 || code == 22)
			{
				return "fog-dark.png";
			}
			if (code == 23 || code == 24)
			{
				return "wind-dark.png";
			}
			if (code == 26 || code == 44)
			{
				return "cloudy-dark.png";
			}
			if (code == 27 || code == 29)
			{
				return "cloudy-moon-dark.png";
			}
			if (code == 28 || code == 30)
			{
				return "cloudy-sun-dark.png";
			}
			if (code == 31 || code == 33)
			{
				return "moon-dark.png";
			}
			if (code == 32 || code == 34 || code == 36)
			{
				return "sun-dark.png";
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

