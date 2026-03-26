using System;

namespace VehicleRentalSystem.Models
{
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle(string vehicleId, string make, string model, int year, double rate, bool hasSidecar)
            : base(vehicleId, make, model, year, rate)
        {
            this.HasSidecar = hasSidecar;
        }

        public override void DisplayVehicleDetails()
        {
            string status = IsRented ? "Rented" : "Available";
            string sidecar = HasSidecar ? "Yes" : "No";
            Console.WriteLine($"[Motorcycle] ID: {VehicleId,-5} | {Year} {Make} {Model} | Sidecar: {sidecar} | Rate: ₱{DailyRentalRate:F2}/day | Status: {status}");
        }
    }
}