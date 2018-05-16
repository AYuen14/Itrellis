namespace CarDealership.Repository.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarDealership.Models;
    using CarDealership.Models.ViewModel;

    /// <summary>
    /// Interface for the car dealership repository
    /// </summary>
    public interface ICarDealershipRepository
    {
        /// <summary>
        /// Gets the car information asynchronous.
        /// </summary>
        /// <param name="CarOptions">The car options.</param>
        /// <returns>List of cars</returns>
        Task<CarViewModel> GetCarInformationAsync(Car carOptions);
    }
}
