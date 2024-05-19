using Game.Entities;
using Game.Services.Events;
using Game.Services.Locator;
using UnityEngine;

namespace Game.Services.Factory
{
    public class EntityFactory
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly ILevelEventsExec _levelEventsExec;

        public EntityFactory(IServiceLocator serviceLocator, ILevelEventsExec levelEventsExec)
        {
            _serviceLocator = serviceLocator;
            _levelEventsExec = levelEventsExec;
        }

        public Actor CreateActor(Actor actor, Vector3 location, Quaternion rotation)
        {
            Actor actorInstance = Object.Instantiate(actor, location, rotation);

            foreach (var dependency in actorInstance.GetComponentsInChildren<IInjectServices>())
            {
                dependency.Inject(_serviceLocator);
            }

            return actorInstance;
        }
    }
}
