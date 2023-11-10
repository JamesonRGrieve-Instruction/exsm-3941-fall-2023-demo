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
        public static void Test_MinutesToSeconds_Valid(int expectedResult, int minutes)
        {
            // Arrange
            // N/A

            // Act
            int actualResult = TestDrivenDevelopment_Development.MinutesToSeconds(minutes);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void Test_MinutesToSeconds_Invalid()
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
        public static void Test_TimeStampToSeconds_Valid(int expectedResult, string timestamp)
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
        public static void Test_TimestampToSeconds_Invalid(string timestamp)
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


        [Theory]
        [InlineData("DLROWOLLEH", "Hello, World!")]
        [InlineData("SSALCOTEMOCLEW", "Welcome to Class.")]
        [InlineData("NUFSISIHT", "This is fun.")]
        [InlineData("", "!@#$%^&*(){}[]-_=+,.<>/?;:'\"")]
        public static void Test_ModifyString_Valid(string expectedResult, string text)
        {
            // Arrange
            // N/A

            // Act
            string actualResult = TestDrivenDevelopment_Development.ModifyString(text);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("One is 1.")]
        [InlineData("1234")]
        public static void Test_ModifyString_Invalid(string text)
        {
            // Arrange
            // N/A

            // Act
            Action act = () =>
            {
                TestDrivenDevelopment_Development.ModifyString(text);
            };

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal("text", exception.ParamName);
        }

        [Theory]
        [InlineData(189.88d, 15.5d, 12.25d, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData(100d, 10d, 20d, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData(314.16d, 20d, null, TestDrivenDevelopment_Development.Shape.Circle)]
        public static void Test_GetArea_Valid(double expectedResult, double sideOne, double? sideTwo, TestDrivenDevelopment_Development.Shape shape)
        {
            // Arrange
            // N/A

            // Act
            double actualResult = TestDrivenDevelopment_Development.GetArea(shape, sideOne, sideTwo);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("sideOne", -1d, 10d, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData("sideOne", 0d, 10d, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData("sideTwo", 10d, -1d, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData("sideTwo", 10d, 0d, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData("sideTwo", 10d, null, TestDrivenDevelopment_Development.Shape.Rectangle)]
        [InlineData("sideOne", -1d, 10d, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData("sideOne", 0d, 10d, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData("sideTwo", 10d, -1d, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData("sideTwo", 10d, 0d, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData("sideTwo", 10d, null, TestDrivenDevelopment_Development.Shape.Triangle)]
        [InlineData("sideOne", -1d, 10d, TestDrivenDevelopment_Development.Shape.Circle)]
        [InlineData("sideOne", 0d, 10d, TestDrivenDevelopment_Development.Shape.Circle)]
        [InlineData("sideTwo", 10d, -1d, TestDrivenDevelopment_Development.Shape.Circle)]
        [InlineData("sideTwo", 10d, 0d, TestDrivenDevelopment_Development.Shape.Circle)]
        [InlineData("sideTwo", 10d, 1d, TestDrivenDevelopment_Development.Shape.Circle)]
        public static void Test_GetArea_Invalid(string issueParameter, double sideOne, double? sideTwo, TestDrivenDevelopment_Development.Shape shape)
        {
            // Arrange
            // N/A

            // Act
            Action act = () =>
            {
                TestDrivenDevelopment_Development.GetArea(shape, sideOne, sideTwo);
            };

            // Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(issueParameter, exception.ParamName);
        }
    }
}
