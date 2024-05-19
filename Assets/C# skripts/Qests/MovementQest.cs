using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementQest : MonoBehaviour, IQest
{
    public event Action OnComplate;

    [SerializeField] GameObject _questDescriptionPanel;
    [SerializeField] TMP_Text _questDescriptionText;
    [SerializeField] KeyCode _codeQuest;
    [SerializeField] string _nameQuest;
    [SerializeField] string _descriptionQuest;

    public void RunQuest()
    {
        _questDescriptionPanel.SetActive(true);
        _questDescriptionText.text = _descriptionQuest;
    }

    public void UpdateQuest()
    {
        if (Input.GetKeyDown(_codeQuest))
        {
            Complate();
        }
    }

    void Complate()
    {
        _questDescriptionPanel.SetActive(false);
        OnComplate?.Invoke();
    }
}
