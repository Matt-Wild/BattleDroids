using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeModuleUI : MonoBehaviour
{
    ChargeModule m_module;

    [SerializeField]
    Slider m_chargeSlider;

    [SerializeField]
    Text m_moduleText;

    void Update()
    {
        m_chargeSlider.value = m_module.GetChargePercent();
        m_moduleText.text = m_module.GetName();
    }

    public ChargeModule GetModule()
    {
        return m_module;
    }

    public void SetModule(ChargeModule _module)
    {
        m_module = _module;
    }
}
