using System;
using Xamarin.Forms;

namespace Sunray
{
	public class TempToThermoImageConverter : IValueConverter
	{
		// TODO: This is only for F - need to support C

		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(string))
			{
				throw new Exception ("Value is not a string");
			}
			var stringValue = (string) value;

			int temp;
			bool result = Int32.TryParse(stringValue, out temp);
			if (!result)
			{
				throw new Exception ("String could not be parsed to int");
			}

			if (temp < 40)
			{
				return "thermo_cold.png";
			}
			else if (temp > 40 && temp < 80)
			{
				return "thermo_mild.png";
			}
			return "thermo_hot.png";	
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

