using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class WindDegreesToDirectionConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;

			double degrees;
			bool result = Double.TryParse(stringValue, out degrees);
			if (!result)
			{
				throw new Exception ("String could not be parsed to double");
			}
				
			if (degrees > 348.75 || degrees < 11.25)
				return "N";
			else if (degrees > 11.25 && degrees < 33.75)
				return "NNE";
			else if (degrees > 33.75 && degrees < 56.25)
				return "NE";
			else if (degrees > 56.25 && degrees < 78.75)
				return "ENE";
			else if (degrees > 78.75 && degrees < 101.25)
				return "E";
			else if (degrees > 101.25 && degrees < 123.75)
				return "ESE";
			else if (degrees > 123.75 && degrees < 146.25)
				return "SE";
			else if (degrees > 146.25 && degrees < 168.75)
				return "SSE";
			else if (degrees > 168.75 && degrees < 191.25)
				return "S";
			else if (degrees > 191.25 && degrees < 213.75)
				return "SSW";
			else if (degrees > 213.75 && degrees < 236.25)
				return "SW";
			else if (degrees > 236.25 && degrees < 258.75)
				return "WSW";
			else if (degrees > 258.75 && degrees < 281.25)
				return "W";
			else if (degrees > 281.25 && degrees < 303.75)
				return "WNW";
			else if (degrees > 303.75 && degrees < 326.25)
				return "NW";
			else if (degrees > 326.25 && degrees < 348.75)
				return "NNW";
			else return "";
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

