using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Mission : ScriptableObject
{
    [field: SerializeField, Tooltip("Batas waktu misi dalam detik, 0 = tidak ada batas waktu"), Min(0)]
    public virtual float timeLimit { get; protected set; } = 0;

    /// <summary>
    /// Waktu yang telah berlalu sejak misi dimulai
    /// </summary>
    [field: NonSerialized]
    public virtual float timeElapsed { get; protected set; } = 0;

    /// <summary>
    /// Apakah misi sedang berjalan?
    /// </summary>
    [field: NonSerialized]
    public virtual bool isRunning { get; protected set; } = false;

    // Events
    public virtual UnityEvent MissionCompleted { get; protected set; } = new();
    public virtual UnityEvent MissionFailed { get; protected set; } = new();

    /// <summary>
    /// Mulai misi
    /// </summary>
    public virtual void Start()
    {
        timeElapsed = 0;
        isRunning = true;
    }

    public virtual void Update()
    {
        if (!isRunning) return;
        if (timeLimit == 0) return;

        if (timeLimit > 0) timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit)
        {
            End();

            EventBus.MissionFailed?.Invoke(this);
            MissionFailed?.Invoke();
        }
    }
    
    /// <summary>
    /// Hentikan misi
    /// </summary>
    public virtual void End()
    {
        isRunning = false;
    }

    /// <summary>
    /// Dapatkan deskripsi misi
    /// </summary>
    public abstract string GetDescription();
}