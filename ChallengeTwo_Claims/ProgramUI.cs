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
            ClaimList();
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
                        TakeCareOfNextClaim();
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


        /*private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<Claim> claimQueue = _claimsRepository.GetClaimByClaimID();
            bool nextClaimBool = true;
            while (nextClaimBool)
            {
                if (claimQueue.Count > 0)
                {
                    var next = claimQueue.Peek();
                    DisplayClaim(next);
                }
                Console.WriteLine("Do you want to deal with this claim now (y/n):");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    claimQueue.Dequeue();
                }
                else if (userInput == "n")
                {
                    nextClaimBool = false;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }
        }*/



        public void CreateNewClaim()
        {
            Console.Clear();

            Console.WriteLine("Enter the Claim ID number: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Claim Type: ");
            ClaimType claimType = ClaimType();

            Console.WriteLine("Enter a description of the accident:");
            string Description = Console.ReadLine();

            Console.WriteLine("Enter the amount of Damage:");
            double ClaimAmount = double.Parse(Console.ReadLine();

            Console.WriteLine("Enter the Date of the incident:");
            DateTime DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Date of the Claim:");
            DateTime DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this claim valid?");
            string IsValid = Console.ReadLine();
        }

            //if(IsValid == true)
            //{
            //   IsValid = true;
            //}
            //else
            //{
            //    IsValid = false;
            //}

            //Claim newClaim = new Claim(id, claimType, Description, ClaimAmount, DateOfIncident, DateOfClaim);
            //_claimsRepository.AddClaimToList(newClaim);

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

            Claim newClaim = new Claim(id, claimType, description, claimAmount, dateOfIncident, dateOfClaim);


            bool wasUpdated = _claimsRepository.UpdateClaim(oldclaim, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Claim updated!");
            }
            else
            {
                Console.WriteLine("Could not update claim.");
            }

        }


        private void DeleteExistingClaim()
        {

        }

        private void ClaimList()
        {
            Claim claim1 = new Claim(1, ClaimTypes.Car, "Car accident on 464", 400d, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27));
            Claim claim2 = new Claim(2, ClaimTypes.Home, "House fire in kitchen", 4000d, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            Claim claim3 = new Claim(3, ClaimTypes.Theft, "Stolen pancakes", 4d, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));

            _claimsRepository.AddClaimToList(claim1);
            _claimsRepository.AddClaimToList(claim2);
            _claimsRepository.AddClaimToList(claim3);
            
        }
    }
}
