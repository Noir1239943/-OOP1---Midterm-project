using System;
using VehicleRentalSystem.Models; // Note the reference to the Models namespace

namespace VehicleRentalSystem.Services
{   
    // PURPOSE: Manages the collection of vehicles and handles business logic.
    public class RentalStore
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        // METHOD: Adds a new vehicle object to the store's inventory.
        public void AddVehicle(Vehicle v) => vehicles.Add(v);

        // METHOD: Displays every vehicle in the fleet.
        public void DisplayAllVehicles()
        {

            Console.WriteLine("\n--- Available Vehicles ---");
            foreach (var v in vehicles) v.DisplayVehicleDetails();
        }

        // METHOD: Handles the logic of selecting a vehicle and calculating price.
        public void ProcessRental()
        {
            DisplayAllVehicles();
            Console.Write("\nEnter Vehicle ID to rent: ");
            string id = Console.ReadLine();
            Vehicle v = vehicles.Find(veh => veh.VehicleId == id);

            if (v == null || v.IsRented)
            {
                Console.WriteLine("Vehicle unavailable or not found.");
                return;
            }

            Console.Write("Rental days: ");
            if (int.TryParse(Console.ReadLine(), out int days) && days > 0)
            {
                Console.WriteLine($"Total calculated cost: ₱{v.CalculateRentalCost(days):F2}");
                v.Rent();
            }
        }

        public void ReturnVehicle()
        {
            Console.Write("\nEnter Vehicle ID to return: ");
            string id = Console.ReadLine();

            // Find the vehicle in the list
            Vehicle v = vehicles.Find(veh => veh.VehicleId == id);

            if (v == null)
            {
                Console.WriteLine("Error: Vehicle ID not found.");
                return;
            }

            if (!v.IsRented)
            {
                Console.WriteLine("Error: This vehicle is not currently rented.");
                return;
            }

            // Call the Return method defined in the Vehicle base class
            v.Return();
            Console.WriteLine($"The '{v.VehicleId} {v.Make} {v.Model} {v.Year}' has been successfully returned.");
        }
    }
}
