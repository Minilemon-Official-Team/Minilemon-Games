using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Mission : ScriptableObject
{
    [field: SerializeField, Tooltip("Batas waktu misi dalam detik, 0 = tidak ada batas waktu")]
    public virtual float timeLimit { get; protected set; } = 0;
    
    [field: NonSerialized]
    public virtual float timeElapsed { get; protected set; } = 0;

    [field: NonSerialized]
    public virtual bool isRunning { get; protected set; } = false;

    // Events
    public virtual UnityEvent MissionCompleted { get; protected set; } = new();
    public virtual UnityEvent MissionFailed { get; protected set; } = new();
    public virtual UnityEvent MissionProgress { get; protected set; } = new();
    
    public virtual void Start() {}
    public virtual void Update() {}
    public virtual void End() {}
    public virtual string GetDescription() => "";
}