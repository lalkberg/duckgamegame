using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    internal WeaponType WeaponType;

    virtual public void Shoot(int level)
    {

    }
}

public enum WeaponType
{
    Hammer, Hookshot, AirCannon, MagnetLauncher
}
