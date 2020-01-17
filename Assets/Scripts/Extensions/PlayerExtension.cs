using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerExtension
{
    public static GameObject GetPlayerObject()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
