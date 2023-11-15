namespace CSharpUnitTests
{
    public class DataStructures_Tests
    {
        [Theory]
        [InlineData(8, 5)]
        public void Test_Add3ToInteger(decimal expectedResult, decimal initialValue)
        {
            // Setup (If Applicable) | "Arrange"
            // N/A

            // Execution | "Act"
            Program.Add3ToInteger(ref initialValue);

            // Assertion | "Assert"
            Assert.Equal(expectedResult, initialValue);

        }
    }
}