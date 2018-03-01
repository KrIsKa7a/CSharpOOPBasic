using System;
using System.Collections.Generic;
using System.Text;
using _08.MilitaryElit.Interfaces;

namespace _08.MilitaryElit.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions
        {
            get { return this.missions; }
        }

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
