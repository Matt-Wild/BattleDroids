using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuntPunt : ChargeModule
{
    protected float m_damage = 100.0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_name = "Cunt Punt";
        m_icon = Resources.Load<Texture2D>("Textures/Modules/cuntPunt");
    }

    public override void Activate()
    {
        base.Activate();

        Module _target = GameObject.Find("InputController").GetComponent<InputController>().GetTargetModule();
        _target.Damage(m_damage);
    }
}
