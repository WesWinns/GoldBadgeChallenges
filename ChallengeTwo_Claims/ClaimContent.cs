using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Claims
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    
    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }  // Would it be better to rename ClaimType?
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }  //???  Not sure if DateTime is correct
        public DateTime DateOfClaim { get; set; }  //???  Not sure if DateTime is correct
        public bool IsValid
        {
            get
            {
                int days = ((TimeSpan)(DateOfClaim - DateOfIncident)).Days;
                Console.WriteLine(days);
                if (days <= 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public ClaimContent(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }
    }
}