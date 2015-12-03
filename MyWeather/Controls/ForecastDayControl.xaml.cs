using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MyWeather.API;

namespace MyWeather
{
	public partial class ForecastDayControl : ContentView
	{
		public ForecastDayControl (Forecast forecast)
		{
			InitializeComponent ();
			this.BindingContext = forecast;
		}
	}
}

