using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleSelector : MonoBehaviour
{
    List<OverlayModule> m_moduleElements = new List<OverlayModule>();

    GameObject m_canvas;
    Droid m_host;
    Image m_foregroundImage;

    [SerializeField]
    GameObject m_modulesBackground, m_modulesForeground;

    void Awake()
    {
        m_canvas = gameObject;
        m_foregroundImage = m_modulesForeground.GetComponent<Image>();
        Disable();
    }

    void Update()
    {
        if (m_host.GetIntegrity() == 0.0f)
        {
            m_foregroundImage.enabled = false;
        }
        else
        {
            m_foregroundImage.enabled = true;
        }
    }

    void UpdateUI()
    {
        List<PowerModule> _powerModules = m_host.GetPowerModules();
        List<ChargeModule> _chargeModules = m_host.GetChargeModules();

        ClearModules();

        Vector3 _newScale = new Vector3(1.0f, 1.0f, 1.0f);
        Vector2 _backgroundSize = new Vector2(10.0f, 100.0f);
        foreach(PowerModule _powerModule in _powerModules)
        {
            _backgroundSize.x += 90.0f;

            OverlayModule _moduleElement = Instantiate(GameObject.Find("PrefabManager").GetComponent<PrefabManager>().m_moduleElement).GetComponent<OverlayModule>();
            _moduleElement.SetModule(_powerModule);
            _moduleElement.gameObject.transform.SetParent(m_modulesBackground.transform);
            _moduleElement.transform.localScale = _newScale;
            m_moduleElements.Add(_moduleElement);
        }

        foreach(ChargeModule _chargeModule in _chargeModules)
        {
            _backgroundSize.x += 90.0f;

            OverlayModule _moduleElement = Instantiate(GameObject.Find("PrefabManager").GetComponent<PrefabManager>().m_moduleElement).GetComponent<OverlayModule>();
            _moduleElement.SetModule(_chargeModule);
            _moduleElement.gameObject.transform.SetParent(m_modulesBackground.transform);
            _moduleElement.transform.localScale = _newScale;
            m_moduleElements.Add(_moduleElement);
        }

        Vector3 _newPosition = new Vector3(-(_backgroundSize.x / 2) + 50, 0.0f, 0.0f);
        foreach(OverlayModule _moduleElement in m_moduleElements)
        {
            _moduleElement.transform.localPosition = _newPosition;
            _newPosition.x += 90.0f;
        }

        m_modulesBackground.GetComponent<RectTransform>().sizeDelta = _backgroundSize;
        m_modulesForeground.GetComponent<RectTransform>().sizeDelta = _backgroundSize;
    }

    void ClearModules()
    {
        foreach(OverlayModule _module in m_moduleElements)
        {
            Destroy(_module.gameObject);
        }

        m_moduleElements = new List<OverlayModule>();
    }

    public void Enable()
    {
        UpdateUI();

        m_canvas.SetActive(true);
    }

    public void Disable()
    {
        m_canvas.SetActive(false);
    }

    public Droid GetHost()
    {
        return m_host;
    }

    public void SetHost(Droid _droid)
    {
        m_host = _droid;
        GameObject _droidGameObject = m_host.GetGameObject();
        Vector3 _position = _droidGameObject.transform.position;
        _position.y += _droidGameObject.GetComponent<Collider>().bounds.size.y;
        m_canvas.transform.position = _position;
    }
}
