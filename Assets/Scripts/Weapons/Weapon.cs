using System;
using UnityEngine;
public abstract class Weapon : MonoBehaviour
{
    public int AvailableAmmo {  get; set; }

    public Weapon(int AvailableAmmo)
    {
        this.AvailableAmmo = AvailableAmmo;
    }

    public void UseWeapon()
    {
        // bazowa implementacja
        Console.Write("Pif Paf");
    }

    public abstract void Sound();
}