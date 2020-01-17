using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReffilBarrel : MonoBehaviour
{
    public float maxAmount;
    private float minAmount;

    void Start()
    {
        minAmount = maxAmount;
    }

    public void RefillKeg(float amount)
    {
        if (minAmount < maxAmount)
        {
            minAmount += amount;
        }
    }
}
