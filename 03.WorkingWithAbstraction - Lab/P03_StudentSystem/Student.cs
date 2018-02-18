using System;
using System.Collections.Generic;

public class Student
{
    private string name;
    private int age;
    private double grade;

    public double Grade
    {
        get { return grade; }
        private set { grade = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.grade = grade;
    }

    public override string ToString()
    {
        var gradeCommentary = GetGradeComment(this.grade);

        return $"{this.name} is {this.age} years old. {gradeCommentary}";
    }

    private string GetGradeComment(double grade)
    {
        if (this.grade >= 5.00)
        {
            return "Excellent student.";
        }
        else if (this.grade < 5.00 && this.grade >= 3.50)
        {
            return "Average student.";
        }
        else
        {
            return "Very nice person.";
        }
    }
}