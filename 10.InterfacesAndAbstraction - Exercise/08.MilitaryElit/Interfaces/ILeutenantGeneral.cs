﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElit.Interfaces
{
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
    }
}
