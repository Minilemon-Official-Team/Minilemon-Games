using System.Collections.Generic;
using UnityEngine;

public class MissionGiver : MonoBehaviour
{
    [field:SerializeField, Tooltip("Misi yang akan diberikan")]
    public List<Mission> missionsToGive {get; private set;}

    [field:SerializeField, Tooltip("Yang akan dispawn saat misi berjalan")]
    public GameObject missionPrefab {get; private set;}

    public void GiveMission()
    {
        MissionManager.instance.missions.AddRange(missionsToGive);
        EventBus.InvokeMissionStarted();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && MissionManager.instance.missions.Count == 0 && !Popup.isOpened)
        {
            EventBus.InvokeMissionsGiven(this);
        }
    }
}