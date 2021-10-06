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
        view.loginBtn.onClick.AddListener(OnClickLogin);
        view.logoutBtn.onClick.AddListener(OnClickLogout);
        view.modifyBtn.onClick.AddListener(OnClickModify);

        //用户登录或注销的时候，刷新基础面板的用户面板和选项列表  
        data.AddEventListener("updateUserEvent", BaseMgr.Instance.UpdateListPanel);
        data.AddEventListener("updateUserEvent", BaseMgr.Instance.UpdateUserPanel);  

        //刷新个人信息面板
        data.AddEventListener("updateUserEvent", view.UpdateSelfInfoContent);
        data.AddEventListener("updateUserEvent", view.UpdateUserPanel);


    }


    private void OnClickLogin()
    {
        data.Login(view.idInput.text, view.passwordInput.text);
    }

    private void OnClickLogout()
    {
        data.Logout();
    }

    private void OnClickModify()
    {
        data.Modify(view.userNameModifyInput.text,view.passwordModifyInput.text,view.phoneModifyInput.text);
    }
}
