using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TavernDoor : InteractableItem
{
    public bool isOpen;
    public bool isInTavern;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string name = currentScene.name;
        if(name == "Tavern")
        {
            isInTavern = true;
        }
        else if(name == "CityHUB")
        {
            isInTavern = false;
        }

    }

    public override void ShowInfo()
    {
        if (isInTavern == true)
        {
            if (isOpen == false)
            {
                interactText = "Press E to open Tavern or Hold to exit";
            }
            else
            {
                interactText = "Tavern is opened !! You can't go out.";
            }
        }
        else
        {
            interactText = "Hold E to enter tavern.";
        }
    }

    public override void OnInteractPress()
    {
        Debug.Log("Open");
        if (isOpen == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z), Time.deltaTime * 50f);
            GuestHandler.instance.OpenTavern();
            isOpen = true;
        }
    }

    public override void OnInteractHold()
    {
        if (isInTavern == true)
        {
            if (isOpen == false)
            {
                Debug.Log("Przygoda wzywa");
                SceneManager.LoadScene("CityHUB");
            }
        }
        else
        {
            SceneManager.LoadScene("Tavern");
        }     
    }
}
