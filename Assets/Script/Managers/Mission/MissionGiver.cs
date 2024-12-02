using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [field:SerializeField]
    public List<Mission> missionsToGive {get; private set;}

    [SerializeField]
    private GameObject missionDisplay;

    bool missionGiven;

    public void GiveMission()
    {
        missionGiven = true;

        Player.instance.missionManager.missions.AddRange(missionsToGive);
        EventBus.InvokeMissionAssigned();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !missionGiven && MissionDisplay.instance == null)
        {
            GameObject display = Instantiate(missionDisplay, GameObject.FindGameObjectWithTag("UI").transform);
            display.GetComponent<MissionDisplay>().missionGiver = this;
        }
    }
}