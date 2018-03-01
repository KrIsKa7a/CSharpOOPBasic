using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElit.Interfaces;

namespace _08.MilitaryElit.Models
{
    public class Engineer : SpecialisedSoldier, IEngeneer
    {
        private List<IRepair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
        {
            get { return this.repairs; }
        }

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
