using System.ComponentModel;
using static CalculatorSystem.Operator;

namespace CalculatorSystem
{

    public class Calculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public static event EventHandler? NumOfequasionsTextChanged;
        string _activebox = "";
        decimal _answer = 0;

        public Factor factor1 { get; set; } = new();
        public Factor factor2 { get; set; } = new();
        public Operator o { get; set; } = new();

        public static int numofequasions { get;  private set ; }

        public decimal Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Answer)));
            }
        }
        public string ActiveBox
        {
            get => _activebox;
            set
            {
                _activebox = value;
                DetermineActiveBox();
            }
        }

        public decimal CalculateSolution()
        {
            numofequasions++;
            if (!decimal.TryParse(factor1.Factorvalue, out decimal firstNumber) ||
                !decimal.TryParse(factor2.Factorvalue, out decimal secondNumber))
            {
                return Answer;
            }

            switch (o.OperatorValue)
            {
                case OperatorValueEnum.Subtract:
                    Answer = firstNumber - secondNumber;
                    break;
                case OperatorValueEnum.Add:
                    Answer = firstNumber + secondNumber;
                    break;
                case OperatorValueEnum.Multiply:
                    Answer = firstNumber * secondNumber;
                    break;
                case OperatorValueEnum.Divide:
                    Answer = firstNumber / secondNumber;
                    break;
            }
            NumOfequasionsTextChanged?.Invoke(this, new EventArgs());
            return Answer;
        }

        public void ChangeOperator(string value)
        {
            if (factor1.Active == true)
            {
                o.OperatorText = value;
            }
        }

        public void DetermineActiveBox(string activebox = "")
        {
            if (o.OperatorValue == OperatorValueEnum.None)
            {
                factor1.Factorvalue = string.Concat(activebox, factor1.Factorvalue, ActiveBox);
            }
            else
            {
                factor2.Factorvalue = string.Concat(activebox, factor2.Factorvalue, ActiveBox);
            }
        }

        public void Clear()
        {
            o.OperatorValue = OperatorValueEnum.None;
            factor1.Active = false;
            factor2.Active = false;
            Answer = 0;
        }

        public void InputSighn(string symbol)
        {
            bool second = factor2.Active;
            string value = second ? factor2.Factorvalue : factor1.Factorvalue;

            if (symbol == "." && value.Contains("."))
                return;

            value = symbol == "."
                ? value + "."
                : value.StartsWith("-") ? value.Substring(1) : "-" + value;

            if (second)
                factor2.Factorvalue = value;
            else
                factor1.Factorvalue = value;
        }


    }
}


