using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private InteractableItem _itemInteract;
    public float holdButton;
    private float _holdTime = 0f;

    private void Update()
    {
        InteractHoldInput();
    }

    private void InteractHoldInput()
    {
        if (holdButton > 0.25f)
        {
            _holdTime += Time.deltaTime;
            if (_holdTime >= 2f)
            { 
                InteractHold();
                _holdTime = 0f;
            }
        }
        else
        {
            _holdTime = 0f;
        }
    }

    public void InteractPress()
    {
        if (_itemInteract != null)
        {
            _itemInteract.OnInteractPress();
        }
    }

    private void InteractHold()
    {
        if (_itemInteract != null)
        {
            _itemInteract.OnInteractHold();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            var interact = other.GetComponent<InteractableItem>();
            if (interact != null)
            {
                interact.ShowInfo();
                _itemInteract = interact;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            _itemInteract = null;
            HUDEvent.CloseMessage();
        }
    }
}
