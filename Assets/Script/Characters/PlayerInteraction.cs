using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask interactableLayerMask; //Control Layers
    public Transform InteractorSource;
    public float InteractRange = 50f;
    public float sphereRadius = 2f;

    public event Action<string> OnInteractableDetected; 
    public event Action OnInteractableLost;

    private IInteractable currentInteractable;
    private RaycastHit lastHitInfo;
    

    void Update()
    {
        DetectInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void DetectInteractable()
    {
        Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.SphereCast(ray, sphereRadius, out RaycastHit hitInfo, InteractRange, interactableLayerMask))
        {
            lastHitInfo = hitInfo;

            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                // Only notify if detects interactable object
                if (currentInteractable != interactable)
                {
                    currentInteractable = interactable;
                    OnInteractableDetected?.Invoke(hitInfo.collider.gameObject.name);
                }
                return;
            }
        }

        // Notify if previous object is lost
        if (currentInteractable != null)
        {
            currentInteractable = null;
            OnInteractableLost?.Invoke();
        }
    }

    // Draw Gizmos in Scene view
    private void OnDrawGizmos()
    {
        if (InteractorSource != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange);

            Gizmos.color = Color.red; 
            Gizmos.DrawWireSphere(InteractorSource.position + InteractorSource.forward * InteractRange, sphereRadius);

            if (lastHitInfo.collider != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(lastHitInfo.point, sphereRadius);
            }
        }
    }
}
