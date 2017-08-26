using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText _inputBill;
        private Button _calculateButton;
        private TextView _outputTip;
        private TextView _outputTotal;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // find views on UI by id
            _inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            _calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            _outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            _outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            // subscribe handdler to click event
            _calculateButton.Click += calculateButton_Click;


        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            float inputBill = float.Parse(_inputBill.Text);

            float tip = inputBill * 0.15f;
            float total = inputBill + tip;

            _outputTip.Text = tip.ToString();
            _outputTotal.Text = total.ToString();
        }
    }
}

