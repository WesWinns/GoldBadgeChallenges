using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Badges
{
    public class ProgramUI
    {
        private bool _isrunning = true;
        private readonly BadgeRepository _badgeRepository = new BadgeRepository();


        public void Run()
        {
            SeedBadges();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isrunning)
            {
                string input = GetMenuSelection();
                OpenMenuItems(input);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number:\n" +
                "1. List all badges.\n" +
                "2. Ass a new badge.\n" +
                "3. Edit a badge\n" +
                "4. Exit");

            string input = Console.ReadLine();
            return input;

        }

        private void OpenMenu(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    ListBadges();
                    break;
                case "2":
                    AddNewBadge();
                    break;
                case "3":
                    EditBadge();
                    break;
                case "4":
                    _isrunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection.");
                    return;

            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        private void ListBadges()
        {
            var badges = _badgeRepository.GetBadgeDictionary();

            foreach (var badge in badges)
            {
                DisplayContent(badge);
            }
        }

        private void DisplayContent(KeyValuePair<int, List<string>> badge)
        {
            string doors = " ";
            foreach (var door in badge.Value)
            {
                doors = doors + door + " ";
            }
            Console.WriteLine($"{badge.Key}\n" +
                $"{doors}");
        }

        private void AddNewBadge()
        {
            var badge = new Badge();

            Console.WriteLine("Please enter Badge ID:");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            badge.BadgeID = badgeID;
            badge.ListOfDoors = GetListOfDoors();

            _badgeRepository.AddBadge(badge);
        }

        private List<string> GetListOfDoors()
        {
            Console.WriteLine("Enter access door(s):");

            while (true)
            {
                string doorOpens = Console.ReadLine();
                List<string> doorList = doorOpens.Split(' ').ToList();
            }
        }

        private void EditBadge()
        {
            Console.WriteLine("Please Enter Your Badge ID:");
            int badgeID = Convert.ToInt32(Console.ReadLine());
            var badge = _badgeRepository.GetBadgeDictionary();

            string door = " ";
            foreach (var otherDoor in badge[badgeID])
            {
                door = door + door + " ";
            }

            Console.WriteLine($"Badge {badgeID} has access to doors {door} now.");

            var response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    Console.WriteLine("Choose a door to remove.");
                    string removeDoor = Console.ReadLine();
                    badge[badgeID].Remove(removeDoor);
                    Console.WriteLine("Door removed.");
                    break;
                case "2":
                    Console.WriteLine("Choose a door to add.");
                    string addDoor = Console.ReadLine();
                    badge[badgeID].Add(addDoor);
                    Console.WriteLine($"{badgeID} has access to door {addDoor}");
                    break;
                default:
                    Console.WriteLine("Please try again.");
                    break;
            }

            private void SeedMenuList()
            {
                var badgeOne = new Badge(1, new List<string>() { "B7" });
                var badgeTwo = new Badge(2, new List<string>() { "A9" });
                var badgeSeven = new Badge(7, new List<string>() { "C7" });
            }
        }
    }
}

