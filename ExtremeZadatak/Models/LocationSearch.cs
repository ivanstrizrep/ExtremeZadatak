using System;
using System.Collections.Generic;

namespace ExtremeZadatak.Models
{
    public partial class LocationSearch
    {
        public int SearchId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Radius { get; set; }
        public string Category { get; set; }
        public DateTime? Time { get; set; }
    }
}
