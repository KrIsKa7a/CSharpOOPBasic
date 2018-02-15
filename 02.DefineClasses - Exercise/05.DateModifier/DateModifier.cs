using System;
using System.Globalization;
public class DateModifier
{
    public double CalculateDifference(string date1, string date2)
    {
        var firstDate = ParseDate(date1);
        var secondDate = ParseDate(date2);

        return Math.Abs((firstDate - secondDate).TotalDays);
    }

    private DateTime ParseDate(string date)
    {
        return DateTime.ParseExact(date, "yyyy MM dd",
            CultureInfo.InvariantCulture);
    }
}
