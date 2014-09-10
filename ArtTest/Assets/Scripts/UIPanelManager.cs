using UnityEngine;
using System.Collections;

public class UIPanelManager : MonoBehaviour
{
    private static UIPanelManager s_instance;

    private UITestPanel m_testPanel;
    private UITitlePanel m_titlePanel;

    public static UIPanelManager Instance
    {
        get { return s_instance; }
    }

    void Awake()
    {
        s_instance = this;
    }

    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.Find("TestPanel");
        if(obj != null)
            m_testPanel = obj.GetComponent<UITestPanel>();
        obj = GameObject.Find("TitlePanel");
        if (obj != null)
            m_titlePanel = obj.GetComponent<UITitlePanel>();

        ShowTestPanel(false);
    }

    public void ShowTestPanel(bool viz)
    {
        m_testPanel.gameObject.SetActive(viz);
    }

    public void ShowTitlePanel(bool viz)
    {
        m_titlePanel.gameObject.SetActive(viz);
    }
}
