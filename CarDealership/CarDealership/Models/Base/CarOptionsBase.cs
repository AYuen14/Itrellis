namespace CarDealership.Models.Base
{
    /// <summary>
    /// Class for car options base
    /// </summary>
    public abstract class CarOptionsBase
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is automatic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is automatic; otherwise, <c>false</c>.
        /// </value>
        public bool IsAutomatic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has sun roof.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has sun roof; otherwise, <c>false</c>.
        /// </value>
        public bool HasSunRoof { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is four wheel drive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is four wheel drive; otherwise, <c>false</c>.
        /// </value>
        public bool IsFourWheelDrive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has low miles.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has low miles; otherwise, <c>false</c>.
        /// </value>
        public bool HasLowMiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has power windows.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has power windows; otherwise, <c>false</c>.
        /// </value>
        public bool HasPowerWindows { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has navigation.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has navigation; otherwise, <c>false</c>.
        /// </value>
        public bool HasNavigation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has heated seats.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has heated seats; otherwise, <c>false</c>.
        /// </value>
        public bool HasHeatedSeats { get; set; }
    }
}