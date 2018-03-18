using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Interfaces
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
