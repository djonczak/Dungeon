using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeerKeg : MonoBehaviour
{
    public float minAmount;
    public float maxAmount;
    public Image beerAmount;

    void Start()
    {
        minAmount = maxAmount;
    }

    public void FillMug(float amount)
    {
        if (minAmount > 0)
        {
            minAmount -= amount;
            beerAmount.fillAmount = minAmount / maxAmount;
        }
        else
        {
            enabled = false;
        }
    }
}
