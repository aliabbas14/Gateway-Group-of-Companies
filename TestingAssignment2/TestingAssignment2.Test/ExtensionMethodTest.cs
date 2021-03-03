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
            This method tests the ToLowerCase method if all the inputs are entered coorectly.
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
            This method tests the ToLowerCase method if all the inputs are not entered coorectly.
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
            This method tests the ToUpperCase method if all the inputs are entered coorectly.
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
            This method tests the ToUpperCase method if all the inputs are not entered coorectly.
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
            This method tests the ToTitleCase method if all the inputs are entered coorectly.
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
            This method tests the ToTitleCase method if all the inputs are not entered coorectly.
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
            This method tests the HasAllLower method if all the inputs are entered coorectly.
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
            This method tests the HasAllLower method if all the inputs are not entered coorectly.
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
            This method tests the FirstLetterToUpper method if all the inputs are entered coorectly.
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
            This method tests the FirstLetterToUpper method if all the inputs are not entered coorectly.
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
            This method tests the HasAllUpper method if all the inputs are entered coorectly.
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
            This method tests the HasAllUpper method if all the inputs are not entered coorectly.
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
            This method tests the ValidNumeric method if all the inputs are entered coorectly.
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
            This method tests the ValidNumeric method if all the inputs are not entered coorectly.
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
            This method tests the RemoveLastCharacter method if all the inputs are entered coorectly.
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
            This method tests the RemoveLastCharacter method if all the inputs are not entered coorectly.
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
            This method tests the WordCount method if all the inputs are entered coorectly.
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
            This method tests the WordCount method if all the inputs are not entered coorectly.
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
            This method tests the StringToInteger method if all the inputs are entered coorectly.
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
            This method tests the StringToInteger method if all the inputs are not entered coorectly.
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
    }
}
