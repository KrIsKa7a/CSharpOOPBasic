using System;
using System.Collections.Generic;
using System.Text;

public class AddCollection : IAddCollection
{
    protected List<string> collection;

    public AddCollection()
    {
        this.collection = new List<string>();
    }

    public List<string> Collection { get; private set; }

    public virtual int Add(string item)
    {
        this.collection.Add(item);

        var indexToAdd = this.collection.Count - 1;

        return indexToAdd;
    }
}
