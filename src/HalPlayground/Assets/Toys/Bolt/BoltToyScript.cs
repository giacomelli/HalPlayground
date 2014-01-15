using UnityEngine;
using System.Collections;

public class BoltToyScript : MonoBehaviour
{
    #region Campos
    private GameObject m_frontBolt;
    private GameObject m_middleBolt;
    private GameObject m_backBolt;
    #endregion

    private void Start()
    {
        m_frontBolt = GameObject.Find("FrontBoltPrefab");
        m_middleBolt = GameObject.Find("MiddleBoltPrefab");
        m_backBolt = GameObject.Find("BackBoltPrefab");
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height - 65, 200, 65));

        if (GUILayout.Button("On/Off front bolt"))
        {
            ChangeBoltState(m_frontBolt);               
        }

        if (GUILayout.Button("On/Off middle bolt"))
        {
            ChangeBoltState(m_middleBolt);
        }

        if (GUILayout.Button("On/Off back bolt"))
        {
            ChangeBoltState(m_backBolt);
        }

        GUILayout.EndArea();
    }

    private void ChangeBoltState(GameObject bolt)
    {
        bolt.SetActiveRecursively(!bolt.active);
    }
}
