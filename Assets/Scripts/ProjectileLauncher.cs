using UnityEngine;

namespace Adventurer.Player
{

    public class ProjectileLauncher : MonoBehaviour, ILauncher
    {
        public Weapon.RangeWeaponData WeaponData
        {
            set => _weaponData = value;
        }
        public Transform BarrelPosition;

        private Weapon.RangeWeaponData _weaponData;
        public void LaunchProjectile()
        {
            GameObject projectile = ObjectPooler.instance.GetPooledObject(_weaponData.ProjectileName);
            if (projectile != null)
            {
                projectile.transform.position = BarrelPosition.position;
                projectile.transform.rotation = BarrelPosition.rotation;
                projectile.SetActive(true);
                projectile.GetComponent<Rigidbody>().AddForce(-transform.right * _weaponData.ProjectileSpeed);
                projectile.GetComponent<IPassFloat>().PassFloat(_weaponData.WeaponDamage);
            }
        }
    }
}
