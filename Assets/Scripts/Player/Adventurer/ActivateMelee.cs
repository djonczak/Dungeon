using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    public MeleeWeaponData weaponData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            GetComponentInParent<IPlaySound>().AttackSound();
            DoAttack(other);
        }
    }

    public void DoAttack(Collider target)
    {
        target.GetComponent<IDamage>().TakeDamage(weaponData.weaponDamage, transform.parent.position);
    }
}

