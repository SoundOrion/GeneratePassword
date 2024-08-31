using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PasswordLibrary;
using System;

namespace PasswordLibrary.Tests
{
    [TestClass]
    public class RandomPasswordTests
    {
        [TestMethod]
        public void Generate_ShouldReturnPasswordWithCorrectLength()
        {
            // Arrange
            var generator = new RandomPassword();
            int expectedLength = 10;

            // Act
            string result = generator.Generate(expectedLength, true, true, true, true);

            // Assert
            Assert.AreEqual(expectedLength, result.Length, "生成されたパスワードの長さが期待値と一致しません。");
        }

        [TestMethod]
        public void Generate_ShouldIncludeUpperCaseWhenRequired()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            string result = generator.Generate(10, true, false, false, false);

            // Assert
            Assert.IsTrue(result.Any(char.IsUpper), "生成されたパスワードに大文字が含まれていません。");
        }

        [TestMethod]
        public void Generate_ShouldIncludeLowerCaseWhenRequired()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            string result = generator.Generate(10, false, true, false, false);

            // Assert
            Assert.IsTrue(result.Any(char.IsLower), "生成されたパスワードに小文字が含まれていません。");
        }

        [TestMethod]
        public void Generate_ShouldIncludeNumbersWhenRequired()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            string result = generator.Generate(10, false, false, true, false);

            // Assert
            Assert.IsTrue(result.Any(char.IsDigit), "生成されたパスワードに数字が含まれていません。");
        }

        [TestMethod]
        public void Generate_ShouldIncludeMarksWhenRequired()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            string result = generator.Generate(10, false, false, false, true);

            // Assert
            Assert.IsTrue(result.Any(c => "!\"#$%&'()*+-/<=>?@;[]^".Contains(c)), "生成されたパスワードに記号が含まれていません。");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Generate_ShouldThrowExceptionWhenLengthIsZero()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            generator.Generate(0, true, true, true, true);

            // Assert
            // Expecting exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Generate_ShouldThrowExceptionWhenNoCharacterTypeSelected()
        {
            // Arrange
            var generator = new RandomPassword();

            // Act
            generator.Generate(10, false, false, false, false);

            // Assert
            // Expecting exception
        }
    }
}
