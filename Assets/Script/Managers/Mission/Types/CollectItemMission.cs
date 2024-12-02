using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectItemMission", menuName = "Missions/Collect Item Mission")]
public class CollectItemMission : Mission
{
    [field: SerializeField, Tooltip("Item yang harus dikumpulkan, letaknya di Assets/Resources/Items")]
    public ItemData item { get; private set; }

    [field: SerializeField, Min(1), Tooltip("Banyak item yang harus didapatkan")]
    public int target { get; private set; }

    [field: NonSerialized]
    public int progress { get; private set; }

    void OnItemCollected(Item item)
    {
        if (item.data != this.item) return;

        progress += item.amount;
        Debug.Log($"Progress: {progress}/{target} ({progress / (float)target:P2})");

        if (progress >= target)
        {
            End();
            Debug.Log("Mission completed!");

            EventBus.InvokeMissionCompleted(this);
            MissionCompleted?.Invoke();
        }
    }

    public override void Start()
    {
        EventBus.ItemCollected.AddListener(OnItemCollected);
        isRunning = true;
    }

    public override void Update()
    {
        if (!isRunning) return;

        if (timeLimit > 0) timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit)
        {
            End();
            Debug.Log("Mission failed: time's up!");

            EventBus.InvokeMissionFailed(this);
            MissionFailed?.Invoke();
        }
    }

    public override void End()
    {
        isRunning = false;
        EventBus.ItemCollected.RemoveListener(OnItemCollected);
    }
}