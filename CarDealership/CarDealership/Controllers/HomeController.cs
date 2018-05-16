using CarDealership.Models;
using CarDealership.Models.ViewModel;
using CarDealership.Services.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
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

        // GET: Home
        public async Task<ActionResult> Index(Car carOptions)
        {
            CarViewModel carViewModel = null;

            try
            {
                carViewModel = Task.Run(() => this._carDealershipService.GetCarInformationAsync(carOptions)).Result;
            }
            catch(Exception ex)
            {
                this._logger.Fatal($"Failed in Home Index \n Exception : {ex}");
                throw;
            }

            return this.View(carViewModel);
        }
    }
}