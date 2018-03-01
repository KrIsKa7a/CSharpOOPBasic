using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElit.Interfaces;

namespace _08.MilitaryElit.Models
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<ISoldier> privates;

        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
        {
            get { return this.privates; }
        }

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var @private in Privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
