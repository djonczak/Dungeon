using UnityEngine;

namespace Adventurer.Player
{
    public class ActivateMelee : MonoBehaviour
    {
        private Weapon.MeleeWeaponData _weaponData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 10)
            {
                GetComponentInParent<IPlaySound>().AttackSound();
                DoAttack(other);
            }
        }

        private void DoAttack(Collider target)
        {
            target.GetComponent<IDamage>().TakeDamage(_weaponData.WeaponDamage, transform.parent.position);
        }

        public void SetWeapon(Weapon.MeleeWeaponData data)
        {
            _weaponData = data;
        }
    }
}

