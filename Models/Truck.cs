using System;

namespace VehicleRentalSystem.Models
{
    // Truck inherits from Vehicle
    public class Truck : Vehicle
    {
        public double TowingCapacity { get; set; }

        public Truck(string vehicleId, string make, string model, int year, double rate, double towingCapacity)
            : base(vehicleId, make, model, year, rate)
        {
            this.TowingCapacity = towingCapacity;
        }

        public override void DisplayVehicleDetails()
        {
            string status = IsRented ? "Rented" : "Available";
            Console.WriteLine($"[Truck] ID: {VehicleId,-5} | {Year} {Make} {Model} | Towing: {TowingCapacity} tons | Rate: ₱{DailyRentalRate:F2}/day | Status: {status}");
        }
    }
}