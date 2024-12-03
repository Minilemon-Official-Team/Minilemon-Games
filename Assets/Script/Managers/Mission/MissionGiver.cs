using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [field:SerializeField]
    public List<Mission> missionsToGive {get; private set;}

    bool missionGiven;

    public void GiveMission()
    {
        missionGiven = true;

        MissionManager.instance.missions.AddRange(missionsToGive);
        EventBus.InvokeMissionStarted();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !missionGiven && MissionDisplay.instance == null)
        {
            EventBus.InvokeMissionsGiven(this);
        }
    }
}