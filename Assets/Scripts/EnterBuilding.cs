using UnityEngine;

public class EnterBuilding : InteractableItem
{
    [SerializeField] private bool inBuilding = false;
    public Transform outsidePoint;
    public Transform inSidesPoint;

    public GameObject city;
    public GameObject dungeon;

    private void Start()
    {
        dungeon.SetActive(false);
    }

    public override void ShowInfo()
    {
        if (inBuilding == false)
        {
            interactText = "Press E to enter dungeon";
            HUDEvent.ShowMessage(interactText);
        }
        else
        {
            interactText = "Press E to go outside.";
            HUDEvent.ShowMessage(interactText);
        }
    }

    public override void OnInteractPress()
    {
        if(inBuilding == false)
        {
            GoInside();
        }
        else
        {
            GoOut();
        }
    }

    private void GoOut()
    {
        inBuilding = false;
        dungeon.SetActive(false);
        city.SetActive(true);
        PlayerExtension.GetPlayerObject().transform.position = outsidePoint.position;
        BlackScreenEvent.ShowBlackScreen();
        DayNightCycleEvent.SwitchLight(); 
    }

    private void GoInside()
    {
        inBuilding = true;
        dungeon.SetActive(true);
        city.SetActive(false);
        PlayerExtension.GetPlayerObject().transform.position = inSidesPoint.position;
        BlackScreenEvent.ShowBlackScreen();
        DayNightCycleEvent.SwitchLight();
    }
}
