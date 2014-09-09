using UnityEngine;
using System.Collections;

// 角色控制器 - 每个角色包含一个实例
// 控制角色在一个矩形区域内，随机行走
public class CharacterCtroller : MonoBehaviour
{
    enum EState
    {
        Stand,
        Walk,
    }
    EState m_state;
    float m_stateStartTime;
    float m_stateDuration;
    Vector3 m_walkForward;
    Animation m_anim;

    // Use this for initialization
    void Start()
    {
        m_state = EState.Stand;
        m_stateDuration = 0;
        m_stateStartTime = Time.realtimeSinceStartup;

        Transform mesh = this.transform.FindChild("mesh");
        m_anim = mesh.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float stateTime = Time.realtimeSinceStartup;
        if (stateTime - m_stateStartTime >= m_stateDuration)
        {
            RandState();
        }

        if (m_state == EState.Walk)
            UpdateWalk();
    }

    void RandState()
    {
        int r = Random.Range(0, 3);
        if (r == 2)
        {
            m_state = EState.Stand;
            m_anim.CrossFade("idle");
        }
        else
        {
            m_state = EState.Walk;
            m_walkForward = Random.insideUnitSphere;
            m_walkForward.y = 0;
            m_walkForward.Normalize();
            m_anim.CrossFade("run");
            
            //-- 设置旋转角度
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, m_walkForward);
            this.transform.rotation = rot;

        }

        m_stateDuration = (float)Random.Range(1, 5);
        m_stateStartTime = Time.realtimeSinceStartup;
    }

    void UpdateWalk()
    {
        const float SPEED = 5;

        float dt = Time.deltaTime;
        Vector3 offset = m_walkForward * (dt*SPEED);
        this.transform.Translate(offset, Space.World);
    }
}
