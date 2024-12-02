using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [SerializeField]
    private List<Mission> missionsToGive;

    bool missionGiven;

    public void GiveMission()
    {
        Player.instance.missionManager.missions.AddRange(missionsToGive);
        EventBus.InvokeMissionAssigned();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !missionGiven)
        {
            GiveMission();
            missionGiven = true;

            Debug.Log("Mission start!");
        }
    }
}