using UnityEngine;
using System.Collections;

public class SceneName
{
    public static string CharTest = "CharTest";
    public static string StaticMeshTest = "SceneTest";
}

public class SceneMgr : MonoBehaviour
{
    static private SceneMgr s_instance;
    public Scene m_currentScene;

    static public SceneMgr Instance
    {
        get { return s_instance; }
    }
    void Awake()
    {
        s_instance = this;
        m_currentScene = null;
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log(string.Format("Load Scene {0} ...", sceneName));
        Application.LoadLevel(sceneName);

        UIPanelManager.Instance.ShowTitlePanel(false);
        UIPanelManager.Instance.ShowTestPanel(true);
    }

    public void ClearTestScene()
    {
        Application.LoadLevel("Empty");
        UIPanelManager.Instance.ShowTitlePanel(true);
        UIPanelManager.Instance.ShowTestPanel(false);
    }
}
