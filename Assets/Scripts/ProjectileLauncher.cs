using UnityEngine;

public class ProjectileLauncher : MonoBehaviour, ILauncher
{
    public RangeWeaponData WeaponData;
    public Transform BarrelPosition;
    
    public void LaunchProjectile()
    {
        GameObject projectile = ObjectPooler.instance.GetPooledObject(WeaponData.ProjectileName);
        if (projectile != null)
        {
            projectile.transform.position = BarrelPosition.position;
            projectile.transform.rotation = BarrelPosition.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody>().AddForce(-transform.right * WeaponData.ProjectileSpeed);
            projectile.GetComponent<IPassFloat>().PassFloat(WeaponData.WeaponDamage);
        }
    }
}
