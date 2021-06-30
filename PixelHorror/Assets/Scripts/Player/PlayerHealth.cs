using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthComponent
{
    protected override void TookDamage()
    {
        throw new System.NotImplementedException();
        //UpdateUI
    }

    protected override void Die()
    {
        base.Die();
    }
}
