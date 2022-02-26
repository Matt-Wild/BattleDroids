using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Destructible
{
    protected List<PowerModule> m_powerModules = new List<PowerModule>();

    public void AddPowerModule(PowerModule _powerModule)
    {
        _powerModule.SetHost(this);
        m_powerModules.Add(_powerModule);
    }

    public float GetPowerOuput()
    {
        float _totalOutput = 0.0f;

        foreach (PowerModule _module in m_powerModules)
        {
            _totalOutput += _module.GetPowerOutput();
        }

        return _totalOutput;
    }
}
