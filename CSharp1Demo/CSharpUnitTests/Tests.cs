namespace CSharpUnitTests
{
    public class Tests
    {
        [Theory]
        [InlineData(true, 1, 1000, 500)]
        [InlineData(true, 1, 1000, 1)]
        [InlineData(true, 1, 1000, 1000)]
        [InlineData(false, 1, 1000, 0)]
        [InlineData(false, 1, 1000, -1)]
        [InlineData(false, 1, 1000, 1001)]
        [InlineData(false, 1, 1000, int.MinValue)]
        [InlineData(false, 1, 1000, int.MaxValue)]
        [InlineData(true, int.MinValue, int.MaxValue, int.MinValue)]
        [InlineData(true, int.MinValue, int.MaxValue, -1)]
        [InlineData(true, int.MinValue, int.MaxValue, 0)]
        [InlineData(true, int.MinValue, int.MaxValue, 1)]
        [InlineData(true, int.MinValue, int.MaxValue, int.MaxValue)]
        public static void Test_ValidateRangedInput(bool expectedResult, int min, int max, int value)
        {
            // Arrange
            // N/A

            // Act
            bool actualResult = Program.ValidateRangedInput(min, max, value);   

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }


    }
}