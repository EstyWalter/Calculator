
using CalculatorSystem;
namespace Calculator;

public partial class Calculator : ContentPage
{
    CalculatorSystem.Calculator activec = new();
    List<CalculatorSystem.Calculator> lstcalculators = new() { new(), new(), new()};
	public Calculator()
	{
        InitializeComponent();
        lstcalculators[0] = activec;
        Solution1Rb.BindingContext = lstcalculators[0];
        Solution2Rb.BindingContext = lstcalculators[1];
        Solution3Rb.BindingContext = lstcalculators[2];
        this.BindingContext = activec;
        CalculatorSystem.Calculator.NumOfequasionsTextChanged += Activec_NumOfequasionsTextChanged;
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        activec.ActiveBox = btn.Text;
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        activec.Clear();
    }

    private void EqualsBtn_Clicked(object sender, EventArgs e)
    {
        activec.CalculateSolution();
    }

    private void SighnBtn_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        activec.InputSighn(btn.Text);
    }

    private void Solution_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.IsChecked && rb.BindingContext is CalculatorSystem.Calculator selectedcalculator)
        {
            activec = selectedcalculator;
            this.BindingContext = activec;
        }
    }

    private void OperatorBtn_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        activec.ChangeOperator(btn.Text);
    }
    private void Activec_NumOfequasionsTextChanged(object? sender, EventArgs e)
    {numofsolutionLbl.Text = $"Solutions: {CalculatorSystem.Calculator.numofequasions}";
    }

}