using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Claims
{
    class ClaimsRepository
    {
        private Queue<ClaimContent> _listOfClaims = new Queue<ClaimContent>();  //Switched to Queue instead of List due to difficulty making the UI work.

        //Create
        public void AddClaimToList(ClaimContent claim)
        {
            _listOfClaims.Enqueue(claim);
        }

        //Read
        public Queue<ClaimContent> GetClaimList()
        {
            return _listOfClaims;
        }

        //Update
        public bool UpdateClaim(int originalID, ClaimContent newClaim)
        {
            // Find the claim
            ClaimContent oldClaim = GetClaimByClaimID(originalID);

            // Update the claim
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                                                                                //Deleted the bool from if statement
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Delete                       ----------------Having a difficult time trying to delete.
        public bool RemoveClaimFromList(int claimID)
        {
            ClaimContent claim = GetClaimByClaimID(claimID);

            if(claim == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;

            if(initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method for Delete ----------- Not sure if it's needed for Delete?
        public ClaimContent GetClaimByClaimID(int claimID)
        {
            foreach(ClaimContent claim in _listOfClaims)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        
        }
    }
}
