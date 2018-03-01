using System;
using System.Collections.Generic;
using System.Text;

public class AddRemoveCollection : AddCollection, IAddRemoveCollection
{
    protected new List<string> collection;

    public AddRemoveCollection()
    {
        this.collection = new List<string>();
    }

    public override int Add(string item)
    {
        this.collection.Insert(0, item);

        return 0;
    }

    public virtual string Remove()
    {
        var itemRemoved = collection[collection.Count - 1];

        collection.RemoveAt(collection.Count - 1);

        return itemRemoved;
    }
}
