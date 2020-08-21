using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Badges
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors = new List<string>();

        public Badge() { }
        public Badge(int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }
    }
}
