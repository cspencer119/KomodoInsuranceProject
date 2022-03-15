using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProject
{
    public class DevTeam
    {
        public List<Developer> Team { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public List<Developer> Devs { get; }

        public DevTeam(List<Developer> team, string name, int id)
        {
            Team = team;
            Name = name;
            ID = id;
        }

        public DevTeam()
        {

        }

        public DevTeam(List<Developer> devs)
        {
            Devs = devs;
        }
    }
}
