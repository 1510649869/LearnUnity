using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class FPSCounter : MonoBehaviour
{
    float m_fpsMeasurePeriod = 0.5f;
    int m_fpsAccumulator = 0;
    float m_fpsNextPeriod = 0;
    int m_currentFps;
    GUIText m_label;

    void Start()
    {
        m_fpsNextPeriod = Time.realtimeSinceStartup + m_fpsMeasurePeriod;
        m_label = GetComponent<GUIText>();
    }

    void Update()
    {
        // measure average frames per second
        m_fpsAccumulator++;
        if (Time.realtimeSinceStartup > m_fpsNextPeriod)
        {
            m_currentFps = (int)(m_fpsAccumulator / m_fpsMeasurePeriod);
            m_fpsAccumulator = 0;
            m_fpsNextPeriod += m_fpsMeasurePeriod;
            m_label.text = string.Format("FPS : {0}, Characters : {1}", m_currentFps, CharacterMgr.Instance.CharacterCount);
            m_label.fontSize = Screen.height / 14;
            m_label.pixelOffset = new Vector2(2, m_label.fontSize);
        }

    }

}
