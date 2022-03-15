using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProject
{
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool PluralsightAccess { get; set; }
        public Developer(string name, int it, bool access)
        {

            Name = name;
            ID = ID;
            PluralsightAccess = access;
        }
        public Developer()
        {
        }
    }
}
