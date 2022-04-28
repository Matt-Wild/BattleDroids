using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    bool m_rising = true;
    float m_currentSpeed = 0.0f;
    float m_stopDistance = 0.0f;

    Vector3 m_originalPos;

    [SerializeField] float m_amount = 1.0f, m_speed = 1.0f;

    void Start()
    {
        m_originalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (m_rising)
        {
            if (m_currentSpeed < m_speed)
            {
                m_currentSpeed += m_speed * Time.deltaTime;
            }
            else
            {
                m_currentSpeed = m_speed;
            }

            Vector3 currentPos = gameObject.transform.position;
            if (currentPos.y - m_originalPos.y > m_amount)
            {
                m_rising = false;
            }

            currentPos.y += m_currentSpeed * Time.deltaTime;
            gameObject.transform.position = currentPos;
        }
        else
        {
            if (-m_currentSpeed < m_speed)
            {
                m_currentSpeed -= m_speed * Time.deltaTime;
            }
            else
            {
                m_currentSpeed = -m_speed;
            }

            Vector3 currentPos = gameObject.transform.position;
            if (currentPos.y < m_originalPos.y + m_stopDistance)
            {
                m_rising = true;
                m_stopDistance = 0.0f;
            }
            else
            {
                currentPos.y += m_currentSpeed * Time.deltaTime;
                gameObject.transform.position = currentPos;
                float currentStopDistance = currentPos.y - (m_originalPos.y + m_amount);
                if (currentStopDistance > m_stopDistance)
                {
                    m_stopDistance = currentStopDistance;
                }
            }
        }
    }
}
