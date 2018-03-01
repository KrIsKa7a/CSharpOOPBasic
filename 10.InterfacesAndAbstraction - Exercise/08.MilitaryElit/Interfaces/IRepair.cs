using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElit.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
