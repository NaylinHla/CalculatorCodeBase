using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [Test]
        public void Add_WithPositiveNumbers_ReturnsSum()
        {
            int result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Add_WithNegativeNumbers_ReturnsSum()
        {
            int result = _calculator.Add(-2, -3);
            Assert.AreEqual(-5, result);
        }

        [Test]
        public void Subtract_WithPositiveNumbers_ReturnsDifference()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Subtract_WithNegativeNumbers_ReturnsDifference()
        {
            int result = _calculator.Subtract(-5, -3);
            Assert.AreEqual(-2, result);
        }

        [Test]
        public void Multiply_WithPositiveNumbers_ReturnsProduct()
        {
            int result = _calculator.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Multiply_WithZero_ReturnsZero()
        {
            int result = _calculator.Multiply(4, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Divide_WithNonZeroDivisor_ReturnsQuotient()
        {
            int result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Test]
        public void Factorial_OfZero_ReturnsOne()
        {
            int result = _calculator.Factorial(0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Factorial_OfPositiveNumber_ReturnsFactorial()
        {
            int result = _calculator.Factorial(5);
            Assert.AreEqual(120, result);
        }

        [Test]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Factorial(-1));
        }

        [Test]
        public void IsPrime_WithPrimeNumber_ReturnsTrue()
        {
            bool result = _calculator.IsPrime(7);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPrime_WithNonPrimeNumber_ReturnsFalse()
        {
            bool result = _calculator.IsPrime(8);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrime_WithOne_ReturnsFalse()
        {
            bool result = _calculator.IsPrime(1);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPrime_WithNegativeNumber_ReturnsFalse()
        {
            bool result = _calculator.IsPrime(-7);
            Assert.IsFalse(result);
        }
    }
}