using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElit.Interfaces;

namespace _08.MilitaryElit.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        private void ParseCorps(string corps)
        {
            bool parsed = Enum.TryParse(typeof(Interfaces.Corps), corps, out object outValue);

            if (!parsed)
            {
                throw new ArgumentException("Invalid corps!");
            }

            this.Corps = (Interfaces.Corps)outValue;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps.ToString()}");

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
