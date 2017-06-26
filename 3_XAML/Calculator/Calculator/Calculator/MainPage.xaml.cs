using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private int _currentState = 1;
        private string _mathOperator;
        private double _firstNumber;
        private double _secondNumber;
        
        public MainPage()
        {
            InitializeComponent();    
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || _currentState < 0)
            {
                this.resultText.Text = "";
                if (_currentState < 0)
                    _currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (_currentState == 1)
                {
                    _firstNumber = number;
                }
                else
                {
                    _secondNumber = number;
                }
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            _currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            _mathOperator = pressed;
        }

        private void OnClear(object sender, EventArgs e)
        {
            _firstNumber = 0;
            _secondNumber = 0;
            _currentState = 1;
            this.resultText.Text = "0";
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (_currentState == 2)
            {
                double result = 0;
                switch (_mathOperator)
                {
                    case "/":
                        result = _firstNumber / _secondNumber;
                        break;
                    case "X":
                        result = _firstNumber * _secondNumber;
                        break;
                    case "+":
                        result = _firstNumber + _secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - _secondNumber;
                        break;
                    default:
                        break;
                }

                _firstNumber = result;
                this.resultText.Text = result.ToString("N0");
                _currentState = -1;
            }
        }
    }

}