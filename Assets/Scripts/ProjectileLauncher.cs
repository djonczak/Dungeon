using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour, ILauncher
{
    public Transform barrelPosition;
    
    public void LaunchProjectile(string name, float projectileSpeed, float projectileDamage)
    {
        GameObject projectile = ObjectPooler.instance.GetPooledObject(name);
        if (projectile != null)
        {
            projectile.transform.position = barrelPosition.position;
            projectile.transform.rotation = barrelPosition.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody>().AddForce(-transform.right * projectileSpeed);
            projectile.GetComponent<IPassFloat>().PassFloat(projectileDamage);
        }
    }
}
