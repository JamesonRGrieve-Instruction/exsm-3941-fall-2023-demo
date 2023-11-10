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
            if (timestamp.Split(':').Length != 2)
            {
                throw new ArgumentException("Too many segments.", nameof(timestamp));
            }
            try
            {
                int hours = int.Parse(timestamp.Split(":")[0]);
                int minutes = int.Parse(timestamp.Split(":")[1]);
                if (hours < 0 || minutes < 0) 
                {
                    throw new ArgumentException("Must be positive.", nameof(timestamp));
                }
                return (hours * 60 + minutes)*60;
            }
            catch(Exception)
            {
                throw new ArgumentException("Invalid segment(s).", nameof(timestamp));
            }


        }
        public static string ModifyString(string text)
        {
            string result = "";
            for (int i = text.Length-1; i >= 0; i--)
            {
                if (char.IsDigit(text[i]))
                {
                    throw new ArgumentException("Cannot contain digits.", nameof(text));
                }
                if (char.IsLetter(text[i]))
                {
                    result += text[i].ToString().ToUpper();
                }
            }
            return result;

            // This also works, assuming you've sanitized it of symbols already.
            /*
            char[] output = text.ToCharArray();
            Array.Reverse(output);
            return output.ToString().ToUpper();
            */
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
