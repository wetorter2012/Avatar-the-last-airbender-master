using System;

namespace Game.Services.Events
{
    public class LevelEvents : ILevelEvents, ILevelEventsExec
    {
        public event Action LevelReady;

        public void OnLevelReady() => LevelReady?.Invoke();
    }
}
