using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
    void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }
}
