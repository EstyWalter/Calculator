using CalculatorSystem;
namespace CalculatorTest
{
    public class Tests
    {

        [TestCase(Operator.OperatorValueEnum.Add, 10)]
        [TestCase(Operator.OperatorValueEnum.Subtract, 6)]
        [TestCase(Operator.OperatorValueEnum.Divide, 4)]
        [TestCase(Operator.OperatorValueEnum.Multiply, 16)]
        public void CalculateSolution(Operator.OperatorValueEnum operation, int expectedAnswer)
        {
            Calculator c = new();
            c.factor1.Factorvalue = "8";
            c.factor2.Factorvalue = "2";
            c.o.OperatorValue = operation;
            var actualAnswer = c.CalculateSolution();
            string msg = $"{operation} with 8 and 2: expected {expectedAnswer}, got {actualAnswer}";
            TestContext.WriteLine(msg);
            Assert.That(actualAnswer, Is.EqualTo(expectedAnswer), msg);
        }

        [TestCase("1", ".", "1.")]
        [TestCase("1", "-", "-1")]
        [TestCase("-1", "-", "1")]
        [TestCase("1.5", ".", "1.5")]
        public void InputSighn(string startingValue, string symbol, string expectedValue)
        {
            Calculator c = new();
            c.factor1.Factorvalue = startingValue;
            c.InputSighn(symbol);
            string actualValue = c.factor1.Factorvalue;
            TestContext.WriteLine(
                $"Starting with '{startingValue}', pressed '{symbol}'. " +
                $"Expected '{expectedValue}', got '{actualValue}'.");
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TheCorrectFactor()
        {
            Calculator c = new();
            c.o.OperatorValue = Operator.OperatorValueEnum.None;

            c.ActiveBox = "1";
            c.ActiveBox = "2";

            Assert.That(c.factor1.Factorvalue, Is.EqualTo("12"));
            Assert.That(c.factor2.Factorvalue, Is.Empty);

            c.o.OperatorValue = Operator.OperatorValueEnum.Add;

            c.ActiveBox = "3";
            c.ActiveBox = "4";

            TestContext.WriteLine(
                $"Factor 1 = '{c.factor1.Factorvalue}', Factor 2 = '{c.factor2.Factorvalue}'");

            Assert.That(c.factor1.Factorvalue, Is.EqualTo("12"));
            Assert.That(c.factor2.Factorvalue, Is.EqualTo("34"));
        }
    }
}
