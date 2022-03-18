using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageModule : ChargeModule
{
    protected float m_damage = 10.0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_name = "Damage Module";
        m_icon = Resources.Load<Texture2D>("Textures/Modules/cuntPunt");
    }

    public override void Activate()
    {
        base.Activate();

        float _damage = m_damage * GetIntegrityPercent();

        InputController _inputController = GameObject.Find("InputController").GetComponent<InputController>();
        Module _targetModule = _inputController.GetTargetModule();
        Droid _targetDroid = _inputController.GetTargetDroid();

        if (_targetModule)
        {
            _targetModule.Damage(_damage);
        }
        else if (_targetDroid)
        {
            _targetDroid.Damage(_damage);
        }
    }
}
