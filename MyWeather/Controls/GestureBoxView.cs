using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class GestureBoxView : BoxView
	{
		public event EventHandler SwipedUp;
		public event EventHandler SwipedDown;

		public void RaiseSwipedUp()
		{
			if (SwipedUp != null)
			{
				SwipedUp (this, EventArgs.Empty);
			}
		}

		public void RaiseSwipedDown()
		{
			if (SwipedDown != null)
			{
				SwipedDown (this, EventArgs.Empty);
			}
		}
	}
}

