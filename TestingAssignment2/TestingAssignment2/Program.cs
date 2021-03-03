using System;

namespace TestingAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Implementing ToLowerCase method.
             */
            string uppercase = "ABC";
            Console.WriteLine(uppercase.ToLowerCase());

            /*
                Implementing ToUpperCase method.
             */
            string lowercase = "abc";
            Console.WriteLine(lowercase.ToUpperCase());

            /*
                Implementing ToTitleCase method.
             */
            string titlecase = "abc";
            Console.WriteLine(titlecase.ToTitleCase());

            /*
                Implementing HasAllLower method.
             */
            string alllower = "abc";
            Console.WriteLine(alllower.HasAllLower());

            /*
                Implementing FirstLetterToUpper method.
             */
            string firstletter = "abc";
            Console.WriteLine(firstletter.FirstLetterToUpper());

            /*
                Implementing HasAllUpper method.
             */
            string allupper = "ABC";
            Console.WriteLine(allupper.HasAllUpper());

            /*
                Implementing ValidNumeric method.
             */
            string validNumeric = "55";
            Console.WriteLine(validNumeric.ValidNumeric());

            /*
                Implementing RemoveLastCharacter method.
             */
            string lastChar = "abc";
            Console.WriteLine(lastChar.RemoveLastCharacter());

            /*
                Implementing WordCount method.
             */
            string wordCount = "abc";
            Console.WriteLine(wordCount.WordCount());

            /*
                Implementing StringToInteger method.
             */
            string strtoint = "5589";
            Console.WriteLine(strtoint.StringToInteger());
        }
    }
}
