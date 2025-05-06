namespace DateTimeMaman.Common.Extensions;

public static class DateTimeExtensions
{
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
}
