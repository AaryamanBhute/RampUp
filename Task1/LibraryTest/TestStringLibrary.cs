using Library;

namespace LibraryTest
{
    [TestClass]
    public class TestStringLibrary
    {
        [TestMethod]
        public void TestIsNumericFalse()
        {
            Assert.IsFalse(StringLibrary.isNumeric("12312 3"));
        }

        [TestMethod]
        public void TestIsNumericTrue()
        {
            Assert.IsTrue(StringLibrary.isNumeric("123123"));
        }

        [TestMethod]
        public void TestStartsWithFalse()
        {
            Assert.IsFalse(StringLibrary.startsWith("apple", "avacado"));
        }

        [TestMethod]
        public void TestStartsWithTrue()
        {
            Assert.IsTrue(StringLibrary.startsWith("apple", "app"));
        }

        [TestMethod]
        public void TestSplitInvalidInput()
        {
            Assert.ThrowsException<InvalidOperationException>(() => StringLibrary.split("apple", ""));
        }

        [TestMethod]
        public void TestSplitValidInput()
        {
            CollectionAssert.AreEqual(new string[] { "a", "b", "c" }, StringLibrary.split("a,b,c", ","));
        }

        [TestMethod]
        public void TestCapitalizeToUpper()
        {
            Assert.AreEqual("Hello There, How Are You", StringLibrary.capitalize("hello there, how are you"));
        }

        [TestMethod]
        public void TestCapitalizeToLower()
        {
            Assert.AreEqual("Hello There, How Are You", StringLibrary.capitalize("HELLO THERE, HOW ARE YOU"));
        }

        [TestMethod]
        public void TestToIntInvalid()
        {
            Assert.ThrowsException<InvalidOperationException>(() => StringLibrary.toInt("123 3"));
        }

        [TestMethod]
        public void TestToIntValid()
        {
            Assert.AreEqual(132367733, StringLibrary.toInt("132367733"));
        }
    }
}
