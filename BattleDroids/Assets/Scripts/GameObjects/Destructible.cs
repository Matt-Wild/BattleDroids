using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    protected int m_durability = 100, m_integrity = 100;

    public int Damage(int _amount)
    {
        m_integrity -= _amount;

        if (m_integrity < 0)
        {
            m_integrity = 0;
        }

        return m_integrity;
    }

    public int Repair(int _amount)
    {
        m_integrity += _amount;

        if (m_integrity > m_durability)
        {
            m_integrity = m_durability;
        }

        return m_integrity;
    }

    public int RepairFull()
    {
        m_integrity = m_durability;

        return m_integrity;
    }

    public float GetIntegrityPercent()
    {
        return (float)m_integrity / (float)m_durability;
    }

    public int GetDurability()
    {
        return m_durability;
    }

    public int GetIntegrity()
    {
        return m_integrity;
    }

    public void SetDurability(int _durability)
    {
        m_durability = _durability;
    }

    public void SetIntegrity(int _integrity)
    {
        m_integrity = _integrity;
    }
}
