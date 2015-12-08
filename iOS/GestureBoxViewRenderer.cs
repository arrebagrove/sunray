using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using MyWeather;
using MyWeather.iOS;

[assembly: ExportRenderer (typeof(GestureBoxView), typeof(GestureBoxViewRenderer))]

namespace MyWeather.iOS
{
	public class GestureBoxViewRenderer : BoxRenderer
	{
		UISwipeGestureRecognizer swipeUpGestureRecognizer;
		UISwipeGestureRecognizer swipeDownGestureRecognizer;
		UISwipeGestureRecognizer swipeLeftGestureRecognizer;
		UISwipeGestureRecognizer swipeRightGestureRecognizer;
		GestureBoxView gestureBoxView;

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.BoxView> e)
		{
			base.OnElementChanged (e);

			gestureBoxView = (GestureBoxView)e.NewElement;

			swipeUpGestureRecognizer = new UISwipeGestureRecognizer ( () => gestureBoxView.RaiseSwipedUp ()) {
				Direction = UISwipeGestureRecognizerDirection.Up
			};
			swipeDownGestureRecognizer = new UISwipeGestureRecognizer ( () => gestureBoxView.RaiseSwipedDown ()) {
				Direction = UISwipeGestureRecognizerDirection.Down
			};
			swipeLeftGestureRecognizer = new UISwipeGestureRecognizer ( () => gestureBoxView.RaiseSwipedLeft ()) {
				Direction = UISwipeGestureRecognizerDirection.Left
			};
			swipeRightGestureRecognizer = new UISwipeGestureRecognizer ( () => gestureBoxView.RaiseSwipedRight ()) {
				Direction = UISwipeGestureRecognizerDirection.Right
			};

			if (e.NewElement == null) {
				if (swipeUpGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeUpGestureRecognizer);
				}
				if (swipeDownGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeDownGestureRecognizer);
				}
				if (swipeLeftGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeLeftGestureRecognizer);
				}
				if (swipeRightGestureRecognizer != null) {
					this.RemoveGestureRecognizer (swipeRightGestureRecognizer);
				}
			}

			if (e.OldElement == null) {
				this.AddGestureRecognizer (swipeUpGestureRecognizer);
				this.AddGestureRecognizer (swipeDownGestureRecognizer);
				this.AddGestureRecognizer (swipeLeftGestureRecognizer);
				this.AddGestureRecognizer (swipeRightGestureRecognizer);
			}
		}
	}
}

