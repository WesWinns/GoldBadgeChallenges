using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Cafe
{
    class ProgramUI
    {
        
        private MenuRepository _menuRepo = new MenuRepository();

        // Method that runs/starts the application
        public void Run()
        {
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Menu Items\n" +
                    "2. View All Menu Items\n" +
                    "3. Delete Current Menu Items\n" +
                    "4. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        AddNewMenuItems();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DeleteExistingMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Have a wonderful day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please try again with a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Add New Menu Items
        private void AddNewMenuItems()
        {
            Console.Clear();
            MenuItems newMenuItems = new MenuItems();
            
            // Number
            Console.WriteLine("What number would you call this meal?");
            newMenuItems.Number = int.Parse(Console.ReadLine());

            // Name
            Console.WriteLine("\nWhat name will this meal be called?");
            newMenuItems.Name = Console.ReadLine();

            // Description
            Console.WriteLine("\nDescribe this meal.");
            newMenuItems.Description = Console.ReadLine();
            
            // Ingredients
            Console.WriteLine("\nWhat are all the ingredients for this meal?");
            newMenuItems.Ingredients = Console.ReadLine();

            // Price
            Console.WriteLine("\nHow much does this meal cost?");
            newMenuItems.Price = decimal.Parse(Console.ReadLine());

            _menuRepo.AddMenuItems(newMenuItems);
        
        }

        // View All Menu Items
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItems> listOfMenuItems = _menuRepo.GetMenuItems();
            
            foreach(MenuItems item in listOfMenuItems)
            {
                Console.WriteLine($"Number: {item.Number}\n" +
                    $"Name: {item.Name}\n" +
                    $"Description: = {item.Description}\n" +
                    $"Ingredients: = {item.Ingredients}\n" +
                    $"Price: {item.Price}\n");
            }

        }

        // Update Menu Items
        private void UpdateMenuItems()
        {

            DisplayAllMenuItems();

            Console.WriteLine("\nEnter the number of the meal you'd like to update:");

            string oldItem = Console.ReadLine();

            MenuItems newMenuItem = new MenuItems();

            Console.WriteLine("Enter the number of the menu item:");
            newMenuItem.Number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the name of the menu item:");
            newMenuItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the description of the menu item:");
            newMenuItem.Description = Console.ReadLine();

            Console.WriteLine("Enter the Ingredients of the menu item:");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the Price of the menu item:");
            string priceAsString = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(priceAsString);

            bool wasUpdated = _menuRepo.UpdateMenuItems(oldItem, newMenuItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu was successfully updated!");
            }
            else
            {
                Console.WriteLine("Menu was not updated.");
            }
        }

        //Delete Existing Menu Items
        private void DeleteExistingMenuItems()
        {

            DisplayAllMenuItems();

            Console.WriteLine("Please Select the menu item you wish to delete:");
            
            string userInput = Console.ReadLine();

            bool wasDeleted = _menuRepo.DeleteMenuItems(userInput);

            if (wasDeleted)
            {
                Console.WriteLine("The menu item was deleted.");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted.");
            }
        }
        private void SeedContentList()
        {
            MenuItems burger = new MenuItems(1, "Burger", "Big ol' Burger", "Mostly Burger, topped with slices of burger.", 8.99m);
            MenuItems coffee = new MenuItems(7, "Coffee", "Big Tank of Coffee", "Caffeine", 2.99m);
            MenuItems chickenSam = new MenuItems(9, "Chicken Sam", "Chicken Sandwich", "A real life chicken with sand and a wich.", 7.99m);

            _menuRepo.AddMenuItems(burger);
            _menuRepo.AddMenuItems(coffee);
            _menuRepo.AddMenuItems(chickenSam);

        }
    }
}
