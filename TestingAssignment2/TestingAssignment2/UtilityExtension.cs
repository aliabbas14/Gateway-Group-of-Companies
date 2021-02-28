using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestingAssignment2
{
    public static class UtilityExtension
    {
        public static string ToLowerCase(this string data)
        {
            if (data.Length > 0)
            {
                return data.ToLower();
            }
            return data;
        }

        public static string ToUpperCase(this string data)
        {
            if (data.Length > 0)
            {
                return data.ToUpper();
            }
            return data;
        }

        public static string ToTitleCase(this string data)
        {
            if (data.Length > 0)
            {
                TextInfo text = new CultureInfo("en-US", false).TextInfo;
                data = text.ToTitleCase(data);
                return new string(data);
            }
            return data;
        }

        public static bool HasAllLower(this string data)
        {
            string mydata = data;
            char[] char_array;
            char ch;
            int length = mydata.Length;
            int i;
            int totalCntLower = 0;

            char_array = mydata.ToCharArray(0, length);
            for (i = 0; i < length; i++)
            {
                ch = char_array[i];
                if (char.IsLower(ch))
                {
                    totalCntLower++;
                }
            }
            if (totalCntLower == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static string FirstLetterToUpper(this string data)
        {
            if (data.Length > 0)
            {
                char[] char_array = data.ToCharArray();
                char_array[0] = char.IsUpper(char_array[0]) ? char.ToLower(char_array[0]) : char.ToUpper(char_array[0]);
                return new string(char_array);
            }
            return data;
        }

        public static bool HasAllUpper(this string data)
        {
            string mydata = data;
            char[] char_array;
            char ch;
            int length = mydata.Length;
            int count;
            int totalcntupper = 0;

            char_array = mydata.ToCharArray(0, length);
            for (count = 0; count < length; count++)
            {
                ch = char_array[count];
                if (char.IsUpper(ch))
                {
                    totalcntupper++;
                }
            }
            if (totalcntupper == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidNumeric(this string data)
        {
            int number = 0;
            return int.TryParse(data, out number);
        }

        public static string RemoveLastCharacter(this string data)
        {
            return data.Remove(data.Length - 1, 1);
        }

        public static int WordCount(this string data)
        {
            int i = 0, Count = 1;
            while (i <= data.Length - 1)
            {
                if (data[i] == ' ' || data[i] == '\n' || data[i] == '\t')
                {
                    Count++;
                }
                i++;
            }
            return Count;
        }

        public static int? StringToInteger(this string data)
        {
            if (data.ValidNumeric())
            {
                return int.Parse(data);
            }
            else
                return null;
        }

    }
}
