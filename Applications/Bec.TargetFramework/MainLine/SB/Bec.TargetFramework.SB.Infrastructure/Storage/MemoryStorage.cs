using System;
using NServiceBus.Features;
using NServiceBus.Gateway.Deduplication;
using NServiceBus.Saga;
using NServiceBus.Timeout.Core;

namespace NServiceBus.Persistence.ExtendedInMemory
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using Unicast.Subscriptions;
    using Unicast.Subscriptions.MessageDrivenSubscriptions;

    public class ExtendedInMemoryPersistence : PersistenceDefinition
    {
        public ExtendedInMemoryPersistence()
        {
            Supports<StorageType.Sagas>(s => s.EnableFeatureByDefault<InMemorySagaPersistence>());
            Supports<StorageType.Timeouts>(s => s.EnableFeatureByDefault<InMemoryTimeoutPersistence>());
            Supports<StorageType.Subscriptions>(s => s.EnableFeatureByDefault<ExtendedInMemorySubscriptionPersistence>());
            Supports<StorageType.Outbox>(s => s.EnableFeatureByDefault<InMemoryOutboxPersistence>());
            Supports<StorageType.GatewayDeduplication>(s => s.EnableFeatureByDefault<InMemoryGatewayPersistence>());


        }
    }

    public class ExtendedInMemorySubscriptionPersistence : Feature
    {
        public ExtendedInMemorySubscriptionPersistence()
        {
            DependsOn<MessageDrivenSubscriptions>();
        }

        /// <summary>
        /// See <see cref="Feature.Setup"/>
        /// </summary>
        protected override void Setup(FeatureConfigurationContext context)
        {
            context.Container.ConfigureComponent<ExtendedInMemorySubscriptionStorage>(DependencyLifecycle.SingleInstance);
        }
    }

    /// <summary>
    /// In memory implementation of the subscription storage
    /// </summary>
    public class ExtendedInMemorySubscriptionStorage : ISubscriptionStorage
    {
        void ISubscriptionStorage.Subscribe(Address address, IEnumerable<MessageType> messageTypes)
        {
            foreach (var m in messageTypes)
            {
                var dict = storage.GetOrAdd(m, type => new ConcurrentDictionary<Address, object>());

                dict.AddOrUpdate(address, addValueFactory, updateValueFactory);
            }
        }

        void ISubscriptionStorage.Unsubscribe(Address address, IEnumerable<MessageType> messageTypes)
        {
            foreach (var m in messageTypes)
            {
                ConcurrentDictionary<Address, object> dict;
                if (storage.TryGetValue(m, out dict))
                {
                    object _;
                    dict.TryRemove(address, out _);
                }
            }
        }

        IEnumerable<Address> ISubscriptionStorage.GetSubscriberAddressesForMessage(IEnumerable<MessageType> messageTypes)
        {
            var result = new HashSet<Address>();
            foreach (var m in messageTypes)
            {
                ConcurrentDictionary<Address, object> list;
                if (storage.TryGetValue(m, out list))
                {
                    result.UnionWith(list.Keys);
                }
            }
            return result;
        }

        public void Init()
        {
        }

        readonly ConcurrentDictionary<MessageType, ConcurrentDictionary<Address, object>> storage = new ConcurrentDictionary<MessageType, ConcurrentDictionary<Address, object>>();
        Func<Address, object> addValueFactory = a => null;
        Func<Address, object, object> updateValueFactory = (a, o) => null;
    }
}