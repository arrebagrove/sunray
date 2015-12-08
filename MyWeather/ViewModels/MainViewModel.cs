using System;
using System.ComponentModel;
using MyWeather.API;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace MyWeather
{
	public class MainViewModel : INotifyPropertyChanged
	{
		#region Fields



		#endregion


		#region Properties

		private Channel channel;
		public Channel Channel
		{
			get { return channel; }
			set {
				channel = value;
				OnPropertyChanged ();
			}
		}

		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set {
				isBusy = value;
				OnPropertyChanged ();
			}
		}

		#endregion

		public MainViewModel ()
		{
			GetFakeWeather ();
		}

		private async void GetFakeWeather()
		{
			var channel = new Channel ();

			var location = new Location ();
			location.City = "Boston";
			location.Region = "MA";
			channel.Location = location;

			var units = new Units ();
			units.Temperature = "F";
			units.Speed = "mph";
			channel.Units = units;

			var wind = new Wind ();
			wind.Direction = "40";
			wind.Speed = "23";
			channel.Wind = wind;

			var atmo = new Atmosphere ();
			atmo.Humidity = "80";
			channel.Atmosphere = atmo;

			var item = new Item ();
			var condition = new Condition ();
			condition.Code = "26";
			condition.Date = "Sat, 05 Dec 2015 12:54 am AKST";
			condition.Temp = "5";
			condition.Text = "Cloudy";
			item.Condition = condition;
			var forecastList = new List<Forecast> ();
			var dayOne = new Forecast ();
			dayOne.Code = "30";
			dayOne.Date = "5 Dec 2015";
			dayOne.Day = "Sat";
			dayOne.High = "5";
			dayOne.Low = "-3";
			dayOne.Text = "Partly Cloudy";
			forecastList.Add (dayOne);
			var dayTwo = new Forecast ();
			dayTwo.Code = "28";
			dayTwo.Date = "6 Dec 2015";
			dayTwo.Day = "Sun";
			dayTwo.High = "9";
			dayTwo.Low = "3";
			dayTwo.Text = "Mostly Cloudy";
			forecastList.Add (dayTwo);
			var dayThree = new Forecast ();
			dayThree.Code = "30";
			dayThree.Date = "7 Dec 2015";
			dayThree.Day = "Mon";
			dayThree.High = "11";
			dayThree.Low = "7";
			dayThree.Text = "Partly Cloudy";
			forecastList.Add (dayThree);
			var dayFour = new Forecast ();
			dayFour.Code = "28";
			dayFour.Date = "8 Dec 2015";
			dayFour.Day = "Tue";
			dayFour.High = "11";
			dayFour.Low = "4";
			dayFour.Text = "Mostly Cloudy";
			forecastList.Add (dayFour);
			var dayFive = new Forecast ();
			dayFive.Code = "34";
			dayFive.Date = "9 Dec 2015";
			dayFive.Day = "Wed";
			dayFive.High = "10";
			dayFive.Low = "3";
			dayFive.Text = "Mostly Cloudy";
			forecastList.Add (dayFive);
			item.Forecast = forecastList;
			channel.Item = item;

			Channel = channel;
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged ([CallerMemberName]string name = "")
		{
			if (PropertyChanged == null)
			{
				return;
			}

			PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
	}
}

