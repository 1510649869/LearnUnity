using UnityEngine;
using System.Collections;

// 处理所有的用户输入操作
public class InputManager : MonoBehaviour
{
    //-- 拖动操作控制变量
    bool m_draging = false;
    Vector3 m_lastDragPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 1 || Input.GetMouseButtonDown(1))
        {
            CharacterMgr.Instance.SpawnRandomCharacter();
        }
        else
        {
            // 拖动操作 - 移动摄像机
            dragMainCamera();
        }
    }

    void dragMainCamera()
    {
        //-- 检测是否在拖动操作
        if (Input.GetMouseButtonDown(0))
        {
            m_draging = true;
            m_lastDragPos = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_draging = false;
        }

        //-- 根据拖动位移，来移动摄像机
        if (m_draging)
        {
            Vector3 offset = Input.mousePosition - m_lastDragPos;
            m_lastDragPos = Input.mousePosition;
            Vector3 cameraPan = new Vector3(offset.x, 0, offset.y);
            Camera.main.transform.Translate(cameraPan);
        }
    }
}
