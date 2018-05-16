namespace CarDealership.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    using Dapper;
    using log4net;

    using CarDealership.Models;
    using CarDealership.Models.ViewModel;
    using CarDealership.App_Start.Utility.Interface;
    using CarDealership.Repository.Interface;
    using Models.Constants;
    using System.Linq;

    /// <summary>
    /// Car dealership repository
    /// </summary>
    /// <seealso cref="CarDealership.Repository.Interface.ICarDealershipRepository" />
    public class CarDealershipRepository: ICarDealershipRepository
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILog _logger;

        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarDealershipRepository"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="connectionStringFactory">The connection string factory.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// connectionStringFactory
        /// </exception>
        public CarDealershipRepository(ILog logger, IConnectionStringFactory connectionStringFactory)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (connectionStringFactory == null)
            {
                throw new ArgumentNullException(nameof(connectionStringFactory));
            }

            this._logger = logger;
            this._connectionString = connectionStringFactory.GetLiveConnectionString();
        }

        /// <summary>
        /// Gets the car information asynchronous.
        /// </summary>
        /// <param name="carOptions"></param>
        /// <returns>
        /// List of cars
        /// </returns>
        public async Task<CarViewModel> GetCarInformationAsync(Car carOptions)
        {
            CarViewModel carList = new CarViewModel();

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Color", carOptions.Color);
                    parameters.Add("@IsAutomatic", carOptions.IsAutomatic);
                    parameters.Add("@HasSunroof", carOptions.HasSunRoof);
                    parameters.Add("@IsFourWheelDrive", carOptions.IsFourWheelDrive);
                    parameters.Add("@HasLowMiles", carOptions.HasLowMiles);
                    parameters.Add("@HasPowerWindows", carOptions.HasPowerWindows);
                    parameters.Add("@HasNavigation", carOptions.HasNavigation);
                    parameters.Add("@HasHeatedSeats", carOptions.HasHeatedSeats);


                    var result = await connection.QueryAsync<Car>
                        (StoredProcedureNames.GetCarInformation,
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    carList.data = result.ToList();
                }
            }
            catch(Exception ex)
            {
                this._logger.Fatal("Exception thrown while in GetCarInformationAsync", ex);
                throw;
            }

            return carList;
        }
    }
}