using System;

namespace VehicleRentalSystem.Models
{
    // PURPOSE: Acts as the "Parent" or "Template" for all vehicle types.
    public abstract class Vehicle
    {
        // OOP PRINCIPLE: Encapsulation (Private fields protect the data).
        private string vehicleId;
        private string make;
        private double dailyRentalRate;
        private bool isRented;

        // PROPERTIES: Public accessors to the private fields.
        public string VehicleId { get => vehicleId; }
        public string Make { get => make; }
        public string Model { get; set; }
        public int Year { get; set; }

        // PURPOSE: Validates that the rental rate isn't set to a negative number.
        public double DailyRentalRate
        {
            get => dailyRentalRate;
            set => dailyRentalRate = value < 0 ? 10.0 : value;
        }

        public bool IsRented { get => isRented; }

        // CONSTRUCTOR: Sets up the initial data for any vehicle created.
        protected Vehicle(string vehicleId, string make, string model, int year, double rate)
        {
            this.vehicleId = vehicleId;
            this.make = make;
            this.Model = model;
            this.Year = year;
            this.DailyRentalRate = rate;
            this.isRented = false;
        }
        // PURPOSE: A "contract" method that subclasses MUST implement.
        public abstract void DisplayVehicleDetails();

        // PURPOSE: Calculates basic cost. Subclasses can change this logic.
        // OOP PRINCIPLE: Polymorphism (Virtual method).
        public virtual double CalculateRentalCost(int daysRented) => DailyRentalRate * daysRented;

        // PURPOSE: Updates the vehicle state to 'Rented'.
        public virtual void Rent() => isRented = true;

        // PURPOSE: Updates the vehicle state to 'Available'.
        public virtual void Return() => isRented = false;
    }
}