using System;
using System.ComponentModel;

namespace MyWeather
{
	public class MainViewModel : INotifyPropertyChanged
	{
		#region Properties

		#endregion

		public MainViewModel ()
		{
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}

