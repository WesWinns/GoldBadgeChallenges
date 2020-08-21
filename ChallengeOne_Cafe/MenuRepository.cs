using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Cafe
{
    public class MenuRepository
    {
        private List<MenuItems> _listOfMenuItems = new List<MenuItems>();

        //Create
        public void AddMenuItems(MenuItems meal)
        {
            _listOfMenuItems.Add(meal);
        }

        //Update
        public bool UpdateMenuItems(string originalName, MenuItems newMenu)
        {
            // Find Menu Item
            MenuItems oldMenu = GetMenuItemsByName(originalName);

            // Update Menu Item
            if (oldMenu != null)
            {
                oldMenu.Number = newMenu.Number;
                oldMenu.Name = newMenu.Name;
                oldMenu.Description = newMenu.Description;
                oldMenu.Ingredients = newMenu.Ingredients;
                oldMenu.Price = newMenu.Price;

                return true;
            }
            else
            {
                return false;
            }

        }

        //Read
        public List<MenuItems> GetMenuItems()
        {
            return _listOfMenuItems;
        }

        //Delete
        public bool DeleteMenuItems(string name)
        {
            MenuItems meal = GetMenuItemsByName(name);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(meal);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method ------ Not sure if needed all the time...
        public MenuItems GetMenuItemsByName(string name)
        {
            foreach (MenuItems items in _listOfMenuItems)                //Look into doing either name and/or number?
            {
                if (items.Name == name)
                {
                    return items;
                }
            }
            return null;
        }
    }
}
