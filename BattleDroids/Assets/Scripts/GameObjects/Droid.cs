using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : Destructible
{
    protected GameObject m_gameObject;

    protected string m_name = "Droid";

    protected List<PowerModule> m_powerModules = new List<PowerModule>();

    private void Start()
    {
        m_gameObject = gameObject;
    }

    public void AddPowerModule(PowerModule _powerModule)
    {
        _powerModule.SetHost(this);
        m_powerModules.Add(_powerModule);
    }

    public GameObject GetGameObject()
    {
        return m_gameObject;
    }

    public string GetName()
    {
        return m_name;
    }

    public List<PowerModule> GetPowerModules()
    {
        return m_powerModules;
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

    public void SetGameObject(GameObject _gameObject)
    {
        m_gameObject = _gameObject;
    }

    public void SetName(string _name)
    {
        m_name = _name;
    }

    public void SetPowerModules(List<PowerModule> _powerModules)
    {
        m_powerModules = _powerModules;
    }
}
