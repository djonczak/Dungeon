using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public delegate void EnemyEventHandler(int id);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(int i)
    {
        OnEnemyDeath?.Invoke(i);
    }
}
