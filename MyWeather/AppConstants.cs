using System;
using Xamarin.Forms;

namespace Sunray
{
	public class AppConstants
	{
		// Padding
		public static readonly Thickness TopItemPadding =
			new Thickness(0, Device.OnPlatform(30, 10, 10), 0, 0);
		public static readonly Thickness TopLabelsPadding = 
			new Thickness(10, Device.OnPlatform(30, 10, 10), 10, 0);

		// Fonts
		public static string ApplicationFont =  
			Device.OnPlatform("Avenir Next", "Roboto-Light", "Segoe UI-Light");

		// Font Sizes
		public static double SmallFontSize = Device.OnPlatform(14,14,14);
		public static double MediumFontSize = Device.OnPlatform(18,18,18);
		public static double LargeFontSize = Device.OnPlatform(24,24,24);
		public static double ExtraLargeFontSize = Device.OnPlatform(115,115,115);

		// Colors
		public static Color DarkBlueColor = Color.FromHex("34495E");
		public static Color WhiteColor = Color.FromHex("F2F1EF");
		public static Color DarkGrayColor = Color.FromHex("2F3737");
		public static Color GreenColor = Color.FromHex("00B16A");

	}
}

