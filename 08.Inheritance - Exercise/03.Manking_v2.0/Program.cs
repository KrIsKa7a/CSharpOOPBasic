using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] studentInfo = Console.ReadLine()
            .Split();

        var studentFirstName = studentInfo[0];
        var studentLastName = studentInfo[1];
        var studentNumber = studentInfo[2];

        string[] workerInfo = Console.ReadLine()
            .Split();
        var workerFirstName = workerInfo[0];
        var workerLastName = workerInfo[1];
        var workerWeekSalary = decimal.Parse(workerInfo[2]);
        var workerWorkHoursPerDay = decimal.Parse(workerInfo[3]);

        try
        {
            var student = new Student(studentFirstName, studentLastName, studentNumber);
            var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerWorkHoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
