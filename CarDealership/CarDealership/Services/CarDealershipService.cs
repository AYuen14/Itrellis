namespace CarDealership.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using log4net;

    using CarDealership.Models;
    using CarDealership.Models.ViewModel;
    using CarDealership.Repository.Interface;
    using CarDealership.Services.Interface;

    /// <summary>
    /// Class for car dealership service
    /// </summary>
    /// <seealso cref="CarDealership.Services.Interface.ICarDealershipService" />
    public class CarDealershipService : ICarDealershipService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILog _logger;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICarDealershipRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarDealershipService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="navigationRepository">The navigation repository.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// navigationRepository
        /// </exception>
        public CarDealershipService(ILog logger, ICarDealershipRepository navigationRepository)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (navigationRepository == null)
            {
                throw new ArgumentNullException(nameof(navigationRepository));
            }

            this._logger = logger;
            this._repository = navigationRepository;
        }

        /// <summary>
        /// Gets the car information asynchronous.
        /// </summary>
        /// <param name="carOptions"></param>
        /// <returns>
        /// List of cars
        /// </returns>
        /// <exception cref="System.ArgumentException">address must not be null. - carOptions</exception>
        public async Task<CarViewModel> GetCarInformationAsync(Car carOptions)
        {
            if (carOptions == null)
            {
                throw new ArgumentException("carOptions must not be null.", nameof(carOptions));
            }

            return await this._repository.GetCarInformationAsync(carOptions);
        }
    }
}