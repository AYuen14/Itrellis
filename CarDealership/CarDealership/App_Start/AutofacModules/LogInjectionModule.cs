namespace CarDealership.App_Start.AutofacModules
{
    using System.Linq;
    using System.Reflection;

    using Autofac;
    using Autofac.Core;
    using log4net;

    /// <summary>
    /// Used to register Log4Net instance
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class LogInjectionModule : Autofac.Module
    {
        /// <summary>
        /// Injects the logger properties.
        /// </summary>
        /// <param name="instance">The instance.</param>
        private static void InjectLoggerProperties(object instance)
        {
            var instanceType = instance.GetType();

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            var properties = instanceType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);

            //Set the properties located.
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, LogManager.GetLogger(instanceType), null);
            }
        }

        /// <summary>
        /// Called when [component preparing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PreparingEventArgs"/> instance containing the event data.</param>
        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter((p,i) => p.ParameterType == typeof(ILog), (p,i) => LogManager.GetLogger(p.Member.DeclaringType)),
                });
        }

        /// <summary>
        /// Override to attach module-specific functionality to a
        /// component registration.
        /// </summary>
        /// <param name="componentRegistry">The component registry.</param>
        /// <param name="registration">The registration to attach functionality to.</param>
        /// <remarks>
        /// This method will be called for all existing <i>and future</i> component
        /// registrations - ordering is not important.
        /// </remarks>
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            //Handle constructor parameters.
            registration.Preparing += OnComponentPreparing;

            //Handle properties.
            registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
        }
    }
}