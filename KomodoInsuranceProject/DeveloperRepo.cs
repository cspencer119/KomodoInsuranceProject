using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProject
{
    public class DeveloperRepo
    {
    private List<Developer> devList = new List<Developer>();

        public void AddDeveloper(Developer dev)
        {
            devList.Add(dev);
        }

        public List<Developer> GetDeveloperList()
        {
            return devList;
        }

        public bool UpdateExistingDeveloper(int id, Developer newDev)
        {
            Developer oldDev = GetDevById(id);
            if (oldDev != null)
            {
                oldDev.Name = newDev.Name;
                oldDev.ID = newDev.ID;
                oldDev.PluralsightAccess = newDev.PluralsightAccess;
                return true;
            }
            return false;
        }

        public bool RemoveDeveloper(int id)
        {
            Developer dev = GetDevById(id);
            if (dev != null)
            {
                int initialCount = devList.Count;
                devList.Remove(dev);
                if (initialCount > devList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Developer GetDevById(int id)
        {
            foreach (Developer dev in devList)
            {
                if (dev.ID == id)
                {
                    return dev;
                }
            }

            return null;
        }

        internal List<DevTeam> GetDeveloperTeamList()
        {
            throw new NotImplementedException();
        }

        internal DevTeam GetTeamById(int oldId)
        {
            throw new NotImplementedException();
        }

        internal void AddDeveloperTeam(DevTeam team)
        {
            throw new NotImplementedException();
        }

        internal void AddDeveloperListToTeam(int id, List<Developer> currentList)
        {
            throw new NotImplementedException();
        }

        internal void UpdateExistingTeam(int oldId, DevTeam devTeam)
        {
            throw new NotImplementedException();
        }

        internal void RemoveDeveloperTeam(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
