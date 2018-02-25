using System;
using System.Collections.Generic;
using System.Text;

public class RandomList : List<string>
{
    private Random random = new Random();
    public string RandomString()
    {
        string result = null;

        if (base.Count > 0)
        {
            var randomIndex = random.Next(0, base.Count - 1);
            result = base[randomIndex];
            base.RemoveAt(randomIndex);
        }

        return result;
    }
}
