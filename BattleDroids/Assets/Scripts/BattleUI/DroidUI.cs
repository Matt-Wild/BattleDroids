using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroidUI : MonoBehaviour
{
    Droid m_droid;

    [SerializeField]
    Slider m_healthSlider;

    [SerializeField]
    Text m_nametagText;


    void Update()
    {
        m_healthSlider.value = m_droid.GetIntegrityPercent();
        m_nametagText.text = m_droid.GetName();
    }

    public Droid GetDroid()
    {
        return m_droid;
    }

    public void SetDroid(Droid _droid)
    {
        m_droid = _droid;
    }
}
