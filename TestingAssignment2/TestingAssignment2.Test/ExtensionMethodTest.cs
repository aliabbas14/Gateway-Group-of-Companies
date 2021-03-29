using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TestingAssignment2;

namespace TestingAssignment2.Test
{
    public class ExtensionMethodTest
    {

        /*
            <summary>
                This method tests the ToLowerCase method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToLowerCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.ToLowerCase();

            //Assert
            Assert.Equal("abc", res);
        }

        /*
            <summary>
                This method tests the ToLowerCase method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToLowerCaseFail()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.ToLowerCase();

            //Assert
            Assert.NotEqual("Abc", res);
        }

        /*
            <summary>
                This method tests the ToLowerCase method if all the inputs are not entered coorectly.
            </summary>
             */
        public void Test_ToLowerCaseLowerCase()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.ToLowerCase();

            //Assert
            Assert.Equal("abc", res);
        }

        /*
            <summary>
                This method tests the ToLowerCase method if all the inputs are not entered coorectly.
            </summary>
             */
        public void Test_ToLowerCaseSpecialCharacter()
        {
            //Arrange
            string data = "@$/&*";

            //Act
            string res = data.ToLowerCase();

            //Assert
            Assert.Equal("@$/&*", res);
        }

        /*
            <summary>
                This method tests the ToLowerCase method if all the inputs are not entered coorectly.
            </summary>
             */
        public void Test_ToLowerCaseTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            string res = data.ToLowerCase();

            //Assert
            Assert.Equal("abc", res);
        }

        /*
            <summary>
                This method tests the ToUpperCase method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToUpperCase()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.ToUpperCase();

            //Assert
            Assert.Equal("ABC", res);
        }


        /*
            <summary>
                This method tests the ToUpperCase method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToUpperCaseFail()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.ToUpperCase();

            //Assert
            Assert.NotEqual("Abc", res);
        }

        /*
           <summary>
               This method tests the ToUpperCase method if all the inputs are not entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_ToUpperCaseUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.ToUpperCase();

            //Assert
            Assert.Equal("ABC", res);
        }


        /*
          <summary>
              This method tests the ToUpperCase method if all the inputs are not entered coorectly.
          </summary>
           */
        [Fact]
        public void Test_ToUpperCaseSpecialCharacter()
        {
            //Arrange
            string data = "$#&*";

            //Act
            string res = data.ToUpperCase();

            //Assert
            Assert.Equal("$#&*", res);
        }


        /*
          <summary>
              This method tests the ToUpperCase method if all the inputs are not entered coorectly.
          </summary>
           */
        [Fact]
        public void Test_ToUpperCaseTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            string res = data.ToUpperCase();

            //Assert
            Assert.Equal("ABC", res);
        }


        /*
            <summary>
                This method tests the ToTitleCase method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToTitleCase()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.ToTitleCase();

            //Assert
            Assert.Equal("Abc", res);
        }

        /*
            <summary>
                This method tests the ToTitleCase method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToTitleCaseFail()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.ToTitleCase();

            //Assert
            Assert.NotEqual("ABC", res);
        }


        /*
            <summary>
                This method tests the ToTitleCase method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToTitleCaseUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.ToTitleCase();

            //Assert
            Assert.Equal("Abc", res);
        }

        /*
            <summary>
                This method tests the ToTitleCase method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ToTitleCaseSpecialCharacter()
        {
            //Arrange
            string data = "#$%&";

            //Act
            string res = data.ToTitleCase();

            //Assert
            Assert.Equal("#$%&", res);
        }


        /*
           <summary>
               This method tests the ToTitleCase method if all the inputs are not entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_ToTitleCaseTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            string res = data.ToTitleCase();

            //Assert
            Assert.Equal("Abc", res);
        }


        /*
            <summary>
                This method tests the HasAllLower method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllLower()
        {
            //Arrange
            string data = "abc";

            //Act
            bool res = data.HasAllLower();

            //Assert
            Assert.True(res);
        }

        /*
            <summary>
                This method tests the HasAllLower method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllLowerFail()
        {
            //Arrange
            string data = "Abc";

            //Act
            bool res = data.HasAllLower();

            //Assert
            Assert.False(res);
        }


        /*
           <summary>
               This method tests the HasAllLower method if all the inputs are entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_HasAllLowerUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            bool res = data.HasAllLower();

            //Assert
            Assert.False(res);
        }

        /*
           <summary>
               This method tests the HasAllLower method if all the inputs are entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_HasAllLowerSpecialCharacter()
        {
            //Arrange
            string data = "@#$%";

            //Act
            bool res = data.HasAllLower();

            //Assert
            Assert.False(res);
        }


        /*
           <summary>
               This method tests the HasAllLower method if all the inputs are entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_HasAllLowerTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            bool res = data.HasAllLower();

            //Assert
            Assert.False(res);
        }


        /*
            <summary>
                This method tests the FirstLetterToUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_FirstLetterToUpper()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.FirstLetterToUpper();

            //Assert
            Assert.Equal("Abc",res);
        }

        /*
            <summary>
                This method tests the FirstLetterToUpper method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_FirstLetterToUpperFail()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.FirstLetterToUpper();

            //Assert
            Assert.NotEqual("ABC", res);
        }


        /*
            <summary>
                This method tests the FirstLetterToUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_FirstLetterToUpperUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.FirstLetterToUpper();

            //Assert
            Assert.Equal("ABC", res);
        }


        /*
            <summary>
                This method tests the FirstLetterToUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_FirstLetterToUpperSpecialCharacter()
        {
            //Arrange
            string data = "#$%^";

            //Act
            string res = data.FirstLetterToUpper();

            //Assert
            Assert.Equal("#$%^", res);
        }

        /*
            <summary>
                This method tests the HasAllUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllUpper()
        {
            //Arrange
            string data = "ABC";

            //Act
            bool res = data.HasAllUpper();

            //Assert
            Assert.True(res);
        }

        /*
            <summary>
                This method tests the HasAllUpper method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllUpperFail()
        {
            //Arrange
            string data = "Abc";

            //Act
            bool res = data.HasAllUpper();

            //Assert
            Assert.False(res);
        }


        /*
            <summary>
                This method tests the HasAllUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllUpperSpecialCharacter()
        {
            //Arrange
            string data = "#$%^";

            //Act
            bool res = data.HasAllUpper();

            //Assert
            Assert.False(res);
        }


        /*
            <summary>
                This method tests the HasAllUpper method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_HasAllUpperTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            bool res = data.HasAllUpper();

            //Assert
            Assert.False(res);
        }

        /*
            <summary>
                This method tests the ValidNumeric method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ValidNumeric()
        {
            //Arrange
            string data = "55";

            //Act
            bool res = data.ValidNumeric();

            //Assert
            Assert.True(res);
        }

        /*
            <summary>
                This method tests the ValidNumeric method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ValidNumericFail()
        {
            //Arrange
            string data = "abc55";

            //Act
            bool res = data.ValidNumeric();

            //Assert
            Assert.False(res);
        }


        /*
            <summary>
                This method tests the ValidNumeric method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ValidNumericUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            bool res = data.ValidNumeric();

            //Assert
            Assert.False(res);
        }

        /*
            <summary>
                This method tests the ValidNumeric method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ValidNumericSpecialCharacter()
        {
            //Arrange
            string data = "#$%^";

            //Act
            bool res = data.ValidNumeric();

            //Assert
            Assert.False(res);
        }


        /*
            <summary>
                This method tests the ValidNumeric method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_ValidNumericTitleCase()
        {
            //Arrange
            string data = "Abc";

            //Act
            bool res = data.ValidNumeric();

            //Assert
            Assert.False(res);
        }

        /*
            <summary>
                This method tests the RemoveLastCharacter method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_RemoveLastCharacter()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.RemoveLastCharacter();

            //Assert
            Assert.Equal("ab",res);
        }

        /*
            <summary>
                This method tests the RemoveLastCharacter method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_RemoveLastCharacterFail()
        {
            //Arrange
            string data = "abc";

            //Act
            string res = data.RemoveLastCharacter();

            //Assert
            Assert.NotEqual("abc", res);
        }

        /*
            <summary>
                This method tests the RemoveLastCharacter method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_RemoveLastCharacterUpperCasse()
        {
            //Arrange
            string data = "ABC";

            //Act
            string res = data.RemoveLastCharacter();

            //Assert
            Assert.Equal("AB", res);
        }


        /*
            <summary>
                This method tests the RemoveLastCharacter method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_RemoveLastCharacterSpecialCharacter()
        {
            //Arrange
            string data = "#$%^";

            //Act
            string res = data.RemoveLastCharacter();

            //Assert
            Assert.Equal("#$%", res);
        }

        /*
            <summary>
                This method tests the WordCount method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_WordCount()
        {
            //Arrange
            string data = "abc";

            //Act
            int res = data.WordCount();

            //Assert
            Assert.Equal(3, res);
        }

        /*
            <summary>
                This method tests the WordCount method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_WordCountFail()
        {
            //Arrange
            string data = "abc";

            //Act
            int res = data.WordCount();

            //Assert
            Assert.Equal(2, res);
        }


        /*
            <summary>
                This method tests the WordCount method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_WordCountUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            int res = data.WordCount();

            //Assert
            Assert.Equal(3, res);
        }


        /*
            <summary>
                This method tests the WordCount method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_WordCountSpecialCharacter()
        {
            //Arrange
            string data = "$%^&";

            //Act
            int res = data.WordCount();

            //Assert
            Assert.Equal(4, res);
        }

        /*
            <summary>
                This method tests the StringToInteger method if all the inputs are entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_StringToInteger()
        {
            //Arrange
            string data = "55";

            //Act
            int res = data.StringToInteger();

            //Assert
            Assert.Equal(55, res);
        }

        /*
            <summary>
                This method tests the StringToInteger method if all the inputs are not entered coorectly.
            </summary>
             */
        [Fact]
        public void Test_StringToIntegerFail()
        {
            //Arrange
            string data = "55";

            //Act
            int res = data.StringToInteger();

            //Assert
            Assert.NotEqual(45, res);
        }

        /*
           <summary>
               This method tests the StringToInteger method if all the inputs are entered coorectly.
           </summary>
            */
        [Fact]
        public void Test_StringToIntegerUpperCase()
        {
            //Arrange
            string data = "ABC";

            //Act
            int res = data.StringToInteger();

            //Assert
            Assert.NotEqual(55, res);
        }
    }
}
