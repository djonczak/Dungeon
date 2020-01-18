using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour, ILauncher
{
    public RangeWeaponData weaponData;
    public Transform barrelPosition;
    
    public void LaunchProjectile()
    {
        GameObject projectile = ObjectPooler.instance.GetPooledObject(weaponData.projectileName);
        if (projectile != null)
        {
            projectile.transform.position = barrelPosition.position;
            projectile.transform.rotation = barrelPosition.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody>().AddForce(-transform.right * weaponData.projectileSpeed);
            projectile.GetComponent<IPassFloat>().PassFloat(weaponData.weaponDamage);
        }
    }
}
