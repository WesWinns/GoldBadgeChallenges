using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Badges
{
    public class Badge_Repository
    {
        public Dictionary<int, List<string>> _badgeList = new Dictionary<int, List<string>>();

        // Create badge
        public void CreateBadge(int badgeID)
        {
            List<string> listOfDoors = new List<string>();
            Badge newBadge = new Badge(badgeID, listOfDoors);

            _badgeList.Add(newBadge.BadgeID, newBadge.ListOfDoors);
        }

        public void AddDoorToBadge(int badgeID, string door)
        {
            _badgeList[badgeID].Add(door);
        }


        // Read all badges
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeList;
        }

        // Delete single door
        public void DeleteBadgeDoor(int badgeID, string door)
        {
            _badgeList[badgeID].Remove(door);
        }

        // Delete all doors from badge
        public void DeleteAllDoorsFromBadge(int badgeID)
        {
            _badgeList[badgeID].Clear();
        }

        public bool HasKey(int key)
        {
            bool validKey = _badgeList.ContainsKey(key);
            if (validKey)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper       --------------------- Not sure if need a helper????
        public Badge GetBadgeByID(int badgeID)
        {
            foreach (var badge in _badgeList)
            {
                if (badge.Key == badgeID)
                {
                    //instantiate a new badge
                    Badge newBadge = new Badge(badge.Key, badge.Value);

                    //assign the Key for this kvp to the badge's ID
                    //assign the Value of this kvp to the badges List of strings
                    return newBadge;
                }
            }
            return null;
        }
    }
}
