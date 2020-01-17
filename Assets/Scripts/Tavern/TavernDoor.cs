using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernDoor : InteractableItem
{
    [SerializeField] private bool isOpen;

    public override void ShowInfo()
    {
        interactText = "Press E to open Tavern or Hold to exit.";
        HUDEvent.ShowMessage(interactText);  
    }

    public override void OnInteractPress()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z), Time.deltaTime * 50f);
        GuestHandler.instance.OpenTavern();
        isOpen = true;
    }

    public override void OnInteractHold()
    {
        if (isOpen == false)
        {
            SceneManager.LoadScene("CityHUB");
        }  
    }
}
