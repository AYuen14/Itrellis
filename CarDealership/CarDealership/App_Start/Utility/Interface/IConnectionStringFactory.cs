namespace CarDealership.App_Start.Utility.Interface
{
    /// <summary>
    /// Interface IConnectionStringFactory
    /// </summary>
    interface IConnectionStringFactory
    {
        /// <summary>
        /// Gets the live connection string.
        /// </summary>
        /// <returns>Returns SQL connecting string for live site.</returns>
        string GetLiveConnectionString();
    }
}
