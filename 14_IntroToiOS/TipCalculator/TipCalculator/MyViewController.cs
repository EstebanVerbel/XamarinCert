using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TipCalculator
{
    public class MyViewController : UIViewController
    {
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Yellow;

            UITextField totalAmount = new UITextField()
            {
                Frame = new CoreGraphics.CGRect(20, 28, View.Bounds.Width - 40, 35),
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Enter Total Amount"
            };

            UIButton calculateButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CoreGraphics.CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0)
            };
            calculateButton.SetTitle("Calculate", UIControlState.Normal);

            UILabel resultLabel = new UILabel()
            {
                Frame = new CoreGraphics.CGRect(20, 124, View.Bounds.Width - 40, 40),
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24), // the number 24 increases the font size
                Text = "Tip $0.00"
            };

            View.AddSubviews(totalAmount, calculateButton, resultLabel);

            // add click event handlers
            calculateButton.TouchUpInside += (s, e) =>
            {
                string totalValue = totalAmount.Text;

                double total = 0;

                Double.TryParse(totalValue, out total);

                resultLabel.Text = String.Format("Tip is {0:C}", total * 0.2);

                // this makes the keyboard be dismissed 
                totalAmount.ResignFirstResponder();
            };



        }

        
    }
}