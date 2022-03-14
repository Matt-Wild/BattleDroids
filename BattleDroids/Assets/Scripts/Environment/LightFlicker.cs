using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    bool m_flickering = false;
    float m_delay;

    Light m_light;

    [SerializeField]
    float m_flickerOnRate = 0.1f, m_flickerOffRate = 0.1f;

    void Start()
    {
        m_light = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        if (m_flickering == false)
        {
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        m_flickering = true;
        m_light.enabled = false;
        m_delay = Random.Range(0.0f, m_flickerOffRate);
        yield return new WaitForSeconds(m_delay);
        m_light.enabled = true;
        m_delay = Random.Range(0.0f, m_flickerOnRate);
        yield return new WaitForSeconds(m_delay);
        m_flickering = false;
    }
}
