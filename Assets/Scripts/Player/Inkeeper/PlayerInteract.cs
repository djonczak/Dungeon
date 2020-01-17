using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InteractableItem itemInteract;
    public float holdButton;
    private float holdTime = 0f;

    private void Update()
    {
        InteractHoldInput();
    }

    private void InteractHoldInput()
    {
        if (holdButton > 0.25f)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= 2f)
            { 
                InteractHold();
                holdTime = 0f;
            }
        }
        else
        {
            holdTime = 0f;
        }
    }

    public void InteractPress()
    {
        if (itemInteract != null)
        {
            itemInteract.OnInteractPress();
        }
    }

    private void InteractHold()
    {
        if (itemInteract != null)
        {
            itemInteract.OnInteractHold();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            var interact = other.GetComponent<InteractableItem>();
            if (interact != null)
            {
                interact.ShowInfo();
                itemInteract = interact;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            itemInteract = null;
            HUDEvent.CloseMessage();
        }
    }
}
