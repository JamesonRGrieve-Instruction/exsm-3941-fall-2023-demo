namespace CSharpUnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(16, 2, 4)]
        [InlineData(32, 2, 5)]
        [InlineData(0, 0, 10)]
        [InlineData(1, 10, 0)]
        [InlineData(1, 1, 10)]
        [InlineData(10, 10, 1)]
        [InlineData(1, -1, 10)]
        [InlineData(0.1, 10, -1)]
        // This is a little weird, but it's apparently expected behaviour for C#.
        [InlineData(int.MinValue,2,1000)]
        
        public void Test_MathPow(int expectedResult, int baseNum, int exponentNum)
        {
            // Setup (If Applicable) | "Arrange"
            // N/A

            // Execution | "Act"
            int actualResult = (int)Math.Pow(baseNum, exponentNum);

            // Assertion | "Assert"
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Test_IntParse() {
            // Setup (If Applicable) | "Arrange"
            string input = "Hello, World!";

            // Assertion | "Assert"
            Assert.Throws<FormatException>(() => {
                // Execution | "Act"
                int actualResult = int.Parse(input);
            });
            
        }
    }
}