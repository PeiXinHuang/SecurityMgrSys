using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelfInfoData:Object
{
 
    private event UnityAction UpdateUserEvent; //ˢ���û��¼�

    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateUserEvent")
            UpdateUserEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateUserEvent")
            UpdateUserEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }



    /// <summary>
    /// �޸ĸ�����Ϣ
    /// </summary>
    public void SaveData(string password, string phone)
    {
        User currentUser = GameManager.Instance.GetCurrentUser();
        if (!GameManager.Instance.HasSetUser())
        {
            throw new System.Exception("Fail to get current user, because current user is null");
        }

   
      

        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("���벻��Ϊ��");
            return;
        }

        currentUser.password = password;
        currentUser.phone = phone;
      

        UserDatabaseMgr.Instance.UpdateUserData(currentUser);
        GameManager.Instance.SetCurrentUser(currentUser);

        if (UpdateUserEvent != null)
            UpdateUserEvent();
    }
}
