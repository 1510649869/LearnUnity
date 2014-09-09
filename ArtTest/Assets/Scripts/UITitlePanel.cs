using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UITitlePanel : MonoBehaviour
{
    void Start()
    {
        Transform btnTrans;

        //-- 角色测试按钮
        btnTrans = this.transform.FindChild("CharTestButton");
        if (btnTrans != null)
        {
            Button btn = btnTrans.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(new UnityAction<Button>(OnCharTestButtonClick));
        }

        //-- 场景测试按钮
        btnTrans = this.transform.FindChild("SceneTestButton");
        if (btnTrans != null)
        {
            Button btn = btnTrans.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(new UnityAction<Button>(OnSceneTestButtonClick));
        }
    }

    void OnCharTestButtonClick(Object sender)
    {
        Debug.Log("Loading Character Test Scene...");
        Application.LoadLevel("CharTest");
        this.gameObject.SetActive(false);
    }

    void OnSceneTestButtonClick(Object sender)
    {
        Debug.Log("Loading Scene Test Scene...");
        Application.LoadLevel("SceneTest");
        this.gameObject.SetActive(false);
    }

}
