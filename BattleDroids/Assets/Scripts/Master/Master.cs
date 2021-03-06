using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    BattleUI m_battleUI;
    List<Droid> m_droids = new List<Droid>();

    [SerializeField]
    GameObject m_friendlyDroid1, m_friendlyDroid2, m_friendlyDroid3, m_enemyDroid1, m_enemyDroid2, m_enemyDroid3;

    [SerializeField]
    Vector3 m_withdrawPosition;

    void Start()
    {
        m_battleUI = GameObject.Find("BattleUI").GetComponent<BattleUI>();

        m_friendlyDroid1.AddComponent<Droid>();
        m_friendlyDroid2.AddComponent<Droid>();
        m_friendlyDroid3.AddComponent<Droid>();

        m_friendlyDroid1.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_friendlyDroid1.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_friendlyDroid2.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_friendlyDroid2.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_friendlyDroid3.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_friendlyDroid3.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_battleUI.AddDroidUI(m_friendlyDroid1.GetComponent<Droid>());
        m_battleUI.AddDroidUI(m_friendlyDroid2.GetComponent<Droid>());
        m_battleUI.AddDroidUI(m_friendlyDroid3.GetComponent<Droid>());

        m_enemyDroid1.AddComponent<Droid>();
        m_enemyDroid2.AddComponent<Droid>();
        m_enemyDroid3.AddComponent<Droid>();
        m_enemyDroid1.GetComponent<Droid>().SetEnemy(true);
        m_enemyDroid2.GetComponent<Droid>().SetEnemy(true);
        m_enemyDroid3.GetComponent<Droid>().SetEnemy(true);

        m_enemyDroid1.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_enemyDroid1.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_enemyDroid2.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_enemyDroid2.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_enemyDroid3.GetComponent<Droid>().AddPowerModule(ScriptableObject.CreateInstance<PowerModule>());
        m_enemyDroid3.GetComponent<Droid>().AddChargeModule(ScriptableObject.CreateInstance<CuntPunt>());

        m_droids.Add(m_friendlyDroid1.GetComponent<Droid>());
        m_droids.Add(m_friendlyDroid2.GetComponent<Droid>());
        m_droids.Add(m_friendlyDroid3.GetComponent<Droid>());
        m_droids.Add(m_enemyDroid1.GetComponent<Droid>());
        m_droids.Add(m_enemyDroid2.GetComponent<Droid>());
        m_droids.Add(m_enemyDroid3.GetComponent<Droid>());
    }

    public Vector3 GetWithdrawPosition()
    {
        return m_withdrawPosition;
    }
}
