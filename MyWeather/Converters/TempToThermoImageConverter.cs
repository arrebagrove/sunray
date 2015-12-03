using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class TempToThermoImageConverter : IValueConverter
	{
		// TODO: This is only for F - need to support C

		#region IValueConverter implementation
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType () != typeof(int))
			{
				throw new Exception ("Value is not an int");
			}

			var code = (int)value;
			if (code < 40)
			{
				return "thermo-cold.png";
			}
			else if (code > 40 && code < 80)
			{
				return "thermo-mild.png";
			}
			return "thermo-hot.png";	
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

