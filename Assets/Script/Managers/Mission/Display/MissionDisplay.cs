using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Class untuk menampilkan misi yang diberikan
/// </summary>
public class MissionDisplay : MonoBehaviour
{
    /// <summary>
    /// Pemberi misi
    /// </summary>
    public MissionGiver missionGiver { private get; set; }

    /// <summary>
    /// Text box berisi deskripsi misi
    /// </summary>
    [SerializeField, Tooltip("Text box berisi deskripsi misi")]
    TextMeshProUGUI missionDescription;

    void Start()
    {
        Popup.Open();

        Debug.Log(missionGiver);

        foreach (Mission mission in missionGiver.missionsToGive)
        {
            missionDescription.text += mission.GetDescription() + "\n";
        }
    }

    /// <summary>
    /// Terima misi dan mulai
    /// </summary>
    public void AcceptMission()
    {
        Popup.Close();

        missionGiver.GiveMission();
        Destroy(gameObject);
    }

    /// <summary>
    /// Tolak misi
    /// </summary>
    public void DeclineMission()
    {
        Popup.Close();

        Destroy(gameObject);
    }
}
