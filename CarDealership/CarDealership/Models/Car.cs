namespace CarDealership.Models
{
    using Base;

    /// <summary>
    /// Car options
    /// </summary>
    public class Car: CarOptionsBase
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
    }
}