using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElit.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
