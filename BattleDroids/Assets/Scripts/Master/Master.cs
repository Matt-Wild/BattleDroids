using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    BattleUI m_battleUI;

    [SerializeField]
    GameObject m_friendlyDroid, m_enemyDroid;

    void Start()
    {
        m_battleUI = GameObject.Find("BattleUI").GetComponent<BattleUI>();

        m_friendlyDroid.AddComponent<Droid>();
        Droid _droid = m_friendlyDroid.GetComponent<Droid>();
        _droid.AddChargeModule(ScriptableObject.CreateInstance<ChargeModule>());
        ChargeModule _newModule = ScriptableObject.CreateInstance<ChargeModule>();
        _newModule.SetName("Module 2");
        _droid.AddChargeModule(_newModule);

        _droid.AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        _droid.AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        _droid.AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());

        m_battleUI.AddDroidUI(_droid);

        m_enemyDroid.AddComponent<Droid>();
    }

    private void Update()
    {
        
    }
}
