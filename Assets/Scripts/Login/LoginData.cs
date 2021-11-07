using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoginData:Object
{

    private event UnityAction LoginSuccessEvent; //ˢ���û��¼�

    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "loginSuccessEvent")
            LoginSuccessEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "loginSuccessEvent")
            LoginSuccessEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }




    /// <summary>
    /// ��¼
    /// </summary>
    /// <param name="userId">�û�id</param>
    /// <param name="password">�û�����</param>
    public void Login(string userId, string password)
    {
        if (string.IsNullOrEmpty(userId))
        {
            Debug.Log("�û�������Ϊ��");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("���벻��Ϊ��");
            return;
        }


        if (!UserDatabaseMgr.Instance.ChargeUserExit(userId)) //�û�������
        {

            Debug.Log("�û�������");
            return;
        }
        else
        {
            User user = UserDatabaseMgr.Instance.GetUserDataById(userId);
            if (user.password != password)
            {
                Debug.Log("�������");
                return;
            }
            GameManager.Instance.SetCurrentUser(user);

        }

        if (GameManager.Instance.HasSetUser())
            LoginSuccessEvent();

    }
}
