using UnityEngine;
using System.Collections;

// 角色管理器
// 负责生成角色
public class CharacterMgr : MonoBehaviour
{
    public static CharacterMgr Instance;
    Transform m_charParent;
    Object m_charPrefab;
    int m_charCount = 0;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        m_charParent = GameObject.Find("Characters").transform;
        m_charPrefab = Resources.Load("char");

        //-- 默认就生成一些角色
        const int W = 3;
        const int H = 3;
        const int SPACE = 10;
        for (int y = 0; y < H; y++)
        {
            for (int x = 0; x < W; x++)
            {
                Vector3 pos = new Vector3(x * SPACE, 0, y * SPACE);
                SpawnCharacter(pos);
            }
        }// end of for

    }

    // 生成一个对象
    public void SpawnRandomCharacter()
    {
        //-- 在一个随机的位置，生成一个对象
        const float R = 10;
        Vector2 rand = Random.insideUnitCircle;
        Vector3 pos = new Vector3(rand.x*R, 0, rand.y*R);

        SpawnCharacter(pos);
    }

    public void SpawnCharacter(Vector3 pos)
    {
        GameObject newChar = GameObject.Instantiate(m_charPrefab, pos, Quaternion.identity) as GameObject;

        //-- 设置对象的父子关系
        newChar.transform.parent = m_charParent;

        //-- 更新计数器
        m_charCount++;
    }

    public int CharacterCount
    {
        get { return m_charCount; }
    }
}
