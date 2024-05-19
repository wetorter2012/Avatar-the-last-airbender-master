using System;

namespace Game.Services.Events
{
    public interface ILevelEvents
    {
        event Action LevelReady;
    }
}
