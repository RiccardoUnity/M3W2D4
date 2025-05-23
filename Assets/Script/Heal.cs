using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PickUpChangeLife
{
    public int healAmount;

    void Awake()
    {
        healAmount = (healAmount > 0) ? 5 : healAmount;
        SetChangeLife(healAmount);
    }
}
