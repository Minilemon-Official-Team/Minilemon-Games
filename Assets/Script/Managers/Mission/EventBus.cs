using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// Class yang digunakan untuk game event secara global
/// </summary>
public static class EventBus
{
    // Events

    /// <summary>
    /// Event yang dipanggil ketika misi diberikan
    /// </summary>
    public static UnityEvent<MissionGiver> MissionsGiven = new();

    /// <summary>
    /// Event yang dipanggil ketika misi dimulai
    /// </summary>
    public static UnityEvent MissionStarted = new();

    /// <summary>
    /// Event yang dipanggil ketika misi selesai
    /// </summary>
    public static UnityEvent<Mission> MissionCompleted = new();

    /// <summary>
    /// Event yang dipanggil ketika misi gagal
    /// </summary>
    public static UnityEvent<Mission> MissionFailed = new();

    /// <summary>
    /// Event yang dipanggil ketika item dikumpulkan
    /// </summary>
    public static UnityEvent<Item> ItemCollected = new();
}