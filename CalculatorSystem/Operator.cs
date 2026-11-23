using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculatorSystem
{
    public class Operator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public enum OperatorValueEnum { None, Add, Multiply, Subtract, Divide };
        public  OperatorValueEnum _operatorvalue;
        public string _operatortext = "";

        public OperatorValueEnum OperatorValue
        {
            get => _operatorvalue;
            set
            {

                _operatorvalue = value;
                switch (OperatorValue)
                {
                    case OperatorValueEnum.Subtract:
                        _operatortext = "-";
                        break;
                    case OperatorValueEnum.Add:
                        _operatortext = "+";
                        break;
                    case OperatorValueEnum.Multiply:
                        _operatortext = "*";
                        break;
                    case OperatorValueEnum.Divide:
                        _operatortext = "/";
                        break;
                    case OperatorValueEnum.None:
                        _operatortext = "";
                        break;
                }
                InvokePropertyChanged();
                InvokePropertyChanged("OperatorText");
            }
        }
        public string OperatorText
        {
            get => _operatortext;
            set
            {
                OperatorValue = value switch
                {
                    "-" => OperatorValueEnum.Subtract,
                    "+" => OperatorValueEnum.Add,
                    "*" => OperatorValueEnum.Multiply,
                    "/" => OperatorValueEnum.Divide,
                    "" => OperatorValueEnum.None
                };
            }
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
