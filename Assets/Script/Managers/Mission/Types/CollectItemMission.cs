using System;
using UnityEngine;

/// <summary>
/// Class untuk misi mengumpulkan item
/// </summary>
[CreateAssetMenu(fileName = "CollectItemMission", menuName = "Missions/Collect Item Mission")]
public class CollectItemMission : Mission
{
    /// <summary>
    /// Item yang harus dikumpulkan
    /// </summary>
    [field: SerializeField, Tooltip("Item yang harus dikumpulkan, letaknya di Assets/Resources/Items")]
    public ItemData item { get; private set; }

    /// <summary>
    /// Banyak item yang harus didapatkan
    /// </summary>
    [field: SerializeField, Min(1), Tooltip("Banyak item yang harus didapatkan")]
    public int target { get; private set; }

    /// <summary>
    /// Progress saat ini
    /// </summary>
    [field: NonSerialized]
    public int progress { get; private set; }

    void OnItemCollected(Item item)
    {
        if (item.data != this.item) return;

        progress += item.amount;

        if (progress >= target)
        {
            End();

            EventBus.MissionCompleted?.Invoke(this);
            MissionCompleted?.Invoke();
        }
    }

    public override void Start()
    {
        base.Start();
        
        progress = 0;
        EventBus.ItemCollected.AddListener(OnItemCollected);
    }

    public override void End()
    {
        base.End();
        
        EventBus.ItemCollected.RemoveListener(OnItemCollected);
    }

    public override string GetDescription()
    {
        string text = $"Kumpulkan {target} {item.name}";
        if (timeLimit > 0) text += $" dalam waktu {timeLimit} detik";
        return text;
    }
}