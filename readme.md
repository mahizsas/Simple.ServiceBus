#Simple.ServiceBus

Wrapper for the Windows Service Bus. 

##Example

```
var container = new ContainerBuilder()
                .RegisterServiceBus()
                .RegisterHandlers(System.Reflection.Assembly.GetExecutingAssembly())
                .ListenFor<SimpleMessage>()
                .Subscribe<SimpleMessage>(x => Console.WriteLine(string.Format("Received (delegate) '{0}' with message id of {1}", x.Title, x.Id)))
                .Build();

            var serviceBus = container.Resolve<IServiceBus>();
 ```
 
``` 
 public class SimpleHandler : IHandle<SimpleMessage>
    {
        public void Handle(SimpleMessage message)
        {
            Console.WriteLine(string.Format("Received (autofac) '{0}' with message id of {1}", message.Title, message.Id));
        }

        public void Handle(object message)
        {
            this.Handle((SimpleMessage) message);
        }
    }
```

#Next

* Remove IHandle (or add helper base class, iik!)
* Add Configuration support for SubscriptionClient sufix
* Add Configuration support to ListenFor<>

```
var container = new ContainerBuilder()
                .RegisterServiceBus()
                .RegisterHandlers(System.Reflection.Assembly.GetExecutingAssembly())
                .ListenFor<SimpleMessage>(c => configuration...)
                .Build();

            var serviceBus = container.Resolve<IServiceBus>();
 ```