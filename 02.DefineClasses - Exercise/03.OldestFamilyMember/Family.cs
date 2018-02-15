using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Family
{
    private List<Person> members;

    public List<Person> Members
    {
        get { return this.members; }
        set { this.members = value; }
    }

    public Family()
    {
        this.members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members
            .OrderByDescending(m => m.Age)
            .FirstOrDefault();
    }
}
