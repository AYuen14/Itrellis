namespace CarDealership.Models.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for car view model
    /// </summary>
    /// <seealso cref="CarDealership.Models.Base.CarOptionsBase" />
    public class CarViewModel
    {
        public IEnumerable<Car> carItems { get; set; }
    }
}