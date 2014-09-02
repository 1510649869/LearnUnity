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

    // Use this for initialization
    void Start()
    {
        m_state = EState.Stand;
        m_stateDuration = 0;
        m_stateStartTime = Time.realtimeSinceStartup;
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
            m_state = EState.Stand;
        else
        {
            const float SPEED = 8;
            m_state = EState.Walk;
            m_walkForward = Random.insideUnitSphere;
            m_walkForward.y = 0;
            m_walkForward *= SPEED;
        }

        m_stateDuration = (float)Random.Range(1, 5);
        m_stateStartTime = Time.realtimeSinceStartup;
    }

    void UpdateWalk()
    {
        float dt = Time.deltaTime;
        Vector3 offset = m_walkForward * dt;
        this.transform.Translate(offset);
    }
}
