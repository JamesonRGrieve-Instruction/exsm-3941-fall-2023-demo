using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp
{
    public class TestDrivenDevelopment_Development
    {
        public static int MinutesToSeconds(int minutes)
        {
            if (minutes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes));
            }
            return minutes * 60;
        }
        public static int TimestampToSeconds(string timestamp)
        {
            throw new NotImplementedException();
        }
        public static string ModifyString(string text)
        {
            throw new NotImplementedException();
        }
        public enum Shape
        {
            Rectangle,
            Triangle,
            Circle
        }
        public static double GetArea(Shape shape, double sideOne, double? sideTwo)
        {
            throw new NotImplementedException();
        }
    }
}
