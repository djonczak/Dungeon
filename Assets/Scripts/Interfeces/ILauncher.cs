using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILauncher
{
    void LaunchProjectile(string projectileName, float projectileSpeed, float damage);
}
