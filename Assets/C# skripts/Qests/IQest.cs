using System;

public interface IQest
{
    event Action OnComplate;

    void RunQuest();
    void UpdateQuest();
}
