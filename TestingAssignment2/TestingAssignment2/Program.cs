using System;

namespace TestingAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string uppercase = "ABC";
            Console.WriteLine(uppercase.ToLowerCase());

            string lowercase = "abc";
            Console.WriteLine(lowercase.ToUpperCase());

            string titlecase = "abc";
            Console.WriteLine(titlecase.ToTitleCase());

            string alllower = "abc";
            Console.WriteLine(alllower.HasAllLower());

            string firstletter = "abc";
            Console.WriteLine(firstletter.FirstLetterToUpper());

            string allupper = "ABC";
            Console.WriteLine(allupper.HasAllUpper());

            string validNumeric = "55";
            Console.WriteLine(validNumeric.ValidNumeric());

            string lastChar = "abc";
            Console.WriteLine(lastChar.RemoveLastCharacter());

            string wordCount = "abc";
            Console.WriteLine(wordCount.WordCount());

            string strtoint = "5589";
            Console.WriteLine(strtoint.StringToInteger());
        }
    }
}
