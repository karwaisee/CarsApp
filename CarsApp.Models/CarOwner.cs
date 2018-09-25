using System.Collections.Generic;

namespace CarsApp.Models
{
    /// <summary>
    /// An owner has zero or more car
    /// </summary>
    public class CarOwner
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
