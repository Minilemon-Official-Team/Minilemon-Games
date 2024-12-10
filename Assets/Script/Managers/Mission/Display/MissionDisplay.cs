using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionDisplay : MonoBehaviour
{
    public static MissionDisplay instance { get; private set; }

    public MissionGiver missionGiver { private get; set; }

    [SerializeField]
    TextMeshProUGUI missionDescription;

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        Debug.Log(missionGiver);

        foreach (Mission mission in missionGiver.missionsToGive)
        {
            missionDescription.text += mission.GetDescription() + "\n";
        }
    }

    public void AcceptMission()
    {
        missionGiver.GiveMission();
        Destroy(gameObject);
    }

    public void DeclineMission()
    {
        Destroy(gameObject);
    }
}
