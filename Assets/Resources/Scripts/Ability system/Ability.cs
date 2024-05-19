using UnityEngine;
using System;

public class Ability
{
    public Action<float, float> EventChangeCooldownTimer;
    public Sprite Icon { get; private set; }
    public GameObject VFX { get; private set; }
    public KeyCode HotKey { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public float CooldownTime { get; private set; }
    public float CooldownTimer { get; private set; }
}
