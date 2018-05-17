namespace CarDealership.Models.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for car view model
    /// </summary>
    /// <seealso cref="CarDealership.Models.Base.CarOptionsBase" />
    public class CarViewModel
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public IEnumerable<Car> data { get; set; }
    }
}