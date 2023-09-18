using PamPam;

namespace InfToPostTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            string expression = "5+5";
            string expected = InfToPost.InfixToPostfix(expression);

            string actual = "5 5 +";
            Assert.AreEqual(expected, actual);
        }
    }
}