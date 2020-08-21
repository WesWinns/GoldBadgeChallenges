using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeOne_Cafe;
using System.Collections.Generic;

namespace CafeTests
{
    [TestClass]
    public class CafeRepositoryTest
    {
        private MenuRepository _menuRepository;
        private MenuItems _menu;


        [TestInitialize]
        public void Arrange()
        {
            _menuRepository = new MenuRepository();
            _menu = new MenuItems(1, "Burger", "Big ol' Burger", "Mostly Burger, topped with slices of burger.", 8.99m);

            _menuRepository.AddMenuItems(_menu);
        }

        [TestMethod]
        public void CreateMenuItem()
        {
            MenuRepository menuRepository = new MenuRepository();
            MenuItems content = new MenuItems(7, "Coffee", "Big Tank of Coffee", "Caffeine", 2.99m);

            menuRepository.AddMenuItems(content);

            Assert.AreEqual(content.Name, "Coffee");
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrect()
        {
            List<MenuItems> directory = _menuRepository.GetMenuItems();

            bool directoryHasMenu = directory.Contains(_menu);

            Assert.IsTrue(directoryHasMenu);
        }

        [TestMethod]
        public void GetItemByName_ShouldReturnCorrectItem()
        {
            MenuItems correctObject = _menuRepository.GetMenuItemsByName("Burger");

            Assert.AreEqual(correctObject.Price, 8.99m);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            Arrange();

            bool deleteResult = _menuRepository.DeleteMenuItems("Burger");
        }
    }
}
