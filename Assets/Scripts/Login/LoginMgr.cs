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
    /// ����¼�����
    /// </summary>
    private void AddEventHander()
    {
        view.loginBtn.onClick.AddListener(OnClickLoginBtn);

        //��¼�ɹ������ص�½����,���������ݵ�¼�û���Ȩ�޽���ˢ��,������ʾ��ǰ��¼�û�
        //���������ʾ������Ϣ���û�������Ϣ���ˢ��
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
}
