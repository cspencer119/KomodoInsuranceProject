using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceProject
{
    public class ProgramUI
    {
 private DevTeamsRepo developerRepo = new DevTeamsRepo();
        private DeveloperRepo developerTeamRepo = new DeveloperRepo();

        public void Run()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Insurance");
                Console.WriteLine("Please select and Option:\n" +
                    "1. Developer Management\n" +
                    "2. Manage Teams\n" +
                    "3. Exit");
                int option = 0;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Reposne");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Run();
                }
                switch (option)
                {
                    case 1:
                        DeveloperManagementMenu();
                        break;
                    case 2:
                        ManageTeamMenu();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Response.");
                        break;
                }
            }
        }
        private void DeveloperManagementMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayDeveloperList();
                int select = 0;
                Console.WriteLine("Select an option please:\n" +
                    "1. Add a developer\n" +
                    "2. Update an existing developer\n" +
                    "3. Delete an existing developer\n" +
                    "4. Return to Main Menu");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Response");
                    DeveloperManagementMenu();
                }
                switch (select)
                {
                    case 1:
                        AddDeveloper();
                        break;
                    case 2:
                        UpdateDeveloper();
                        break;
                    case 3:
                        DeleteDeveloper();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ManageTeamMenu()
        {
            bool exit = false;
            while (exit != true)
            {
                Console.Clear();
                DisplayTeamList();
                int select = 0;
                Console.WriteLine("Please select an option:\n" +
                    "1. Add a Team to the system\n" +
                    "2. Update/Change an existing Team\n" +
                    "3. Delete an existing Team\n" +
                    "4. Return to Main Menu");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Response");
                    ManageTeamMenu();
                }
                switch (select)
                {
                    case 1:
                        AddTeam();
                        break;
                    case 2:
                        UpdateExistingTeam();
                        break;
                    case 3:
                        DeleteTeam();
                        break;
                }
            }
        }


        private void DisplayTeamList()
        {
            List<DevTeam> list = developerTeamRepo.GetDeveloperTeamList();
            foreach (DevTeam team in list)
            {
                DisplayTeam(team);
            }
        }

        private void DisplayTeam(DevTeam team, bool showMembers = false)
        {
            Console.WriteLine($"ID: {team.Team} Name: {team.Name} Number of developers: {team.Team.Count}");
            if (showMembers)
            {
                foreach (Developer dev in team.Team)
                {
                    DisplayDeveloper(dev);
                }
            }
        }

        private void DisplayTeam(int id, string name, List<Developer> devs, bool showMembers = false)
        {
            Console.WriteLine($"ID: {id} Name: {name} Number of developers: {devs.Count}");
            if (showMembers)
            {
                foreach (Developer dev in devs)
                {
                    DisplayDeveloper(dev);
                }
            }
        }

        private void DisplayDeveloperList()
        {
            List<Developer> list = developerRepo.GetDeveloperList();
            foreach (Developer dev in list)
            {
                DisplayDeveloper(dev);
            }
        }

        private Developer FindDeveloper()
        {
            DisplayDeveloperList();
            Console.WriteLine("Dev ID (e to exit)");
            string response = Console.ReadLine();
            if (response.ToLower() != "e")
            {
                int oldId = int.Parse(response);
                return developerRepo.GetDevTeamById(oldId);
            }
            return null;
        }

        private DevTeam FindTeam()
        {
            DisplayTeamList();
            Console.WriteLine("Team ID (e to exit)");
            string response = Console.ReadLine();
            if (response.ToLower() != "e")
            {
                int oldId = int.Parse(response);
                return developerTeamRepo.GetTeamById(oldId);
            }
            return null;
        }

        private void DisplayDeveloper(Developer dev)
        {
            Console.WriteLine($"ID: {dev.ID} Name: {dev.Name} Access: {dev.PluralsightAccess}");
        }

        private void DisplayDeveloper(int id, string name, bool access)
        {
            Console.WriteLine($"ID: {id} Name: {name} Access: {access}");
        }

        private void AddDeveloper()
        {
            Console.Clear();
            Console.WriteLine("ID: ");
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Response.");
                DeveloperManagementMenu();
            }

            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Pluralsight Access Y/N:");
            string access = Console.ReadLine().ToLower();
            bool pluralAccess;
            if (access == "y")
            {
                pluralAccess = true;
            }
            else if (access == "n")
            {
                pluralAccess = false;
            }
            else
            {
                pluralAccess = false;
            }
            Developer dev = new Developer()
            {
                ID = id,
                Name = name,
                PluralsightAccess = pluralAccess
            };
            developerRepo.AddDeveloper(dev);
        }

        private bool UpdateDeveloper()
        {
            Console.Clear();
            Developer dev = FindDeveloper();
            int oldId = dev.ID;
            string oldName = dev.Name;
            bool oldAccess = dev.PluralsightAccess;

            if (dev != null)
            {
                int newId = 0;
                string newName = "";
                bool newAccess = false;
                bool loopExit = true;
                string response = null;
                if (dev == null)
                {
                    return false;
                }
                DisplayDeveloper(dev);
                while (loopExit)
                {
                    Console.WriteLine("New ID, press n for -no change- :");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newId = int.Parse(response);
                            loopExit = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please provide a valid response");
                        }
                    }
                    else
                    {
                        newId = oldId;
                    }
                    loopExit = false;
                }
                loopExit = true;
                Console.Clear();
                DisplayDeveloper(dev);
                while (loopExit)
                {
                    Console.WriteLine("New Name: please press n for -no change-:");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newName = response;
                            loopExit = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a valid response");
                        }
                    }
                    else
                    {
                        newName = oldName;
                    }
                    loopExit = false;
                }
                loopExit = true;
                Console.Clear();
                DisplayDeveloper(dev);
                while (loopExit)
                {
                    Console.WriteLine("New Access to PluralSight Y/N: Press -nc- for -no change-");
                    response = Console.ReadLine().ToLower();
                    if (response != "nc")
                    {
                        try
                        {
                            if (response.ToLower() == "y")
                            {
                                newAccess = true;
                            }
                            else if (response.ToLower() == "n")
                            {
                                newAccess = false;
                            }
                            loopExit = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a valid response");
                        }
                    }
                    else
                    {
                        newAccess = oldAccess;
                    }
                    loopExit = false;
                }

                DisplayDeveloper(newId, newName, newAccess);
                Console.WriteLine("Are these updates accurate? Y/N");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    developerRepo.UpdateDeveloper(oldId, new Developer() { Name = newName, ID = newId, PluralsightAccess = newAccess });
                }
                else if (answer == "n")
                {
                    UpdateDeveloper();
                }
            }
            return false;
        }

        private void DeleteDeveloper()
        {
            Developer dev = FindDeveloper();
            DisplayDeveloper(dev);
            Console.WriteLine("Do you want to delete this developer from the system? Y/N");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                developerRepo.DeleteDeveloper(dev.ID);
                Console.WriteLine("Developer has been deleted from the system. Bye-Bye!");

            }
        }

        private void AddTeam()
        {
            Console.Clear();
            Console.WriteLine("ID: ");
            int id = 0;
            List<Developer> devs = new List<Developer>();
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please add a valid response.");
                DeveloperManagementMenu();
            }

            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            DevTeam team = new DevTeam(devs)
            {
                ID = id,
                Name = name,
                Team = devs
            };
            developerTeamRepo.AddDeveloperTeam(team);
            Console.WriteLine("Do you want to add these developers? Y/N");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                AddDeveloperToTeam(id);
            }
        }

        private void AddDeveloperToTeam(int id)
        {
            Console.Clear();
            bool more = true;
            string response = "";
            DevTeam team = developerTeamRepo.GetTeamById(id);
            string name = team.Name;
            List<Developer> currentList = new List<Developer>();
            while (more)
            {
                Developer dev = FindDeveloper();
                currentList.Add(dev);
                DisplayTeam(id, name, currentList, true);
                Console.WriteLine("Add more? (y/n)");
                response = Console.ReadLine().ToLower();
                if (response == "n")
                {
                    more = false;
                }
            }
            Console.Clear();
            DisplayTeam(id, name, currentList, true);
            Console.WriteLine("Is this correct? (y/n)");
            response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                developerTeamRepo.AddDeveloperListToTeam(id, currentList);
            }

        }

        private bool UpdateExistingTeam()
        {
            Console.Clear();
            DevTeam team = FindTeam();
            if (team == null)
            {
                return false;
            }
            int oldId = team.ID;
            string oldName = team.Name;
            List<Developer> oldMembers = team.Team;

            if (team != null)
            {
                int newId = 0;
                string newName = "";
                List<Developer> newMembers = new List<Developer>();
                bool loopExit = true;
                string response = null;
                if (team == null)
                {
                    return false;
                }
                DisplayTeam(team, true);
                while (loopExit)
                {
                    Console.WriteLine("New ID (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newId = int.Parse(response);
                            loopExit = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newId = oldId;
                    }
                    loopExit = false;
                }
                loopExit = true;
                Console.Clear();
                DisplayTeam(team);
                while (loopExit)
                {
                    Console.WriteLine("New name (n for no change):");
                    response = Console.ReadLine().ToLower();
                    if (response != "n")
                    {
                        try
                        {
                            newName = response;
                            loopExit = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Invalid Response");
                        }
                    }
                    else
                    {
                        newName = oldName;
                    }
                    loopExit = false;
                }
                loopExit = true;
                Console.Clear();
                DisplayTeam(newId, newName, newMembers, true);
                Console.WriteLine("Is this correct? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    developerTeamRepo.UpdateExistingTeam(oldId, new DevTeam() { Name = newName, ID = newId, Team = newMembers });
                }
                else if (answer == "n")
                {
                    UpdateExistingTeam();
                }
            }
            return false;
        }

        private void DeleteTeam()
        {
            DevTeam devTeam = FindTeam();
            DisplayTeam(devTeam);
            Console.WriteLine("Are you sure you want to remove this team? Y/N");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                Console.WriteLine("Are you certain? (y/n)");
                response = Console.ReadLine().ToLower();
                if (response == "y")
                {
                    developerTeamRepo.RemoveDeveloperTeam(devTeam.ID);
                    Console.WriteLine("Team removed");
                }
            }


            //private void SeedContent(){}
        }
    }
}
