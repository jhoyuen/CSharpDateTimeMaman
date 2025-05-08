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

    #region CountDaysBetweenDates

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

    #endregion

    #region FromLocalToSpecificCountryDateTime

    [Theory]
    [InlineData("MU", 1, 8)]
    [InlineData("GB", 22, 7)]
    [InlineData("US", 17, 7)]
    public void FromLocalToSpecificCountryDateTime_ShouldReturnValidDateTime(string countryCode, int hourInTimeZone, int dateInTimeZone)
    {
        // Arrange
        var dateTime = new DateTime(2025, 5, 8, 7, 17, 0);

        // Act
        var result = dateTime.FromLocalToSpecificCountryDateTime(countryCode);

        // Assert
        Assert.Equal(dateTime.Kind, result.Kind);
        Assert.Equal(hourInTimeZone, result.Hour);
        Assert.Equal(dateInTimeZone, result.Day);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void FromLocalToSpecificCountryDateTime_WhenCountryCodeIsNullOrWhitespace_ShouldThrowArgumentException(string countryCode)
    {
        // Arrange
        var dateTime = new DateTime(2025, 5, 8, 7, 17, 0);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => dateTime.FromLocalToSpecificCountryDateTime(countryCode));
    }

    [Theory]
    [InlineData("ZZ")]
    [InlineData("just a test")]
    public void FromLocalToSpecificCountryDateTime_WhenCountryCodeNotFound_ShouldThrowArgumentException(string invalidCountryCode)
    {
        // Arrange
        var dateTime = new DateTime(2025, 5, 8, 7, 17, 0);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => dateTime.FromLocalToSpecificCountryDateTime(invalidCountryCode));
    }

    #endregion
}
