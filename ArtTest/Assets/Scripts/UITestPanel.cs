using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UITestPanel : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Transform btnTrans;

        //-- 角色测试按钮
        btnTrans = this.transform.FindChild("BackButton");
        if (btnTrans != null)
        {
            Button btn = btnTrans.gameObject.GetComponent<Button>();
            btn.onClick.AddListener(new UnityAction<Button>(OnBackButtonClick));
        }
    }

    void OnBackButtonClick(Object sender)
    {
        SceneMgr.Instance.ClearTestScene();
        UIPanelManager.Instance.ShowTestPanel(false);
    }
}
