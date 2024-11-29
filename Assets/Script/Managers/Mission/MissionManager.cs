using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [field: SerializeField]
    public List<Mission> missions { get; private set; } = new();

    void Awake()
    {
        EventBus.MissionCompleted.AddListener(RemoveMission);
        EventBus.MissionFailed.AddListener(RemoveMission);
        EventBus.MissionAssigned.AddListener(StartMission);
    }

    void Update()
    {
        foreach (Mission mission in missions)
        {
            mission?.Update();
        }
    }

    void RemoveMission(Mission mission)
    {
        missions.Remove(mission);
    }

    void StartMission()
    {
        foreach (Mission mission in missions)
        {
            if (!mission.isStarted) mission.Start();
        }
    }
}
