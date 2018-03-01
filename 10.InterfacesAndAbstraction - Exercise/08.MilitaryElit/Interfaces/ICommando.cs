﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElit.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
