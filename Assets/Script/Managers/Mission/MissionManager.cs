using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager instance { get; private set; }

    /// <summary>
    /// List misi yang sedang berjalan
    /// </summary>
    public List<Mission> missions { get; private set; } = new();

    [SerializeField, Tooltip("Object untuk menampilkan misi yang akan diberikan")]
    private GameObject missionDisplay;

    [SerializeField, Tooltip("Object untuk menampilkan misi yang sedang berjalan")]
    private GameObject missionPanel;

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;

            EventBus.MissionCompleted.AddListener(RemoveMission);
            EventBus.MissionFailed.AddListener(RemoveMission);
            EventBus.MissionStarted.AddListener(StartMission);
            EventBus.MissionsGiven.AddListener(ShowMissions);
        }
    }

    void Update()
    {
        foreach (Mission mission in missions)
        {
            mission?.Update();
        }
    }

    /// <summary>
    /// Hapus misi dari list
    /// </summary>
    /// <param name="mission">Misi yang ingin dihapus</param>
    void RemoveMission(Mission mission)
    {
        missions.Remove(mission);
    }

    /// <summary>
    /// Mulai misi
    /// </summary>
    void StartMission()
    {
        foreach (Mission mission in missions)
        {
            if (!mission.isRunning)
            {
                GameObject panel = Instantiate(missionPanel, GameObject.Find("Missions").transform);
                panel.GetComponent<MissionPanel>().mission = mission;

                mission.Start();
            }
        }
    }

    /// <summary>
    /// Tampilkan misi apa saja yang ada di pemberi misi
    /// </summary>
    /// <param name="giver">Pemberi misi</param>
    void ShowMissions(MissionGiver giver)
    {
        GameObject display = Instantiate(missionDisplay, GameObject.FindGameObjectWithTag("UI").transform);
        display.GetComponent<MissionDisplay>().missionGiver = giver;
    }

    void OnDestroy()
    {
        foreach (Mission mission in missions)
        {
            mission.End();
        }
    }

    [ContextMenu("Test Mission")]
    void GetMissions() => Debug.Log(missions.Count);
}
