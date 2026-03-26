using System;

namespace VehicleRentalSystem.Models
{
    // PURPOSE: Represents a specific 'Car' entity.
    // OOP PRINCIPLE: Inheritance (inherits from Vehicle).
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string vehicleId, string make, string model, int year, double rate, int doors)
            : base(vehicleId, make, model, year, rate)
        {
            this.NumberOfDoors = doors;
        }

        public override void DisplayVehicleDetails()
        {
            string status = IsRented ? "Rented" : "Available";
            Console.WriteLine($"[Car] ID: {VehicleId,-5} | {Year} {Make} {Model} | Doors: {NumberOfDoors} | Rate: ₱{DailyRentalRate:F2}/day | Status: {status}");
        }

        public override double CalculateRentalCost(int daysRented)
        {
            double baseCost = base.CalculateRentalCost(daysRented);
            return DailyRentalRate > 100 ? baseCost * 1.15 : baseCost;
        }
    }
}