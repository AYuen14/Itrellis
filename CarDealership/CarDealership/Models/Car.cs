namespace CarDealership.Models
{
    using System.Text;

    using Base;

    /// <summary>
    /// Car options
    /// </summary>
    public class Car: CarOptionsBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the make.
        /// </summary>
        /// <value>
        /// The make.
        /// </value>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Prints the options to display.
        /// </summary>
        /// <returns></returns>
        public string PrintOptions()
        {
            StringBuilder sb = new StringBuilder();

            if(!string.IsNullOrWhiteSpace(this.Color))
                sb.Append(string.Format("Color: {0}", this.Color));

            if(this.HasSunRoof == true)
                sb.Append(", Sun roof");

            if(this.IsFourWheelDrive == true)
                sb.Append(", 4 Wheel Drive");

            if(this.HasLowMiles == true)
                sb.Append(", Low Miles");

            if(this.HasPowerWindows == true)
                sb.Append(", Power Windows");

            if(this.HasNavigation == true)
                sb.Append(", Navigation");

            if(this.HasHeatedSeats == true)
                sb.Append(", Heated Seats");

            return sb.ToString();

        }
    }
}