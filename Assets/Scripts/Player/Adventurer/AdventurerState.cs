using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerState : MonoBehaviour
{
    [SerializeField] private bool _isMelee;
    [SerializeField] bool _isAiming;

    public AdventurerData playerData;

    public void SetWeaponState(bool state)
    {
        _isMelee = state;
    }

    public void SetAimingState(bool state)
    {
        _isAiming = state;
    }

    public bool ReturnWeponState()
    {
        return _isMelee;
    }

    public bool ReturnAimingState()
    {
        return _isAiming;
    }
}
