using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    float m_timer = 0.0f;

    [SerializeField]
    GameObject m_value;

    [SerializeField]
    float m_speed = 1.5f, m_duration = 2.0f;

    void Update()
    {
        Vector3 _newPos = gameObject.transform.position;
        _newPos.y += m_speed * Time.deltaTime;

        gameObject.transform.position = _newPos;

        m_timer += Time.deltaTime;

        if (m_timer >= m_duration)
        {
            Destroy(gameObject);
        }
    }

    public void SetValue(float _value)
    {
        int _valueInt = (int)_value;

        m_value.GetComponent<TextMeshProUGUI>().text = _valueInt.ToString();
    }
}
