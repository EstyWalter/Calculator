using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculatorSystem
{
    public class Factor : INotifyPropertyChanged
    {
        string _factorvalue = "";
        bool _active = false;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Factorvalue
        {
            get => _factorvalue;
            set
            {
                _factorvalue = value;
                _active = Factorvalue == "" ? false : true;
                InvokePropertyChanged();
                InvokePropertyChanged("Active");
            }
        }

        public bool Active
        {
            get => _active;
            set
            {
                if (!value)
                {
                    Factorvalue = "";
                }
                InvokePropertyChanged();
                InvokePropertyChanged("FactorValue");
            }
        }
        private void InvokePropertyChanged([CallerMemberName] string propertyName = "")
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
