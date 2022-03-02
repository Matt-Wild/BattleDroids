using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroidUI : MonoBehaviour
{
    Droid m_droid;
    GameObject m_droidCanvas;
    List<ChargeModuleUI> m_chargeModuleUIs = new List<ChargeModuleUI>();

    [SerializeField]
    Slider m_healthSlider;

    [SerializeField]
    Text m_nametagText;

    [SerializeField]
    GameObject m_chargeModuleUIPrefab;

    void Awake()
    {
        m_droidCanvas = gameObject;
    }

    void Update()
    {
        m_healthSlider.value = m_droid.GetIntegrityPercent();
        m_nametagText.text = m_droid.GetName();
    }

    public void UpdateChargeModuleUI()
    {
        foreach(ChargeModule _module in m_droid.GetChargeModules())
        {
            AddChargeModuleUI(_module);
        }
    }

    public void AddChargeModuleUI(ChargeModule _chargeModule)
    {
        GameObject _newChargeModuleUI = Instantiate(m_chargeModuleUIPrefab);
        _newChargeModuleUI.transform.SetParent(m_droidCanvas.transform, false);
        _newChargeModuleUI.transform.localScale = new Vector3(1, 1, 1);

        Vector3 _newPosition = _newChargeModuleUI.transform.position;
        _newPosition.y = 15 * m_chargeModuleUIs.Count + 65;
        _newChargeModuleUI.transform.position = _newPosition;

        ChargeModuleUI _newChargeModuleUIScript = _newChargeModuleUI.GetComponent<ChargeModuleUI>();
        _newChargeModuleUIScript.SetModule(_chargeModule);

        m_chargeModuleUIs.Add(_newChargeModuleUIScript);
    }

    public Droid GetDroid()
    {
        return m_droid;
    }

    public void SetDroid(Droid _droid)
    {
        m_droid = _droid;

        UpdateChargeModuleUI();
    }
}
