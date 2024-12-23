using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class untuk panel misi yang sedang berlangsung
/// </summary>
public class MissionPanel : MonoBehaviour
{
    /// <summary>
    /// Object gambar background
    /// </summary>
    [field: SerializeField, Tooltip("Object gambar background")]
    public Image image { get; private set; }

    /// <summary>
    /// Misi yang sedang berlangsung
    /// </summary>
    [field: NonSerialized]
    public Mission mission { private get; set; }

    /// <summary>
    /// Text box berisi deskripsi misi
    /// </summary>
    [SerializeField, Tooltip("Text box berisi deskripsi misi")]
    private TextMeshProUGUI textDescription;

    /// <summary>
    /// Text box berisi progress misi
    /// </summary>
    [SerializeField, Tooltip("Text box berisi progress misi")]
    private TextMeshProUGUI textProgress;

    /// <summary>
    /// Text box berisi sisa waktu
    /// </summary>
    [SerializeField, Tooltip("Text box berisi sisa waktu")]
    private TextMeshProUGUI textTimer;


    void Start()
    {
        textDescription.text = mission.GetDescription();

        mission.MissionCompleted.AddListener(OnMissionCompleted);
        mission.MissionFailed.AddListener(OnMissionFailed);
    }

    void Update()
    {
        if (mission.isRunning)
        {
            if (mission is CollectItemMission current)
                textProgress.text = $"{current.progress}/{current.target}";
            if (mission.timeLimit > 0)
                textTimer.text = $"{mission.timeLimit - mission.timeElapsed:F1}s";
        }
    }

    /// <summary>
    /// Saat misi berhasil
    /// </summary>
    void OnMissionCompleted()
    {
        textProgress.text = "BERHASIL";
        
        image.color = new Color(0, 1, 0, 1f / 3f);
        Destroy(gameObject, 3f);
    }

    /// <summary>
    /// Saat misi gagal
    /// </summary>
    void OnMissionFailed()
    {
        textProgress.text = "GAGAL";

        image.color = new Color(1, 0, 0, 1f / 3f);
        Destroy(gameObject, 3f);
    }
}
