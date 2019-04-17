using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBoost : ActiveItemTemplate
{

    // Use this for initialization
    private void Awake()
    {
        howLong = 50;
        cdTime = 200;
    }

    public override void use()
    {
        p.shotDelay = p.shotDelay / 4;
    }

    public override void revert()
    {
        p.shotDelay = p.shotDelay * 4;
    }

}
