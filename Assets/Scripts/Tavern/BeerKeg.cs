using UnityEngine;
using UnityEngine.UI;

public class BeerKeg : MonoBehaviour
{
    public Image beerAmount;

    public float minAmount = 0f;
    [SerializeField] private float maxAmount = 400f;

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
    }

    public void FillKeg(float amount)
    {
        if(minAmount < maxAmount)
        {
            minAmount += amount;
            beerAmount.fillAmount = minAmount / maxAmount;
        }
    }
}
