using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [field:SerializeField]
    public List<Mission> missionsToGive {get; private set;}

    public void GiveMission()
    {
        MissionManager.instance.missions.AddRange(missionsToGive);
        EventBus.InvokeMissionStarted();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && MissionManager.instance.missions.Count == 0 && MissionDisplay.instance == null)
        {
            EventBus.InvokeMissionsGiven(this);
        }
    }
}