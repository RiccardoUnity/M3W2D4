using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : PickUpChangeLife
{
    public int damage;

    void Awake()
    {
        damage = (damage < 0) ? -5 : damage;
        SetChangeLife(damage);
    }


}
