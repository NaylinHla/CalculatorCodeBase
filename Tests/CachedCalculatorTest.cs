using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [TestFixture]
    public class CachedCalculatorTests
    {
        private CachedCalculator _cachedCalculator;

        [SetUp]
        public void Setup()
        {
            _cachedCalculator = new CachedCalculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum_AndCachesResult()
        {
            int a = 2, b = 3;
            int result1 = _cachedCalculator.Add(a, b);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            int result2 = _cachedCalculator.Add(a, b);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.AreEqual(5, result1);
            Assert.AreEqual(5, result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            // There should be exactly one cached entry for this operation
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void Subtract_ReturnsCorrectDifference_AndCachesResult()
        {
            int a = 10, b = 4;
            int result1 = _cachedCalculator.Subtract(a, b);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            int result2 = _cachedCalculator.Subtract(a, b);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.AreEqual(6, result1);
            Assert.AreEqual(6, result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void Multiply_ReturnsCorrectProduct_AndCachesResult()
        {
            int a = 3, b = 4;
            int result1 = _cachedCalculator.Multiply(a, b);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            int result2 = _cachedCalculator.Multiply(a, b);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.AreEqual(12, result1);
            Assert.AreEqual(12, result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void Divide_ReturnsCorrectQuotient_AndCachesResult()
        {
            int a = 20, b = 5;
            int result1 = _cachedCalculator.Divide(a, b);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            int result2 = _cachedCalculator.Divide(a, b);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.AreEqual(4, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void Divide_ByZero_ThrowsException_AndDoesNotCache()
        {
            int a = 10, b = 0;
            int initialCacheCount = _cachedCalculator._cache.Count;
            Assert.Throws<DivideByZeroException>(() => _cachedCalculator.Divide(a, b));
            // Ensure the cache count remains unchanged after the exception
            Assert.AreEqual(initialCacheCount, _cachedCalculator._cache.Count);
        }

        [Test]
        public void Factorial_ReturnsCorrectFactorial_AndCachesResult()
        {
            int n = 5;
            int result1 = _cachedCalculator.Factorial(n);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            int result2 = _cachedCalculator.Factorial(n);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.AreEqual(120, result1);
            Assert.AreEqual(120, result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void Factorial_Negative_ThrowsException_AndDoesNotCache()
        {
            int n = -3;
            int initialCacheCount = _cachedCalculator._cache.Count;
            Assert.Throws<ArgumentException>(() => _cachedCalculator.Factorial(n));
            Assert.AreEqual(initialCacheCount, _cachedCalculator._cache.Count);
        }

        [Test]
        public void IsPrime_ReturnsTrueForPrime_AndCachesResult()
        {
            int candidate = 7;
            bool result1 = _cachedCalculator.IsPrime(candidate);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            bool result2 = _cachedCalculator.IsPrime(candidate);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }

        [Test]
        public void IsPrime_ReturnsFalseForNonPrime_AndCachesResult()
        {
            int candidate = 8;
            bool result1 = _cachedCalculator.IsPrime(candidate);
            int cacheCountAfterFirstCall = _cachedCalculator._cache.Count;
            bool result2 = _cachedCalculator.IsPrime(candidate);
            int cacheCountAfterSecondCall = _cachedCalculator._cache.Count;

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.AreEqual(cacheCountAfterFirstCall, cacheCountAfterSecondCall);
            Assert.AreEqual(1, cacheCountAfterSecondCall);
        }
    }
}