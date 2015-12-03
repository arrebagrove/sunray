using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace MyWeather
{
	public partial class MainPage : ContentPage
	{
		private MainViewModel viewModel;

		public MainPage ()
		{
			InitializeComponent ();

			viewModel = new MainViewModel ();
			this.BindingContext = viewModel;

			// Check temp label size
			// Setup Forecast list

			SubscribeBoxViewMain ();

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			PrintBounds ();
		}

		private void PrintBounds() {
			Debug.WriteLine ("Cities Grid" + gridCities.Bounds);
			Debug.WriteLine ("Main Grid" + gridMainContent.Bounds);
			Debug.WriteLine ("Settings Grid" + gridSettings.Bounds);
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
			var pageHeight = boxViewMain.Height;

			gridSettings.TranslateTo (0, 0, 400, Easing.SinIn);
			gridMainContent.TranslateTo (0, pageHeight, 400, Easing.SinOut);

			SubscribeBoxViewCities ();
			PrintBounds ();
		}

		private void MoveDownToMain()
		{
			var pageHeight = boxViewMain.Height;

			gridSettings.TranslateTo (0, -pageHeight, 400, Easing.SinIn);
			gridMainContent.TranslateTo (0, 0, 400, Easing.SinOut);

			PrintBounds ();
			SubscribeBoxViewMain ();
		}

		private void MoveUpToMain()
		{
			var pageHeight = boxViewMain.Height;

			gridSettings.TranslateTo (0, pageHeight, 400, Easing.SinIn);
			gridMainContent.TranslateTo (0, 0, 400, Easing.SinOut);

			PrintBounds ();
			SubscribeBoxViewMain ();
		}

		private void MoveToSettings()
		{
			var pageHeight = boxViewMain.Height;

			gridSettings.TranslateTo (0, -pageHeight, 400, Easing.SinIn);
			gridMainContent.TranslateTo (0, -pageHeight, 400, Easing.SinOut);

			PrintBounds ();
			SubscribeBoxViewSettings ();
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

		#endregion
	}
}

