using System;

namespace TestingAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                <summary>
                    Implementing ToLowerCase method.
                </summary>
             */
            string uppercase = "ABC";
            Console.WriteLine(uppercase.ToLowerCase());

            /*
                <summary>
                    Implementing ToUpperCase method.
                </summary>
             */
            string lowercase = "abc";
            Console.WriteLine(lowercase.ToUpperCase());

            /*
                <summary>
                    Implementing ToTitleCase method.
                </summary>
             */
            string titlecase = "abc";
            Console.WriteLine(titlecase.ToTitleCase());

            /*
                <summary>
                    Implementing HasAllLower method.
                </summary>
             */
            string alllower = "abc";
            Console.WriteLine(alllower.HasAllLower());

            /*
                <summary>
                    Implementing FirstLetterToUpper method.
                </summary>
             */
            string firstletter = "abc";
            Console.WriteLine(firstletter.FirstLetterToUpper());

            /*
                <summary>
                    Implementing HasAllUpper method.
                </summary>
             */
            string allupper = "ABC";
            Console.WriteLine(allupper.HasAllUpper());

            /*
                <summary>
                    Implementing ValidNumeric method.
                </summary>
             */
            string validNumeric = "55";
            Console.WriteLine(validNumeric.ValidNumeric());

            /*
                <summary>
                    Implementing RemoveLastCharacter method.
                </summary>
             */
            string lastChar = "abc";
            Console.WriteLine(lastChar.RemoveLastCharacter());

            /*
                <summary>
                    Implementing WordCount method.
                </summary>
             */
            string wordCount = "abc";
            Console.WriteLine(wordCount.WordCount());

            /*
                <summary>
                    Implementing StringToInteger method.
                </summary>
             */
            string strtoint = "5589";
            Console.WriteLine(strtoint.StringToInteger());
        }
    }
}
