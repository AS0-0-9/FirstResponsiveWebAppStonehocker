using System;
using Xunit;
using FirstResponsiveWebAppStonehocker;
using FirstResponsiveWebAppStonehocker.Models;

namespace FirstResponsiveWebAppUnitTests
{
    public class AgeCalulateUnitTests
    {
        [Fact]
        public void BirthdayAlreadyPassed()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(1990, 1, 1) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = 36;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BirthdayNotPassed()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(1990, 10, 1) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = 35;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BirthdayToday()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(1990, 9, 15) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = 36;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NullBirthday()
        {
            //Arrange
            var model = new AgeThisYear ();
            var today = new DateOnly(2026, 9, 15);


            //Act and Assert (had to be combined to see if the exception was thrown)
            Assert.Throws<InvalidOperationException>(() => model.CalculateAge(today));
        }
        [Fact]
        public void FutureBirthday()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(2030, 8, 15) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = -4;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LeapYearBirthday()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(1992, 2, 29) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = 34;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void BornToday()
        {
            //Arrange
            var model = new AgeThisYear { Birthday = new DateOnly(2026, 9, 15) };
            var today = new DateOnly(2026, 9, 15);

            int? expected = 0;
            int? actual;
            //Act
            actual = model.CalculateAge(today);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
