using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Simple.ServiceBus.Infrastructure
{
    public class TopicRepository : ITopicRepository
    {
        private readonly NamespaceManager _namespaceManager;

        public TopicRepository(NamespaceManager namespaceManager)
        {
            _namespaceManager = namespaceManager;
        }

        public TopicDescription Get<T>()
        {
            var topicName = string.Format("Topic_{0}", typeof(T).Name);
            
            if (!_namespaceManager.TopicExists(topicName))
                _namespaceManager.CreateTopic(topicName);

            return _namespaceManager.GetTopic(topicName);
        }

    }
}
