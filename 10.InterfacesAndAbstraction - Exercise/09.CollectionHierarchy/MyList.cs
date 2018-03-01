using System;
using System.Collections.Generic;
using System.Text;

public class MyList : AddRemoveCollection, IMyList
{
    public MyList()
    {
        this.collection = new List<string>();
    }

    public override sealed string Remove()
    {
        //Console.WriteLine(String.Join(" ", collection));

        var itemRemoved = this.collection[0];

        collection.RemoveAt(0);

        return itemRemoved;
    }

    public int Used()
    {
        return this.collection.Count;
    }
}
