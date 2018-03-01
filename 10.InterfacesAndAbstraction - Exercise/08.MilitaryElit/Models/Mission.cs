using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElit.Interfaces;

namespace _08.MilitaryElit.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            ParseState(state);
        }

        private void ParseState(string state)
        {
            bool parsed = Enum.TryParse(typeof(Interfaces.State), state, out object outValue);

            if (!parsed)
            {
                throw new ArgumentException("Invalid mission state!");
            }

            this.State = (Interfaces.State)outValue;
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidOperationException("Mission already finished!");
            }

            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
