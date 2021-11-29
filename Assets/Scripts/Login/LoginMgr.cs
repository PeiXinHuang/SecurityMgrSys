using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr : MonoBehaviour
{
    private static LoginMgr instance;
    public static LoginMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (LoginMgr)FindObjectOfType(typeof(LoginMgr));
                if (instance == null)
                {
                    GameObject LoginMgrObj = new GameObject("LoginMgr");
                    instance = (LoginMgr)LoginMgrObj.AddComponent(typeof(LoginMgr));

                }
                instance.InitSelfInfoMgr();
            }

            return instance;
        }

    }

    private LoginView view;
    public LoginData data;
    public void InitSelfInfoMgr()
    {

        view = (LoginView)FindObjectOfType(typeof(LoginView));
        data = new LoginData();

        AddEventHander();
    }



    /// <summary>
    /// 添加事件处理
    /// </summary>
    private void AddEventHander()
    {
        view.loginBtn.onClick.AddListener(OnClickLoginBtn);
        view.exitBtn.onClick.AddListener(ExitApp);

        //登录成功，隐藏登陆界面,基础面板根据登录用户的权限进行刷新,并且显示当前登录用户
        //详情面板显示个人信息，用户个人信息面板刷新
        data.AddEventListener("loginSuccessEvent", LoginMgr.Instance.HideLoginPanel);
        data.AddEventListener("loginSuccessEvent", BaseMgr.Instance.UpdateUserPanel);
        data.AddEventListener("loginSuccessEvent", BaseMgr.Instance.UpdateListPanel);
        data.AddEventListener("loginSuccessEvent", BaseMgr.Instance.UpdateContentPanel);
        data.AddEventListener("loginSuccessEvent", SelfInfoMgr.Instance.UpdateContent);

        

    }

    private void OnClickLoginBtn()
    {
        data.Login(view.userIdInput.text,view.passwordInput.text);
    }



    public void ShowLoginPanel()
    {
        view.ShowLoginPanel();
    }

    public void HideLoginPanel()
    {
        view.HideLoginPanel();
   
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
