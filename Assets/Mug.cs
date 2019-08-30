using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : InteractableItem
{
    public float amountToFill;
    public bool isDirty;
    public bool isFull;

    public Canvas canvas;
    public Transform emptyMug;
    public Transform fullMug;

    public override void OnInteract()
    {
        itemName = "Mug";
        interactText = "Press E/X/A/B to pick up " + itemName;
      //  base.OnInteract();
    }

    private void Start()
    {
        emptyMug.gameObject.SetActive(true);
        fullMug.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
       canvas.transform.rotation = Camera.main.transform.rotation;
    }

    public void FillMug(BeerKeg keg)
    {
        if (isFull == false)
        {
            keg.FillMug(amountToFill);
            isFull = true;
            fullMug.gameObject.SetActive(true);
            emptyMug.gameObject.SetActive(false);
        }
    }

    public void DirtyMug()
    {
        isFull = false;
        isDirty = true;
        fullMug.gameObject.SetActive(false);
        emptyMug.gameObject.SetActive(true);
    }

    public void CleanMug()
    {

    }
}
