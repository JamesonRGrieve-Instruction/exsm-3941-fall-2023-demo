using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUnitTests
{
    public class TestDrivenDevelopment_Tests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(60, 1)]
        [InlineData(600, 10)]
        public static void TestValid_MinutesToSeconds(int expectedResult, int minutes)
        {
            // Arrange
            // N/A

            // Act
            int actualResult = TestDrivenDevelopment_Development.MinutesToSeconds(minutes);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void TestInvalid_MinutesToSeconds()
        {
            // Arrange
            // N/A

            // Act
            // Action allows us to store an anonymous function (with no return) in a variable.
            // This allows us to maintain the Arrange-Act-Assert format of our tests, while still using Assert.Throws.
            Action act = () =>
            {
                TestDrivenDevelopment_Development.MinutesToSeconds(-1);
            };

            // Assert
            // We have two assertions in this case because we want to be more specific (either for ourselves or someone else developing the software.
            // One is saying that the function should throw the argument exception at all.
            // The other is saying that the parameter name of that exception is correct.
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Equal("minutes", exception.ParamName);
        }

        [Theory]
        [InlineData(0, "0:00")]
        [InlineData(60, "0:01")]
        [InlineData(300, "0:05")]
        [InlineData(3600, "1:00")]
        public static void TestValid_TimeStampToSeconds(int expectedResult, string timestamp)
        {
            // Arrange
            // N/A

            // Act
            int actualResult = TestDrivenDevelopment_Development.TimestampToSeconds(timestamp);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("01")]
        [InlineData("10;10")]
        [InlineData("One hour.")]
        [InlineData("-1:00")]
        [InlineData("0:-01")]
        [InlineData("1:1:1")]
        //[InlineData("0:1")]
        public static void TestInvalid_TimestampToSeconds(string timestamp)
        {
            // Arrange
            // N/A

            // Act
            Action act = () =>
            {
                TestDrivenDevelopment_Development.TimestampToSeconds(timestamp);
            };

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("timestamp", exception.ParamName);
        }

    }
}
