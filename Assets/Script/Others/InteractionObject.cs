using UnityEngine;

//IInteractable.cs Interface
public class InteractionObject : MonoBehaviour, IInteractable
{
    //Insert logic here
    public void Interact()
    {
        Debug.Log("You interacted with : " + gameObject.name);
    }
}
