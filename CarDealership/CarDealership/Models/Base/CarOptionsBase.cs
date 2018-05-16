namespace CarDealership.Models.Base
{
    /// <summary>
    /// Class for car options base
    /// </summary>
    public abstract class CarOptionsBase
    {
        public string Color { get; set; }
        public bool IsAutomatic { get; set; }
        public bool HasSunRoof { get; set; }
        public bool IsFourWheelDrive { get; set; }
        public bool HasLowMiles { get; set; }
        public bool HasPowerWindows { get; set; }
        public bool HasNavigation { get; set; }
        public bool HasHeatedSeats { get; set; }
    }
}