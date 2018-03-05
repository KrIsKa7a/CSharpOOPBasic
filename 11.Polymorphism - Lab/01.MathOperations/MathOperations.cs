using System;
using System.Collections.Generic;
using System.Text;

public class MathOperations
{
    public int Add(int a, int b)
    {
        var sum = a + b;

        return sum;
    }

    public double Add(double a, double b, double c)
    {
        var sum = a + b + c;

        return sum;
    }

    public decimal Add(decimal a, decimal b, decimal c)
    {
        var sum = a + b + c;

        return sum;
    }
}