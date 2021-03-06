﻿namespace NServiceBus.Unicast.Tests
{
    using Outbox;
    using Transports;
    using NUnit.Framework;
    using Testing;

    [TestFixture]
    public class LoadHandlersBehaviorTests
    {
        [Test]
        public void Should_throw_when_there_are_no_registered_message_handlers()
        {
            var behavior = new LoadHandlersConnector(new MessageHandlerRegistry(new Conventions()), new InMemorySynchronizedStorage(), new InMemoryTransactionalSynchronizedStorageAdapter());

            var context = new TestableIncomingLogicalMessageContext();

            context.Extensions.Set<OutboxTransaction>(new InMemoryOutboxTransaction());
            context.Extensions.Set<TransportTransaction>(new FakeTransportTransaction());

            Assert.That(async () => await behavior.Invoke(context, c => TaskEx.CompletedTask), Throws.InvalidOperationException);
        }

        class FakeTransportTransaction : TransportTransaction
        {
        }
    }
}