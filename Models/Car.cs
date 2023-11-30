using System;
using System.Collections.Generic;

namespace CarRentalLibrary.Models
{
    public partial class Car
    {
        public Car()
        {
            Bookings = new HashSet<Booking>();
        }

        public string Carid { get; set; } = null!;
        public string? Carrentalid { get; set; }
        public string? Carmodel { get; set; }
        public decimal? Insuranceamount { get; set; }
        public string? Fueltype { get; set; }
        public string? Mileage { get; set; }
        public int? Noofdoors { get; set; }
        public decimal? Rentalpriceperday { get; set; }
        public string? Luggagespace { get; set; }
        public string? Geartype { get; set; }
        public bool? Freecancelation { get; set; }
        public string? Caravailability { get; set; }

        public virtual Carrental? Carrental { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
