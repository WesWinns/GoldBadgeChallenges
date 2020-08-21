using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Claims
{
    public class ProgramUI
    {
        private bool _isRunning = true;

        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a claim:\n" +
                    "1. Create a New Claim\n" +
                    "2. View All Claims\n" +
                    "3. View All Claims By ID\n" +
                    "4. Update an Existing Claim\n" + 
                    "5. Exit");

                Console.WriteLine("Please enter a number: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        //TakeCareOfNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        UpdateExistingClaim();
                        break;
                    case "5":
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            Queue<ClaimContent> listofClaims = _claimsRepository.GetClaimList();

            foreach (ClaimContent claimContent in listofClaims)
            {
                Console.WriteLine($"ClaimID: {claimContent.ClaimID} {claimContent.ClaimType} {claimContent.Description} {claimContent.ClaimAmount} {claimContent.DateOfIncident.ToShortDateString()} {claimContent.DateOfClaim.ToShortDateString()} {claimContent.IsValid}\n");
            }

        }

        private void DisplayClaim(ClaimContent claimContent)
        {
            Console.WriteLine($"Claim ID: {claimContent.ClaimID}\n" +
                $"Type: {claimContent.ClaimType}.\n" +
                $"Description: {claimContent.Description}\n" +
                $"Amount: {claimContent.ClaimAmount}\n" +
                $"Date of Accident: {claimContent.DateOfIncident}\n" +
                $"Date of Claim: {claimContent.DateOfClaim}\n" +
                $"Is the claim valid: {claimContent.IsValid}\n");
        }

        public void CreateNewClaim()
        {
            Console.Clear();

            Console.WriteLine("Enter the Claim ID number: ");
            int id = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the Claim Type: ");
            //ClaimType claimType = ClaimType();

            Console.WriteLine("Enter a description of the accident:");
            string Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of Damage:");
            double ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Date of the incident:");
            DateTime DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Date of the Claim:");
            DateTime DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this claim valid?");
            string IsValid = Console.ReadLine();
        }


        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type:\n" +
                "1. Home\n" +
                "2. Car\n" +
                "3. Theft\n");

            while (true)
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        return ClaimType.Home;
                    case "2":
                        return ClaimType.Car;
                    case "3":
                        return ClaimType.Theft;
                                                            //Could not use breaks or default?
                }
            }
        }
        
        private void DisplayContentByID()
        {
            Console.Clear();

            Console.WriteLine("Please enter claim ID.");

            int claimID = int.Parse(Console.ReadLine());

            ClaimContent claimContent = _claimsRepository.GetClaimByClaimID(claimID);

            if(claimContent != null)
            {
                Console.WriteLine($"Claim ID: {claimContent.ClaimID}\n" +
                    $"Claim Type: {claimContent.ClaimType}\n" +
                    $"Description: {claimContent.Description}\n" +
                    $"Claim Amount: {claimContent.ClaimAmount}\n" +
                    $"Date of the Incident: {claimContent.DateOfIncident.ToShortDateString()}\n" +
                    $"Date of the Claim: {claimContent.DateOfClaim.ToShortDateString()}\n" +
                    $"Valid? {claimContent.IsValid}");
            }
            else
            {
                Console.WriteLine("No claims by that ID exist.");
            }
        }

        private void UpdateExistingClaim()
        {
            Console.Clear();
            DisplayAllClaims();

            Console.WriteLine("Enter the Claim ID to update: ");

            int oldclaim = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Claim ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Amount: ");
            double claimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("Date of Incident: ");
            string incidentInput = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentInput);
            
            Console.WriteLine("Date of Claim: ");
            string claimDateInput = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDateInput);

        }
    }
}
