using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] _questAll;
    [SerializeField] bool _tutorialIsComplite;

    List<IQest> _quests;
    int _currentQuestIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeTutorial()
    {
        InitializeQuest();
    }

    void InitializeQuest()
    {
        _quests = new();

        foreach(MonoBehaviour item in _quests)
        {
            if (item is IQest quest)
            {
                _quests.Add(quest);
            }
        }
    }

    public void RunTutorial(int qestindex = 0)
    {
        _currentQuestIndex = qestindex;
        RunNextQuest();
    }

    void QuestOnComplite()
    {
        _quests[_currentQuestIndex].OnComplate -= QuestOnComplite;
        _currentQuestIndex++;

        if (_currentQuestIndex < _quests.Count)
        {
            RunNextQuest();
        }
        else
        {
            _tutorialIsComplite = true;
        }
    }

    void RunNextQuest()
    {
        _quests[_currentQuestIndex].OnComplate += QuestOnComplite;
        _quests[_currentQuestIndex].RunQuest();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_tutorialIsComplite && _currentQuestIndex != -1)
        {
            _quests[_currentQuestIndex].UpdateQuest();
        }
    }
}
