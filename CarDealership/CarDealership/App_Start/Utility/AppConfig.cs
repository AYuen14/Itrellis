namespace CarDealership.App_Start.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;

    using Interface;

    /// <summary>
    /// Defines the App config.
    /// </summary>
    /// <seealso cref="CarDealership.App_Start.Utility.Interface.IAppConfig" />
    public class AppConfig : IAppConfig
    {
        /// <summary>
        /// Cache config settings, case-insensitive
        /// </summary>
        private readonly Dictionary<string, string> _settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Cache connection string settings, case-insensitive
        /// </summary>
        private readonly Dictionary<string, string> _connectionString = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Attempts to get a string containing the value for the requested setting name.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="result">The output variable to populate with the string found in matching setting, when found.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">settingName</exception>
        /// <exception cref="System.ArgumentException">setting name should not exist in both secureSettings and appSettings section</exception>
        private bool TryGetSetting(string settingName, out string result)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new ArgumentNullException(nameof(settingName));
            }

            string setting;
            bool settingFound = false;

            lock (this._settings)
            {
                if (this._settings.TryGetValue(settingName, out setting))
                {
                    settingFound = true;
                }
                else
                {
                    //Setting not found in local cache, check App.Config file instead.
                    var secureSettings = (NameValueCollection)ConfigurationManager.GetSection("secureSettings");
                    var appSettings = ConfigurationManager.AppSettings;

                    if (secureSettings?[settingName] != null)
                    {
                        if (appSettings?[settingName] != null)
                        {
                            throw new ArgumentException("setting name should not exist in both secureSettings and appSettings section");
                        }

                        setting = secureSettings[settingName];
                        settingFound = true;
                        this._settings.Add(settingName, setting);
                    }
                    else if (appSettings[settingName] != null)
                    {
                        setting = appSettings[settingName];
                        settingFound = true;
                        this._settings.Add(settingName, setting);
                    }
                }
            }

            result = setting;

            return settingFound;
        }

        /// <summary>
        /// Attempts to get a connection string for the requested environment, where success of the attempt is returned.
        /// </summary>
        /// <param name="connectionStringName">The case-insensitive name of the connection string for which the connection string is to be retrieved.</param>
        /// <param name="result">An output string parameter containing the connection string if the call is successful.</param>
        /// <returns>Returns true if the requested connection string is found, else if returns false.</returns>
        private bool TryGetConnectionString(string connectionStringName, out string result)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }

            string connectionString;
            bool connectionStringFound = false;

            lock (this._connectionString)
            {
                if (this._connectionString.TryGetValue(connectionStringName, out connectionString))
                {
                    connectionStringFound = true;
                }
                else
                {
                    if (ConfigurationManager.ConnectionStrings != null && ConfigurationManager.ConnectionStrings[connectionStringName] != null)
                    {
                        connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                        connectionStringFound = true;
                        this._connectionString.Add(connectionStringName, connectionString);
                    }
                }
            }

            result = connectionString;
            return connectionStringFound;
        }

        /// <summary>
        /// Gets a string containing the value matching the setting name argument.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="defaultValue">The default value  if not found.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">settingName</exception>
        public string GetSetting(string settingName, string defaultValue = null)
        {
            if (string.IsNullOrEmpty(settingName))
            {
                throw new ArgumentNullException(nameof(settingName));
            }

            string setting;

            bool settingFound = this.TryGetSetting(settingName, out setting);

            if (!settingFound && defaultValue != null)
            {
                setting = defaultValue;
            }

            return setting;
        }

        /// <summary>
        /// Gets the connection string for the connection string name.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetConnectionString(string connectionStringName)
        {
            string connectionString;

            var environmentFound = this.TryGetConnectionString(connectionStringName, out connectionString);

            if (!environmentFound)
            {
                throw new ArgumentException(nameof(connectionStringName));
            }

            return connectionString;
        }
    }
}