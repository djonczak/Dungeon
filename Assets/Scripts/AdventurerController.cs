using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    private AdventurerCombat adventurerCombat;

    private void Start()
    {
        adventurerCombat = GetComponent<AdventurerCombat>();
    }

    void Update()
    {
        if (Input.GetButtonDown("AttackButton"))
        {
            Debug.Log("Zaatakował");
            adventurerCombat.DoAttack();
        }
    }
}
