using System;
using VehicleRentalSystem.Models; // Reference to the Models namespace to access Vehicle, Car, and Motorcycle classes
using VehicleRentalSystem.Services;
using System.Globalization;

namespace VehicleRentalSystem
{
    class Program
    {
        // PURPOSE: The main execution loop and user interface.
        static void Main(string[] args)
        {
           // Initialize the store service.
            RentalStore store = new RentalStore();
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-PH"); // Set culture for Philippine Pesos

            // Add some sample vehicles to the inventory.
            store.AddVehicle(new Car("C101", "Toyota", "Camry", 2022, 1200, 4));// Standard car
            store.AddVehicle(new Car("C102", "Tesla", "Model S", 2023, 5000, 4)); // Luxury car rate!
            store.AddVehicle(new Motorcycle("M201", "Harley-Davidson", "Iron 883", 2021, 4500, false));// Motorcycle without sidecar
            store.AddVehicle(new Motorcycle("M202", "Tricycle", "Baja 125", 2022, 700, true)); // Motorcycle with sidecar
            store.AddVehicle(new Truck("T301", "Ford", "F-150", 2023, 3000, 5.5));// Truck with towing capacity

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("VEHICLE RENTAL SYSTEM MAIN MENU");
                Console.WriteLine("=================================");
                Console.WriteLine("1. View All Available Vehicles");
                Console.WriteLine("2. Rent a Vehicle");
                Console.WriteLine("3. Return a Vehicle"); 
                Console.WriteLine("4. Exit Application");
                Console.Write("Please select an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        store.DisplayAllVehicles();
                        break;
                    case "2":
                        store.ProcessRental();
                        break;
                    case "3":
                        store.ReturnVehicle(); 
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Vehicle Rental System. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select 1, 2, 3, or 4.");
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}