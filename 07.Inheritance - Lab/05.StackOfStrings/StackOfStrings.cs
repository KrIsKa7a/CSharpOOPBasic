using System;
using System.Collections.Generic;
using System.Text;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string output = GetOutput();
        this.data.RemoveAt(data.Count - 1);

        return output;
    }

    public string Peek()
    {
        string output = GetOutput();

        return output;
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }

    private string GetOutput()
    {
        string output = null;

        if (IsEmpty())
        {
            return output;
        }

        return output = this.data[data.Count - 1];
    }
}
