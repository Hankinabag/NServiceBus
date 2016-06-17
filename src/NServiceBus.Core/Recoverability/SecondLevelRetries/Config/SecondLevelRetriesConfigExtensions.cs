namespace NServiceBus
{
    /// <summary>
    /// Provides config options for the SLR feature.
    /// </summary>
    public static class SecondLevelRetriesConfigExtensions
    {
        /// <summary>
        /// Allows for customization of the second level retries.
        /// </summary>
        /// <param name="config">The <see cref="EndpointConfiguration" /> instance to apply the settings to.</param>
        public static SecondLevelRetriesSettings SecondLevelRetries(this EndpointConfiguration config)
        {
            Guard.AgainstNull(nameof(config), config);
            return new SecondLevelRetriesSettings(config);
        }
    }
}