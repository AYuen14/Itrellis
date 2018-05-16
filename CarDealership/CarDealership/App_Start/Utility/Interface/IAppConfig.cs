namespace CarDealership.App_Start.Utility.Interface
{
    /// <summary>
    /// IAppConfig defines the interface for reading settings from App.Config
    /// </summary>
    public interface IAppConfig
    {
        /// <summary>
        /// Gets a string containing the value matching the setting name argument.
        /// </summary>
        /// <param name="settingName">Name of the setting to retrieve.</param>
        /// <param name="defaultValue">The default value  if not found.</param>
        /// <returns></returns>
        string GetSetting(string settingName, string defaultValue = null);

        /// <summary>
        /// Gets the connection string for the connection string name.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns></returns>
        string GetConnectionString(string connectionStringName);
    }
}
