namespace FileParserTest
{
    [TestClass]
    public class TestParser
    {
        private string? _testFilePath;

        [TestInitialize]
        public void TestInitialize()
        {
            _testFilePath = Path.Combine(Path.GetTempPath(), "testfile.txt");
            File.WriteAllText(_testFilePath, "Line 1\nLine 2\nLine 3");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(_testFilePath!);
        }

        [TestMethod]
        public void ParseExistingFile()
        {
            var fileParser = new FileParser(_testFilePath!);

            List<string> lines = fileParser.Parse();

            CollectionAssert.AreEqual(new List<string> { "Line 1", "Line 2", "Line 3" }, lines);
        }

        [TestMethod]
        public void ParseNonExistingFile()
        {
            var fileParser = new FileParser("NonExistentFile.txt");

            List<string> lines = fileParser.Parse();

            CollectionAssert.AreEqual(new List<string>(), lines);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNullFilePath()
        {
            var fileParser = new FileParser(null!);
        }
    }
}