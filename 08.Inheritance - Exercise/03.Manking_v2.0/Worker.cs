using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private const int MIN_WEEK_SALARY = 10;

    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        private set
        {
            if (value <= MIN_WEEK_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursPerDay = value;
        }
    }

    public decimal SalaryPerHour
    {
        get { return this.CalculateSalaryPerHour(); }
    }

    private decimal CalculateSalaryPerHour()
    {
        return WeekSalary / (WorkHoursPerDay * 5.0m);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        var result = sb.ToString().TrimEnd();

        return result;
    }
}
