using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(Random.insideUnitSphere.x, Random.insideUnitSphere.y, 0f) * 0.5f, 2f);
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

}
