﻿using System;
using System.Collections.Generic;

namespace CarRentalLibrary.Models
{
    public partial class Carrental
    {
        public Carrental()
        {
            Cars = new HashSet<Car>();
        }

        public string Carrentalid { get; set; } = null!;
        public string? Carrentalcompanyname { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
