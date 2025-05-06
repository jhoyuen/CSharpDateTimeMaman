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