using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Item Pickup")]

    [Tooltip("Posisi tangan (mengambil item)")]
    [SerializeField] Transform handTransform;

    [Tooltip("Posisi kepala (aiming untuk mengambil item)")]
    [SerializeField] Transform headTransform;

    [Tooltip("Layer dari item yang diambil")]
    [SerializeField] LayerMask itemLayer;

    [Tooltip("Jarak yang diperbolehkan untuk diambil")]
    [SerializeField, Min(0)] float pickupRange = 5f;

    [Tooltip("Sudut yang diperbolehkan untuk diambil")]
    [SerializeField, Range(0, 45)] float pickupAngle = 30f;

    GameObject nearbyItem;
    public Inventory inventory { get; private set; }

    void Awake()
    {
        inventory = new Inventory();
    }

    void Update()
    {
        CheckForNearbyItems();
    }

    // Mendeteksi gameobject dekat dengan layer yang benar
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
        Physics.Raycast(
            new Ray(headTransform.position, Camera.main.transform.forward),
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

    // Ambil item
    public void OnGrab()
    {
        try
        {
            inventory.AddItem(nearbyItem.GetComponent<Item>());
            Destroy(nearbyItem);
        }
        catch (Exception ex)
        {

        }
    }
}
