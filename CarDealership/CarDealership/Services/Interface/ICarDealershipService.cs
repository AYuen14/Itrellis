namespace CarDealership.Services.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealership.Models;
    using CarDealership.Models.ViewModel;

    /// <summary>
    /// Interface for the car dealership service
    /// </summary>
    public interface ICarDealershipService
    {
        /// <summary>
        /// Gets the car information asynchronous.
        /// </summary>
        /// <param name="CarOptions">The car options.</param>
        /// <returns>List of cars</returns>
        Task<CarViewModel> GetCarInformationAsync(Car carOptions);
    }
}
