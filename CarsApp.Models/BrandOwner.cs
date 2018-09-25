using System;
using System.Collections.Generic;
using System.Text;

namespace CarsApp.Models
{
    /// <summary>
    /// A car brand has zero or more car owners
    /// </summary>
    public class BrandOwner
    {
        public string Brand { get; set; }
        public IEnumerable<string> Owners { get; set; }
    }
}
