using System;
using System.Collections.Generic;
using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class BadgeRepositoryTest
    {
        private BadgeRepository _badgeRepository;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badge = new BadgeRepository();
            var door = new List<string>() { "B3", "A8", "B2" };
            _badge = new Badge(1, door);
            _badgeRepository.GetBadgeDictionary(_badge);
        }

        [TestMethod]
        public void GetBadgeDictionary_ShouldReturn()
        {
            var badges = _badgeRepository.GetBadgeDictionary();

            Assert.IsTrue(badges.ContainsKey(1));
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            var updatedDoors = new List<string>() { "D3", "C4" };
            var isUpdated = _badgeRepository.UpdateBadge(1, updatedDoors);

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            Assert.IsTrue(_badgeRepository.DeleteBadge(1));
        }

    }
}
