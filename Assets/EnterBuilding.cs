using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : InteractableItem
{
    [SerializeField] private bool inBuilding = false;
    public Transform dungeonPoint;
    public Transform castlePoint;
    public Transform player;
    public AdventurerHUD hud;

    public GameObject city;
    public GameObject dungeon;

    public TimeController timeController;

    private void Start()
    {
        dungeon.SetActive(false);
    }

    public override void ShowInfo()
    {
        if (inBuilding == false)
        {
            interactText = "Press E to enter dungeon";
        }
        else
        {
            interactText = "Press E to go outside.";
        }
    }

    public override void OnInteractPress()
    {
        if(inBuilding == false)
        {
            inBuilding = true;
            dungeon.SetActive(true);
            city.SetActive(false);
            player.transform.position = dungeonPoint.position;
            hud.FogDisperse();
            timeController.SwitchLights();
        }
        else
        {
            inBuilding = false;
            dungeon.SetActive(false);
            city.SetActive(true);
            player.transform.position = castlePoint.position;
            hud.FogDisperse();
            timeController.SwitchLights();
        }
    }

}
