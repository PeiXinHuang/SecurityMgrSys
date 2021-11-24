using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 个人信息管理类
/// </summary>
public class SelfInfoMgr : MonoBehaviour
{
    // 实现单例模式访问数据库
    private static SelfInfoMgr instance;
    public static SelfInfoMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SelfInfoMgr)FindObjectOfType(typeof(SelfInfoMgr));
                if (instance == null)
                {
                    GameObject databaseMgrObj = new GameObject("SelfInfoMgr");
                    instance = (SelfInfoMgr)databaseMgrObj.AddComponent(typeof(SelfInfoMgr));

                }
                instance.InitSelfInfoMgr();
            }

            return instance;
        }

    }


    private SelfInfoView view;
    public SelfInfoData data;
    public void InitSelfInfoMgr()
    {

        view = (SelfInfoView)FindObjectOfType(typeof(SelfInfoView));
        data = new SelfInfoData();

        AddEventHander();
    }



    /// <summary>
    /// 添加事件处理
    /// </summary>
    private void AddEventHander()
    {

        //绑定按钮事件
        view.saveBtn.onClick.AddListener(OnClickSave);


        //刷新个人信息面板
        data.AddEventListener("updateUserEvent", SelfInfoMgr.Instance.UpdateContent);


    }

    private void OnClickSave()
    {
        //data.Modify(view.userNameModifyInput.text,view.passwordModifyInput.text,view.phoneModifyInput.text);
    }


    public void UpdateContent()
    {
        view.UpdateContent(GameManager.Instance.GetCurrentUser());
    }
}
