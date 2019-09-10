using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityReturn : InteractableItem
{
    public override void ShowInfo()
    {
        interactText = "Press E to exit " + itemName;
    }

    public override void OnInteractPress()
    {
        SceneManager.LoadScene("CityHUB");
    }
}
