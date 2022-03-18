using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeModuleUI : MonoBehaviour
{
    ChargeModule m_module;
    InputController m_inputController;

    [SerializeField]
    Slider m_chargeSlider;

    [SerializeField]
    Text m_moduleText;

    [SerializeField]
    Button m_activationButton;

    void Start()
    {
        m_inputController = GameObject.Find("InputController").GetComponent<InputController>();
        m_activationButton.interactable = false;
    }

    void Update()
    {
        m_chargeSlider.value = m_module.GetChargePercent();
        m_moduleText.text = m_module.GetName();

        if (m_module.GetCharged() && (m_inputController.GetTargetModule() || m_inputController.GetTargetDroid()))
        {
            m_activationButton.interactable = true;
        }
        else
        {
            m_activationButton.interactable = false;
        }
    }

    public void ActivateModule()
    {
        m_module.Activate();
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
