using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelfInfoData:Object
{
    private User currentUser = new User(); //��ǰ���û�����,null��ʾδ��¼

    private event UnityAction<User> updateUser; //ˢ���û��¼�

    public void AddEventListener(string eventName, UnityAction<User> function)
    {
        if (eventName == "updateUserEvent")
            updateUser += function;
    }
    public void RemoveEventListener(string eventName, UnityAction<User> function)
    {
        if (eventName == "updateUserEvent")
            updateUser -= function;
    }



    /// <summary>
    /// ��¼
    /// </summary>
    /// <param name="userId">�û�id</param>
    /// <param name="password">�û�����</param>
    public void Login(string userId,string password)
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
            User user = UserDatabaseMgr.Instance.GetUserData(userId);
            if(user.password != password)
            {
                Debug.Log("�������");
                return;
            }
            currentUser = user;
           
        }

        if (updateUser != null)
            updateUser(currentUser);

    }

    /// <summary>
    /// ע���˺�
    /// </summary>
    public void Logout()
    {
        currentUser = new User();
        if (updateUser != null)
            updateUser(currentUser);
    }

    /// <summary>
    /// ��ȡ��ǰ�û�
    /// </summary>
    /// <returns>��ǰ�û�</returns>
    public User GetCurrentUser()
    {
        return currentUser;
    }

    /// <summary>
    /// �޸ĸ�����Ϣ
    /// </summary>
    public void Modify(string username,string password, string phone)
    {

        if (currentUser.isEmptyUser())
            Debug.LogError("Modify Fail, current user is null");

        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("�û���������Ϊ��");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("���벻��Ϊ��");
            return;
        }

        currentUser.userName = username;
        currentUser.password = password;
        currentUser.phone = phone;
      

        UserDatabaseMgr.Instance.UpdateUserData(currentUser);

        if (updateUser != null)
            updateUser(currentUser);
    }
}
