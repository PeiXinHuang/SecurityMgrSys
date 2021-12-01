using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoControlData : Object
{

    private event UnityAction SendEventEvent;
    private event UnityAction UpdateCanSendUsers;
    private event UnityAction UpdateSendUsers;

    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "sendEventEvent")
            SendEventEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "sendEventEvent")
            SendEventEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }

    //发送用户
    public Dictionary<string, string> sendUserDir = new Dictionary<string, string>();

    public void SendInfo(string sendTitle, string sendContent)
    {
        if (string.IsNullOrEmpty(sendTitle))
        {
            MessageBoxMgr.Instance.ShowWarnning("信息标题不能为空");
            return;
        }

        if (string.IsNullOrEmpty(sendContent))
        {
            MessageBoxMgr.Instance.ShowWarnning("信息内容不能为空");
            return;
        }

        if(sendUserDir.Keys.Count == 0)
        {
            MessageBoxMgr.Instance.ShowWarnning("收件人不能为空");
            return;
        }

        List<string> receiveIds = new List<string>();
        foreach (string key in sendUserDir.Keys)
        {
            receiveIds.Add(key);
        }

        InfoDatabaseMgr.Instance.CreateNewInfos(GameManager.Instance.GetCurrentUser().userId,
            receiveIds, sendTitle, sendContent);

        if (SendEventEvent != null)
            SendEventEvent();

        MessageBoxMgr.Instance.ShowInfo("发送信息成功");
    }

    

    public void UpdateAllCanSendUsers()
    {
        sendUserDir.Clear();
        List<User> users = UserDatabaseMgr.Instance.GetUsersData(new User());
        foreach (User user in users)
        {
            sendUserDir.Add(user.userId, user.userName);
        }

        if (UpdateCanSendUsers != null)
            UpdateCanSendUsers();
    }

}
