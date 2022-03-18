using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuntPunt : DamageModule
{
    protected override void OnEnable()
    {
        base.OnEnable();
        m_name = "Cunt Punt";
        m_icon = Resources.Load<Texture2D>("Textures/Modules/cuntPunt");
        m_damage = 1000.0f;
    }

    public override void Activate()
    {
        base.Activate();
    }
}
