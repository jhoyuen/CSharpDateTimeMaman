# DateTimeMaman
A library of extension methods to assist with some common date and time operations

## JDM-2: Introduce `IsUnderAge` extension method
- Find out from a `DateTime`, usually a date of birth, if a person with this date of birth is under age
```
public static bool IsUnderAge(this DateTime dateOfBirth, int minimumAge, DateTime? today = null)
{
    today = today ?? DateTime.Today;
    int age = today.Value.Year - dateOfBirth.Year;
    age = GetCorrectAge(dateOfBirth, today.Value, age);

    return age < minimumAge;
}

private static int GetCorrectAge(DateTime dateOfBirth, DateTime today, int age)
{
    if (dateOfBirth.Date > today.AddYears(-age))
    {
        age--;
    }

    return age;
}
```

## JDM-3: Calculate the number of days between a start and end date
```
public static int CountDaysBetweenDates(this DateOnly startDate, DateOnly endDate) => Math.Abs(endDate.DayNumber - startDate.DayNumber);
```

## JDM-4: From a local DateTime, convert and get the specific country DateTime by country code
```
public static DateTime FromLocalToSpecificCountryDateTime(this DateTime dateTime, string countryCode)
{
    if (string.IsNullOrWhiteSpace(countryCode))
        throw new ArgumentException("Country code must be provided.");

    var upperCode = countryCode.Trim().ToUpperInvariant();

    if (!Constants.CountryTimeZones.TryGetValue(upperCode, out var timezoneId))
        throw new ArgumentException($"Time zone for country code '{countryCode}' not found.");

    var utcDateTime = dateTime.ToUniversalTime();
    var tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);

    return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tzInfo);
}
```