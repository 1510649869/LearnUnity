using UnityEngine;
using System.Collections;

// 控制一些应用程序的全局变量
public class ApplicationMgr : MonoBehaviour
{
    GameObject m_globals;

    void Start()
    {
        m_globals = this.gameObject;
        GameObject.DontDestroyOnLoad(m_globals);

        //Application.targetFrameRate = 30;
    }

}
