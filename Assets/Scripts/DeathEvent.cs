using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public delegate void EnemyEventHandler(int id);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(int i)
    {
        if(OnEnemyDeath != null)
        {
            OnEnemyDeath(i);
        }
    }
}
