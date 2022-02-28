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

    public void AddDroidUI(Droid _droid)
    {
        GameObject _newDroidUI = Instantiate(m_droidUIPrefab);
        _newDroidUI.transform.SetParent(m_battleCanvas.transform, false);
        _newDroidUI.transform.localScale = new Vector3(1, 1, 1);

        Vector3 _newPosition = _newDroidUI.transform.position;
        _newPosition.x = -110 * m_droidUIs.Count + 1000;
        _newDroidUI.transform.position = _newPosition;

        DroidUI _newDroidUIScript = _newDroidUI.GetComponent<DroidUI>();
        _newDroidUIScript.SetDroid(_droid);

        m_droidUIs.Add(_newDroidUIScript);
    }
}
