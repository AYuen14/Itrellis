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
            CarViewModel carList = null;

            try
            {
                using (var connection = new SqlConnection(this._connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Color", carOptions.Color);
                    parameters.Add("@IsAutomatic", carOptions.IsAutomatic);
                    parameters.Add("@IsSunRoof", carOptions.IsSunRoof);
                    parameters.Add("@IsFourWheelDrive", carOptions.IsFourWheelDrive);
                    parameters.Add("@IsLowMiles", carOptions.IsLowMiles);
                    parameters.Add("@IsPowerWindows", carOptions.IsPowerWindows);
                    parameters.Add("@IsNavigation", carOptions.IsNavigation);
                    parameters.Add("@IsHeatedSeats", carOptions.IsHeatedSeats);


                    var result = await connection.QueryAsync<Car>
                        (StoredProcedureNames.GetCarInformation,
                        parameters,
                        commandType: CommandType.StoredProcedure);

                    carList.carItems = result.ToList();
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