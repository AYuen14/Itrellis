namespace CarDealership.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using log4net;

    using CarDealership.Models;
    using CarDealership.Models.ViewModel;
    using CarDealership.Services.Interface;

    /// <summary>
    /// Controller class for home
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILog _logger;

        /// <summary>
        /// The car dealership service
        /// </summary>
        private readonly ICarDealershipService _carDealershipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="carDealershipService">The car dealership service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// logger
        /// or
        /// carDealershipService
        /// </exception>
        public HomeController(ILog logger, ICarDealershipService carDealershipService)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (carDealershipService == null)
            {
                throw new ArgumentNullException(nameof(carDealershipService));
            }

            this._logger = logger;
            this._carDealershipService = carDealershipService;
        }

        /// <summary>
        /// Initial run to return all car options.
        /// </summary>
        /// <param name="carOptions">The car options.</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(Car carOptions)
        {
            CarViewModel carViewModel = null;

            try
            {
                carViewModel = Task.Run(() => this._carDealershipService.GetCarInformationAsync(carOptions)).Result;
            }
            catch (Exception ex)
            {
                this._logger.Fatal($"Failed in Home Index \n Exception : {ex}");
                throw;
            }

            return this.View(carViewModel);
        }

        /// <summary>
        /// Posts the data to return filter selected data.
        /// </summary>
        /// <param name="carOptions">The car options.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostData(Car carOptions)
        {
            CarViewModel carViewModel = null;

            try
            {
                carViewModel = Task.Run(() => this._carDealershipService.GetCarInformationAsync(carOptions)).Result;
            }
            catch (Exception ex)
            {
                this._logger.Fatal($"Failed in Home Index \n Exception : {ex}");
                throw;
            }

            return PartialView("_partialTable", carViewModel);
        }
    }
}