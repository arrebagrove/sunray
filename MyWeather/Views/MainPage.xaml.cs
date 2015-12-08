using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace MyWeather
{
	public partial class MainPage : ContentPage
	{
		private MainViewModel viewModel;
		private int currentForecastIndex = 0;
		private ForecastDayControl tomorrowForecastControl;
		private ForecastDayControl dayTwoForecastControl;
		private ForecastDayControl dayThreeForecastControl;
		private ForecastDayControl dayFourForecastControl;

		public MainPage ()
		{
			InitializeComponent ();

			viewModel = new MainViewModel ();
			this.BindingContext = viewModel.Channel;

			// Check temp label size

			SubscribeBoxViewMain ();
			SetUpForecastViews ();
		}

		private void SetUpForecastViews ()
		{
			// There are 5 days in the forecast
			// The first one is today because Yahoo is lame
			var forecastList = viewModel.Channel.Item.Forecast;
			var todayForecast = forecastList [0];
			labelHighTemp.Text = String.Format ("{0}°", todayForecast.High);
			labelLowTemp.Text = String.Format ("{0}°", todayForecast.Low);

			var tomorrowForecast = forecastList [1];
			tomorrowForecast.Day = "Tomorrow";
			tomorrowForecastControl = new ForecastDayControl (tomorrowForecast);
			relativeLayoutForecast.Children.Add (tomorrowForecastControl,
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			var dayTwoForecast = forecastList [2];
			dayTwoForecastControl = new ForecastDayControl (dayTwoForecast);
			relativeLayoutForecast.Children.Add (dayTwoForecastControl,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			var dayThreeForecast = forecastList [3];
			dayThreeForecastControl = new ForecastDayControl (dayThreeForecast);
			relativeLayoutForecast.Children.Add (dayThreeForecastControl,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width * 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			var dayFourForecast = forecastList [4];
			dayFourForecastControl = new ForecastDayControl (dayFourForecast);
			relativeLayoutForecast.Children.Add (dayFourForecastControl,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width * 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			SubscribeBoxViewForecastLeft ();
			SubscribeBoxViewForecastRight ();
		}

		#region Swipe Handlers

		private void BoxViewCitiesSwipedUp (object sender, EventArgs e) 
		{
			MoveDownToMain ();
			UnSubscribeBoxViewCities ();
		}

		private void BoxViewMainSwipedUp (object sender, EventArgs e)
		{
			MoveToSettings ();
			UnSubscribeBoxViewMain ();
		}

		private void BoxViewMainSwipedDown (object sender, EventArgs e) 
		{
			MoveToCities ();
			UnSubscribeBoxViewMain ();
		}

		private void BoxViewSettingsSwipedDown (object sender, EventArgs e) 
		{
			MoveUpToMain ();
			UnSubscribeBoxViewSettings ();
		}

		private void MoveToCities()
		{
			var pageHeight = gridMainContent.Height;

			var citiesRect = new Rectangle (0, 0, gridCities.Width, gridCities.Height);
			gridCities.LayoutTo (citiesRect, 300, Easing.SinIn);
			var mainRect = new Rectangle (0, gridMainContent.Height, gridMainContent.Width, gridMainContent.Height);
			gridMainContent.LayoutTo (mainRect, 300, Easing.SinIn);

			SubscribeBoxViewCities ();
		}

		private void MoveDownToMain()
		{
			var pageHeight = gridMainContent.Height;

			var citiesRect = new Rectangle (0, -gridCities.Height, gridCities.Width, gridCities.Height);
			gridCities.LayoutTo (citiesRect, 300, Easing.SinIn);
			var mainRect = new Rectangle (0, 0, gridMainContent.Width, gridMainContent.Height);
			gridMainContent.LayoutTo (mainRect, 300, Easing.SinIn);

			SubscribeBoxViewMain ();
		}

		private void MoveUpToMain()
		{
			var pageHeight = gridMainContent.Height;

			var settingsRect = new Rectangle (0, gridSettings.Height, gridSettings.Width, gridSettings.Height);
			gridSettings.LayoutTo (settingsRect, 300, Easing.SinIn);
			var mainRect = new Rectangle (0, 0, gridMainContent.Width, gridMainContent.Height);
			gridMainContent.LayoutTo (mainRect, 300, Easing.SinIn);

			SubscribeBoxViewMain ();
		}

		private void MoveToSettings()
		{
			var pageHeight = gridMainContent.Height;

			var settingsRect = new Rectangle (0, 0, gridSettings.Width, gridSettings.Height);
			gridSettings.LayoutTo (settingsRect, 300, Easing.SinIn);
			var mainRect = new Rectangle (0, -gridMainContent.Height, gridMainContent.Width, gridMainContent.Height);
			gridMainContent.LayoutTo (mainRect, 300, Easing.SinIn);

			SubscribeBoxViewSettings ();
		}

		private void BoxViewForecastSwipedLeft(object sender, EventArgs e)
		{
			if (currentForecastIndex == 3)
			{
				return;
			}

			currentForecastIndex++;
				
			if (currentForecastIndex == 1)
			{
				MoveForecastToDayTwo ();
			}
			if (currentForecastIndex == 2)
			{
				MoveForecastToDayThree ();
			}
			if (currentForecastIndex == 3)
			{
				MoveForecastToDayFour ();
			}
		}

		private void BoxViewForecastSwipedRight(object sender, EventArgs e)
		{
			if (currentForecastIndex == 0)
			{
				return;
			}
			
			currentForecastIndex--;

			var pageWidth = boxViewForecast.Width;

			if (currentForecastIndex == 0)
			{
				MoveForecastToTomorrow ();
			}
			if (currentForecastIndex == 1)
			{
				MoveForecastToDayTwo ();
			}
			if (currentForecastIndex == 2)
			{
				MoveForecastToDayThree ();
			}
		}

		private void MoveForecastToTomorrow()
		{
			var tomorrowRect = new Rectangle (0, 0, 
				tomorrowForecastControl.Width, tomorrowForecastControl.Height);
			var dayTwoRect = new Rectangle (dayTwoForecastControl.Width, 0, 
				dayTwoForecastControl.Width, dayTwoForecastControl.Height);
			var dayThreeRect = new Rectangle (dayThreeForecastControl.Width * 2, 0, 
				dayThreeForecastControl.Width, dayThreeForecastControl.Height);
			var dayFourRect = new Rectangle (dayFourForecastControl.Width * 3, 0, 
				dayFourForecastControl.Width, dayFourForecastControl.Height);

			tomorrowForecastControl.LayoutTo (tomorrowRect, 300, Easing.CubicInOut);
			dayTwoForecastControl.LayoutTo (dayTwoRect, 300, Easing.CubicInOut);
			dayThreeForecastControl.LayoutTo (dayThreeRect, 300, Easing.CubicInOut);
			dayFourForecastControl.LayoutTo (dayFourRect, 300, Easing.CubicInOut);
		}

		private void MoveForecastToDayTwo()
		{
			var tomorrowRect = new Rectangle (-tomorrowForecastControl.Width, 0, 
				tomorrowForecastControl.Width, tomorrowForecastControl.Height);
			var dayTwoRect = new Rectangle (0, 0, 
				dayTwoForecastControl.Width, dayTwoForecastControl.Height);
			var dayThreeRect = new Rectangle (dayThreeForecastControl.Width, 0, 
				dayThreeForecastControl.Width, dayThreeForecastControl.Height);
			var dayFourRect = new Rectangle (dayFourForecastControl.Width * 2, 0, 
				dayFourForecastControl.Width, dayFourForecastControl.Height);

			tomorrowForecastControl.LayoutTo (tomorrowRect, 300, Easing.CubicInOut);
			dayTwoForecastControl.LayoutTo (dayTwoRect, 300, Easing.CubicInOut);
			dayThreeForecastControl.LayoutTo (dayThreeRect, 300, Easing.CubicInOut);
			dayFourForecastControl.LayoutTo (dayFourRect, 300, Easing.CubicInOut);
		}

		private void MoveForecastToDayThree()
		{
			var tomorrowRect = new Rectangle (-tomorrowForecastControl.Width * 2, 0, 
				tomorrowForecastControl.Width, tomorrowForecastControl.Height);
			var dayTwoRect = new Rectangle (-dayTwoForecastControl.Width, 0, 
				dayTwoForecastControl.Width, dayTwoForecastControl.Height);
			var dayThreeRect = new Rectangle (0, 0, 
				dayThreeForecastControl.Width, dayThreeForecastControl.Height);
			var dayFourRect = new Rectangle (dayFourForecastControl.Width, 0, 
				dayFourForecastControl.Width, dayFourForecastControl.Height);

			tomorrowForecastControl.LayoutTo (tomorrowRect, 300, Easing.CubicInOut);
			dayTwoForecastControl.LayoutTo (dayTwoRect, 300, Easing.CubicInOut);
			dayThreeForecastControl.LayoutTo (dayThreeRect, 300, Easing.CubicInOut);
			dayFourForecastControl.LayoutTo (dayFourRect, 300, Easing.CubicInOut);
		}

		private void MoveForecastToDayFour()
		{
			var tomorrowRect = new Rectangle (-tomorrowForecastControl.Width * 3, 0, 
				tomorrowForecastControl.Width, tomorrowForecastControl.Height);
			var dayTwoRect = new Rectangle (-dayTwoForecastControl.Width * 2, 0, 
				dayTwoForecastControl.Width, dayTwoForecastControl.Height);
			var dayThreeRect = new Rectangle (-dayThreeForecastControl.Width, 0, 
				dayThreeForecastControl.Width, dayThreeForecastControl.Height);
			var dayFourRect = new Rectangle (0, 0, 
				dayFourForecastControl.Width, dayFourForecastControl.Height);

			tomorrowForecastControl.LayoutTo (tomorrowRect, 300, Easing.CubicInOut);
			dayTwoForecastControl.LayoutTo (dayTwoRect, 300, Easing.CubicInOut);
			dayThreeForecastControl.LayoutTo (dayThreeRect, 300, Easing.CubicInOut);
			dayFourForecastControl.LayoutTo (dayFourRect, 300, Easing.CubicInOut);
		}

		#endregion

		#region Subscrib/Unsubscribe to Swipe Events

		private void SubscribeBoxViewMain ()
		{
			boxViewMain.SwipedUp += (object sender, EventArgs e) =>
			{
				BoxViewMainSwipedUp (sender, e);
			};
			boxViewMain.SwipedDown += (object sender, EventArgs e) =>
			{
				BoxViewMainSwipedDown (sender, e);
			};
		}

		private void UnSubscribeBoxViewMain ()
		{
			boxViewMain.SwipedUp -= (object sender, EventArgs e) =>
			{
				BoxViewMainSwipedUp (sender, e);
			};
			boxViewMain.SwipedDown -= (object sender, EventArgs e) =>
			{
				BoxViewMainSwipedDown (sender, e);
			};
		}

		private void SubscribeBoxViewCities ()
		{
			boxViewCities.SwipedUp += (object sender, EventArgs e) =>
			{
				BoxViewCitiesSwipedUp (sender, e);
			};
		}

		private void UnSubscribeBoxViewCities ()
		{
			boxViewCities.SwipedUp -= (object sender, EventArgs e) =>
			{
				BoxViewCitiesSwipedUp (sender, e);
			};
		}

		private void SubscribeBoxViewSettings ()
		{
			boxViewSettings.SwipedDown += (object sender, EventArgs e) =>
			{
				BoxViewSettingsSwipedDown (sender, e);
			};
		}

		private void UnSubscribeBoxViewSettings ()
		{
			boxViewSettings.SwipedDown -= (object sender, EventArgs e) =>
			{
				BoxViewSettingsSwipedDown (sender, e);
			};
		}

		private void SubscribeBoxViewForecastLeft()
		{
			boxViewForecast.SwipedLeft += (object sender, EventArgs e) =>
			{
				BoxViewForecastSwipedLeft(sender, e);
			};
		}

		private void SubscribeBoxViewForecastRight()
		{
			boxViewForecast.SwipedRight += (object sender, EventArgs e) => 
			{
				BoxViewForecastSwipedRight(sender, e);
			};
		}

		#endregion
	}
}

