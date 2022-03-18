using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{
    protected GameObject m_gameObject;
    protected ModuleSelector m_moduleSelector;

    protected string m_name = "Droid";

    protected List<PowerModule> m_powerModules = new List<PowerModule>();
    protected List<ChargeModule> m_chargeModules = new List<ChargeModule>();

    [SerializeField]
    protected float m_durability = 100.0f, m_integrity = 100.0f;

    void Start()
    {
        m_gameObject = gameObject;

        m_moduleSelector = Instantiate(GameObject.Find("PrefabManager").GetComponent<PrefabManager>().m_droidOverlay).GetComponent<ModuleSelector>();
        m_moduleSelector.SetHost(this);
    }

    void Update()
    {
        foreach(ChargeModule _chargeModule in m_chargeModules)
        {
            _chargeModule.Update();
        }
    }

    public void AddPowerModule(PowerModule _powerModule)
    {
        _powerModule.SetHost(this);
        m_powerModules.Add(_powerModule);
    }

    public void AddChargeModule(ChargeModule _chargeModule)
    {
        _chargeModule.SetHost(this);
        m_chargeModules.Add(_chargeModule);
    }

    public float Damage(float _amount)
    {
        m_integrity -= _amount;

        if (m_integrity < 0.0f)
        {
            m_integrity = 0.0f;
        }

        return m_integrity;
    }

    public float Repair(float _amount)
    {
        m_integrity += _amount;

        if (m_integrity > m_durability)
        {
            m_integrity = m_durability;
        }

        return m_integrity;
    }

    public float RepairFull()
    {
        m_integrity = m_durability;

        return m_integrity;
    }

    public GameObject GetGameObject()
    {
        return m_gameObject;
    }

    public ModuleSelector GetModuleSelector()
    {
        return m_moduleSelector;
    }

    public string GetName()
    {
        return m_name;
    }

    public List<PowerModule> GetPowerModules()
    {
        return m_powerModules;
    }

    public List<ChargeModule> GetChargeModules()
    {
        return m_chargeModules;
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

    public float GetIntegrityPercent()
    {
        return m_integrity / m_durability;
    }

    public float GetDurability()
    {
        return m_durability;
    }

    public float GetIntegrity()
    {
        return m_integrity;
    }

    public void SetGameObject(GameObject _gameObject)
    {
        m_gameObject = _gameObject;
    }

    public void SetModuleSelector(ModuleSelector _moduleSelector)
    {
        m_moduleSelector = _moduleSelector;
    }

    public void SetName(string _name)
    {
        m_name = _name;
    }

    public void SetPowerModules(List<PowerModule> _powerModules)
    {
        m_powerModules = _powerModules;
    }

    public void SetChargeModules(List<ChargeModule> _chargeModules)
    {
        m_chargeModules = _chargeModules;
    }

    public void SetDurability(float _durability)
    {
        m_durability = _durability;
    }

    public void SetIntegrity(float _integrity)
    {
        m_integrity = _integrity;
    }
}
