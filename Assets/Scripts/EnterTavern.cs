using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTavern : InteractableItem
{

    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(interactText);    
    }

    public override void OnInteractPress()
    {
        SceneManager.LoadScene("Tavern");
    }
}
