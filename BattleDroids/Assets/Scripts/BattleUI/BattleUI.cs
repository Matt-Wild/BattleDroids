using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    List<DroidUI> m_droidUIs = new List<DroidUI>();
    GameObject m_battleCanvas;

    [SerializeField]
    GameObject m_droidUIPrefab;

    void Start()
    {
        m_battleCanvas = gameObject;
    }

    void Update()
    {
        foreach (DroidUI _droidUI in m_droidUIs)
        {
            if (_droidUI.GetDroid().GetWithdrawn())
            {
                m_droidUIs.Remove(_droidUI);
                Destroy(_droidUI.gameObject);
                UpdateUIPosition();
                break;
            }
        }
    }

    public void UpdateUIPosition()
    {
        float _xAdj = 0.0f;

        foreach (DroidUI _droidUI in m_droidUIs)
        {
            Vector3 _newPosition = _droidUI.gameObject.transform.localPosition;
            _newPosition.x = _xAdj + (Screen.width / 2) - 60;
            _droidUI.gameObject.transform.localPosition = _newPosition;

            _xAdj -= 110.0f;
        }
    }

    public void AddDroidUI(Droid _droid)
    {
        GameObject _newDroidUI = Instantiate(m_droidUIPrefab);
        _newDroidUI.transform.SetParent(m_battleCanvas.transform, false);
        _newDroidUI.transform.localScale = new Vector3(1, 1, 1);

        DroidUI _newDroidUIScript = _newDroidUI.GetComponent<DroidUI>();
        _newDroidUIScript.SetDroid(_droid);

        m_droidUIs.Add(_newDroidUIScript);

        UpdateUIPosition();
    }
}
