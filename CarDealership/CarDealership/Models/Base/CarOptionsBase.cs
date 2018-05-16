namespace CarDealership.Models.Base
{
    using CarDealership.Models.Constants;

    /// <summary>
    /// Class for car options base
    /// </summary>
    public abstract class CarOptionsBase
    {
        public ColorOptions Color { get; set; }
        public bool IsAutomatic { get; set; }
        public bool IsSunRoof { get; set; }
        public bool IsFourWheelDrive { get; set; }
        public bool IsLowMiles { get; set; }
        public bool IsPowerWindows { get; set; }
        public bool IsNavigation { get; set; }
        public bool IsHeatedSeats { get; set; }
    }
}