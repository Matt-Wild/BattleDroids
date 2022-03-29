using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{
    protected bool m_withdrawn = false;
    protected bool m_targeted = false;

    protected GameObject m_gameObject;
    protected ModuleSelector m_moduleSelector;
    protected PrefabManager m_prefabManager;

    protected string m_name = "Droid";

    protected List<PowerModule> m_powerModules = new List<PowerModule>();
    protected List<ChargeModule> m_chargeModules = new List<ChargeModule>();

    [SerializeField]
    protected float m_durability = 100.0f, m_integrity = 100.0f;

    void Start()
    {
        m_gameObject = gameObject;
        m_prefabManager = GameObject.Find("PrefabManager").GetComponent<PrefabManager>();

        m_moduleSelector = Instantiate(m_prefabManager.m_droidOverlay).GetComponent<ModuleSelector>();
        m_moduleSelector.SetHost(this);
        m_moduleSelector.gameObject.transform.SetParent(gameObject.transform);
    }

    void Update()
    {
        foreach(ChargeModule _chargeModule in m_chargeModules)
        {
            _chargeModule.Update();
        }

        if (!m_withdrawn)
        {
            if (GetPowerIntegrity() == 0.0f)
            {
                SetWithdrawn(true);
            }
        }
    }

    public void Detarget()
    {
        m_targeted = false;

        foreach (PowerModule _module in m_powerModules)
        {
            _module.SetTargeted(false);
        }

        foreach (ChargeModule _module in m_chargeModules)
        {
            _module.SetTargeted(false);
        }
    }

    public void Teleport(Vector3 _pos)
    {
        m_gameObject.transform.position = _pos;
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

    public void SpawnPopup(float _value)
    {
        GameObject _popup = Instantiate(m_prefabManager.m_damagePopup);
        _popup.GetComponent<DamagePopup>().SetValue(_value);
    }

    public float Damage(float _amount)
    {
        SpawnPopup(_amount);

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

    public float GetPowerIntegrity()
    {
        float _total = 0.0f;

        foreach (PowerModule _module in m_powerModules)
        {
            _total += _module.GetIntegrity();
        }

        return _total;
    }

    public bool GetWithdrawn()
    {
        return m_withdrawn;
    }

    public bool GetTargeted()
    {
        return m_targeted;
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

    public void SetWithdrawn(bool _withdrawn)
    {
        m_withdrawn = _withdrawn;

        if (m_withdrawn)
        {
            Detarget();
            Teleport(GameObject.Find("Master").GetComponent<Master>().GetWithdrawPosition());
        }
    }

    public void SetTargeted(bool _targeted)
    {
        m_targeted = _targeted;
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
