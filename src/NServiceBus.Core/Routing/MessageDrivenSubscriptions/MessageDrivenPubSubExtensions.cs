namespace NServiceBus
{
    using System;
    using System.Reflection;
    using Routing;
    using Routing.MessageDrivenSubscriptions;
    using Transports;

    /// <summary>
    /// Extensions for configuring message-driven pub sub.
    /// </summary>
    public static class MessageDrivenPubSubExtensions
    {
        /// <summary>
        /// Registers a publisherEndpoint endpoint for a given endpoint type.
        /// </summary>
        /// <param name="routingSettings">Extended object</param>
        /// <param name="publisherEndpoint">Publisher endpoint</param>
        /// <param name="eventType">Event type</param>
        public static void RegisterPublisherForType<T>(this RoutingSettings<T> routingSettings, string publisherEndpoint, Type eventType) where T : TransportDefinition, IMessageDrivenSubscriptionTransport
        {
            routingSettings.Settings.GetOrCreate<Publishers>().Add(publisherEndpoint, eventType);
        }

        /// <summary>
        /// Registers a publisherEndpoint for all events in a given assembly (and optionally namespace).
        /// </summary>
        /// <param name="routingSettings">Extended object</param>
        /// <param name="publisherEndpoint">Publisher endpoint</param>
        /// <param name="eventAssembly">Assembly containing events</param>
        /// <param name="eventNamespace">Optional namespace containing events</param>
        public static void RegisterPublisherForAssembly<T>(this RoutingSettings<T> routingSettings, string publisherEndpoint, Assembly eventAssembly, string eventNamespace = null) where T : TransportDefinition, IMessageDrivenSubscriptionTransport
        {
            routingSettings.Settings.GetOrCreate<Publishers>().Add(publisherEndpoint, eventAssembly, eventNamespace);
        }
    }
}