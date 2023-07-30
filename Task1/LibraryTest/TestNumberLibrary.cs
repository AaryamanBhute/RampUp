using Library;

namespace LibraryTest
{
    [TestClass]
    public class TestNumberLibrary
    {
        [TestMethod]
        public void TestIsEvenTrue()
        {
            Assert.IsTrue(NumberLibrary.isEven(2));
        }

        [TestMethod] 
        public void TestIsEvenFalse() {
            Assert.IsFalse(NumberLibrary.isEven(11));
        }

        [TestMethod]
        public void TestSquarePositive()
        {
            Assert.AreEqual(25, NumberLibrary.square(5));
        }

        [TestMethod]
        public void TestSquareNegative()
        {
            Assert.AreEqual(36, NumberLibrary.square(-6));
        }

        [TestMethod]
        public void TestStringifyMaxVal()
        {
            Assert.AreEqual("2147483647", NumberLibrary.stringify(int.MaxValue));
        }

        [TestMethod]
        public void TestStringifyMinVal()
        {
            Assert.AreEqual("-2147483648", NumberLibrary.stringify(int.MinValue));
        }

        [TestMethod]
        public void TestStringifyNegative()
        {
            Assert.AreEqual("-15236", NumberLibrary.stringify(-15236));
        }

        [TestMethod]
        public void TestStringifyPositive()
        {
            Assert.AreEqual("15236", NumberLibrary.stringify(15236));
        }

        [TestMethod]
        public void TestRandomSampleInvalidInput()
        {
            Assert.ThrowsException<InvalidOperationException>(() => NumberLibrary.randomSample(2, -3, 3));
        }

        [TestMethod]
        public void TestRandomSampleValid()
        {
            int lower = -3, upper = 7, len = 5;
            int[] vals = NumberLibrary.randomSample(lower, upper, len);

            Assert.AreEqual(len, vals.Length);

            foreach(int val in vals)
            {
                Assert.IsTrue(val >= lower && val < upper);
            }
        }

        [TestMethod]
        public void TestAllUniqueFalse()
        {
            int[] test = { 1, 3, 4, 3 };
            Assert.IsFalse(NumberLibrary.allUnique(test));
        }

        [TestMethod]
        public void TestAllUniqueTrue()
        {
            int[] test = { 1, 3, 4, -2 };
            Assert.IsTrue(NumberLibrary.allUnique(test));
        }
    }
}