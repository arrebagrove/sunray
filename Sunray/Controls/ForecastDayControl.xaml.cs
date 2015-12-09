using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Sunray.API;

namespace Sunray
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

