using System;
using UnityEngine;
using StarterAssets;
using Cinemachine;

/// <summary>
/// Class untuk player
/// </summary>
public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    [Header("Player Item Pickup")]

    /// <summary>
    /// Posisi tangan (mengambil item)
    /// </summary>
    [Tooltip("Posisi tangan (mengambil item)")]
    [SerializeField] Transform handTransform;

    /// <summary>
    /// Posisi kepala (aiming untuk mengambil item)
    /// </summary>
    [Tooltip("Posisi kepala (aiming untuk mengambil item)")]
    [SerializeField] Transform headTransform;

    /// <summary>
    /// Layer dari item yang diambil
    /// </summary>
    [Tooltip("Layer dari item yang diambil")]
    [SerializeField] LayerMask itemLayer;

    /// <summary>
    /// Jarak yang diperbolehkan untuk mengambil/berinteraksi dengan item
    /// </summary>
    [Tooltip("Jarak yang diperbolehkan untuk mengambil/berinteraksi dengan item")]
    [SerializeField, Min(0)] float pickupRange = 5f;

    /// <summary>
    /// Sudut yang diperbolehkan untuk mengambil/berinteraksi dengan item
    /// </summary>
    [Tooltip("Sudut yang diperbolehkan untuk mengambil/berinteraksi dengan item")]
    [SerializeField, Range(0, 45)] float pickupAngle = 30f;
    
    /// <summary>
    /// Item yang berada di dekat player
    /// </summary>
    GameObject nearbyItem;

    /// <summary>
    /// Item yang dipegang player
    /// </summary>
    GameObject handItem;

    public Inventory inventory { get; private set; }

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;

        inventory = new Inventory();

        InitializeComponents();
    }

    /// <summary>
    /// Menginisialisasi komponen-komponen player
    /// </summary>
    void InitializeComponents()
    {
        CinemachineVirtualCamera camera = GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>();
        
        Transform cameraRoot = GetComponent<ThirdPersonController>().CinemachineCameraTarget.transform;

        camera.LookAt = cameraRoot;
        camera.Follow = cameraRoot;
    }

    void Update()
    {
        CheckForNearbyItems();
    }

    /// <summary>
    /// Mendeteksi item yang berada di dekat player
    /// </summary>
    void CheckForNearbyItems()
    {
        Vector3 playerForward = transform.forward;

        // Abaikan sumbu Y
        Vector3 cameraForward = new(
            Camera.main.transform.forward.x,
            0,
            Camera.main.transform.forward.z
        );

        // Raycast
        Physics.SphereCast(
            new Ray(headTransform.position, Camera.main.transform.forward),
            0.5f,
            out RaycastHit hit,
            pickupRange,
            itemLayer,
            QueryTriggerInteraction.Collide
        );

        // Sudut antara arah pemain dan arah kamera
        float angle = Vector3.Angle(playerForward, cameraForward);

        if (hit.collider != null && angle <= pickupAngle)
        {
            nearbyItem = hit.collider.gameObject;
        }
        else
        {
            nearbyItem = null;
        }
    }

    /// <summary>
    /// Mengambil item yang berada di hadapan player
    /// </summary>
    public void OnGrab()
    {
        try
        {
            nearbyItem.SendMessage("Pick");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    /// <summary>
    /// Interaksi dengan item yang berada di hadapan player
    /// </summary>
    public void OnInteraction()
    {
        try
        {
            nearbyItem.SendMessage("Interact");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    /// <summary>
    /// Memegang item
    /// </summary>
    /// <param name="item">Item yang dipegang</param>
    public void SetHand(Item item)
    {
        if (handItem != null)
        {
            Destroy(handItem);
        }

        handItem = Instantiate(item.data.prefab, handTransform);
        handItem.transform.localScale = Vector3.one * 0.01f;
        
        handItem.GetComponent<Collectible>().item.amount = item.amount;
        handItem.GetComponent<Collectible>().item.data = item.data;
    }

    /// <summary>
    /// Jatuhkan item yang dipegang ke tanah
    /// </summary>
    public void OnDrop()
    {
        if (handItem == null)
        {
            return;
        }

        inventory.RemoveItemAt(inventory.selectedIndex);

        handItem.transform.parent = null;
        handItem.AddComponent<Rigidbody>();

        handItem = null;
    }
}
