using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    BattleUI m_battleUI;

    [SerializeField]
    GameObject m_droid;

    void Start()
    {
        m_battleUI = GameObject.Find("BattleUI").GetComponent<BattleUI>();

        m_droid.AddComponent<Droid>();

        m_battleUI.AddDroidUI(m_droid.GetComponent<Droid>());
    }

    private void Update()
    {
        
    }
}
