namespace CarDealership.App_Start.Utility
{
    using System;

    using CarDealership.App_Start.Utility.Interface;

    /// <summary>
    /// Defines the connection string factory.
    /// </summary>
    /// <seealso cref="CarDealership.App_Start.Utility.Interface.IConnectionStringFactory" />
    public class ConnectionStringFactory : IConnectionStringFactory
    {
        /// <summary>
        /// The application configuration
        /// </summary>
        private readonly IAppConfig _appConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionStringFactory"/> class.
        /// </summary>
        /// <param name="appConfig">The application configuration.</param>
        /// <exception cref="System.ArgumentNullException">appConfig</exception>
        public ConnectionStringFactory(IAppConfig appConfig)
        {
            if (appConfig == null)
            {
                throw new ArgumentNullException(nameof(appConfig));
            }

            this._appConfig = appConfig;
        }

        /// <summary>
        /// Gets the live connection string.
        /// </summary>
        /// <returns>
        /// Returns SQL connecting string for live site.
        /// </returns>
        /// <exception cref="System.Exception">Connection string 'live' was empty or not found in the web.config file.</exception>
        public string GetLiveConnectionString()
        {
            var connectionString = _appConfig.GetConnectionString("live");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string 'live' was empty or not found in the web.config file.");
            }

            return connectionString;
        }
    }
}