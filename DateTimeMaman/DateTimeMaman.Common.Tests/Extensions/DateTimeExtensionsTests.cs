using DateTimeMaman.Common.Extensions;

namespace DateTimeMaman.Common.Tests.Extensions;

public class DateTimeExtensionsTests
{
    #region IsUnderAge

    [Theory]
    [InlineData(4, 7, 2007)]
    [InlineData(7, 5, 2007)]
    [InlineData(25, 12, 2010)]
    public void IsUnderAge_WhenAgeLessThanMinimumAge_ShouldReturnTrue(int day, int month, int year)
    {
        // Arrange
        var dob = new DateTime(year, month, day);

        // Act
        bool isUnderAge = dob.IsUnderAge(18, new DateTime(2025, 5, 6));

        // Assert
        Assert.True(isUnderAge);
    }

    [Theory]
    [InlineData(6, 5, 2007)]
    [InlineData(11, 4, 2007)]
    [InlineData(15, 10, 1983)]
    public void IsUnderAge_WhenAgeGreaterThanMinimumAge_ShouldReturnFalse(int day, int month, int year)
    {
        // Arrange
        var dob = new DateTime(year, month, day);

        // Act
        bool isUnderAge = dob.IsUnderAge(18, new DateTime(2025, 5, 6));

        // Assert
        Assert.False(isUnderAge);
    }

    #endregion

    [Theory]
    [InlineData(12, 5, 2025)]
    [InlineData(2, 5, 2025)]
    public void CountDaysBetweenDates_ShouldReturnValidNumberOfDays(int day, int month, int year)
    {
        // Arrange
        var startDate = new DateOnly(2025, 5, 7);
        var endDate = new DateOnly(year, month, day);

        // Act
        var days = startDate.CountDaysBetweenDates(endDate);
        
        // Assert
        Assert.Equal(5, days);
    }
}
