using System;
using Xamarin.Forms;

namespace MyWeather
{
	public class GestureBoxView : BoxView
	{
		public event EventHandler SwipedUp;
		public event EventHandler SwipedDown;
		public event EventHandler SwipedLeft;
		public event EventHandler SwipedRight;

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

		public void RaiseSwipedLeft()
		{
			if (SwipedLeft != null)
			{
				SwipedLeft (this, EventArgs.Empty);
			}
		}

		public void RaiseSwipedRight()
		{
			if (SwipedRight != null)
			{
				SwipedRight (this, EventArgs.Empty);
			}
		}
	}
}

