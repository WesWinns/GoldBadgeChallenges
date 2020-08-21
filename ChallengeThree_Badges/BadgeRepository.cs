using ChallengeThree_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        // Create
        public void CreateBadge(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.ListOfDoors);
        }

        // Read
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }

        // Update
        public bool UpdateBadge(int badgeId, List<string> updatedListOfDoors)
        {
            if (_badgeDictionary.ContainsKey(badgeId))
            {
                _badgeDictionary[badgeId] = updatedListOfDoors;
                return true;
            }

            return false;
        }

        // Delete
        public bool DeleteBadge(int badgeID)
        {
            return _badgeDictionary.Remove(badgeID);
        }
    }
}
