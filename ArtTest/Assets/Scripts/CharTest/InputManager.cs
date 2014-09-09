using UnityEngine;
using System.Collections;

// 处理所有的用户输入操作
public class InputManager : MonoBehaviour
{
    Plane m_groundPlane;

    // Use this for initialization
    void Start()
    {
        m_groundPlane = new Plane(Vector3.up, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch tch = Input.touches[0];
            if (Input.touchCount==1
                && tch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(tch.position);
                float rayDistance;
                if (m_groundPlane.Raycast(ray, out rayDistance))
                    CharacterMgr.Instance.SpawnCharacter(ray.GetPoint(rayDistance));
            }
            else if (Input.touchCount>=2
                && tch.phase == TouchPhase.Moved)
            {
                Vector2 offset = tch.deltaPosition;
                Vector3 cameraPan = new Vector3(offset.x, 0, offset.y);
                Camera.main.transform.Translate(cameraPan);
            }
        }
    }

}
