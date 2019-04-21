using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerController : MonoBehaviour
{
    private AdventurerCombat adventurerCombat;
    private AdventurerState state;

    private void Start()
    {
        adventurerCombat = GetComponent<AdventurerCombat>();
        state = GetComponent<AdventurerState>();
    }

    void Update()
    {
        if (state.isAlive == true)
        {
            if (Input.GetButtonDown("AttackButton"))
            {
                adventurerCombat.DoAttack();
            }
        }
    }
}
