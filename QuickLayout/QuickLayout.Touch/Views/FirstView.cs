using Cirrious.FluentLayouts.Touch;
using Foundation;
using UIKit;
using QuickLayout.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using ObjCRuntime;

namespace QuickLayout.Touch.Views
{
	[Register("FirstView")]
	public class FirstView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			View.BackgroundColor = UIColor.White;
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var buttonF = new UIButton(UIButtonType.RoundedRect);
			buttonF.SetTitle("Form", UIControlState.Normal);
			Add(buttonF);

			var buttonD = new UIButton(UIButtonType.RoundedRect);
			buttonD.SetTitle("Details", UIControlState.Normal);
			Add(buttonD);

			var buttonS = new UIButton(UIButtonType.RoundedRect);
			buttonS.SetTitle("Search", UIControlState.Normal);
			Add(buttonS);

			var buttonT = new UIButton(UIButtonType.RoundedRect);
			buttonT.SetTitle("Tip", UIControlState.Normal);
			Add(buttonT);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(buttonF).To("GoForm");
			set.Bind(buttonD).To("GoDetails");
			set.Bind(buttonS).To("GoSearch");
			set.Bind(buttonT).To("GoTip");
			set.Apply();

			var constraints = View.VerticalStackPanelConstraints(
											new Margins(20, 10, 20, 10, 5, 5),
											View.Subviews);
			View.AddConstraints(constraints);
		}
	}
}