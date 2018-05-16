namespace CarDealership.Models
{
    using CarDealership.Models.Constants;

    /// <summary>
    /// Car options
    /// </summary>
    public class CarOptions
    {
        ColorOptions Color { get; set; }
        bool IsAutomatic { get; set; }
        bool IsSunRoof { get; set; }
        bool IsFourWheelDrive { get; set; }
        bool IsLowMiles { get; set; }
        bool IsPowerWindows { get; set; }
        bool IsNavigation { get; set; }
        bool IsHeatedSeats { get; set; }
    }
}