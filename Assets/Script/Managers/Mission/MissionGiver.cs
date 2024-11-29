using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [SerializeField]
    private List<Mission> missionsToGive;

    bool missionGiven;

    public void GiveMission()
    {
        foreach (Mission mission in missionsToGive)
        {
            Mission copy = Instantiate(mission);
            Player.instance.missionManager.missions.Add(copy);
        }

        
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