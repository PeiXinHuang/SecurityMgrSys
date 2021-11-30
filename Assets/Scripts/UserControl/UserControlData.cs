using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserControlData : Object
{
    private UnityAction SearchUsersEvent;
    private UnityAction AddUserEvent;
    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "SearchUsersEvent")
            SearchUsersEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "SearchUsersEvent")
            SearchUsersEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }

    #region 查找用户相关

    private string searchUserName = "";
    private string searchId = "";
    private string searchSex = "";
    private User.UserJob searchJob = User.UserJob.None;

    public void SetSearchUserName(string name)
    {
        this.searchUserName = name;
    }
    public void SetSearchId(string id)
    {
        this.searchId = id;
    }
    public void SetSearchSex(int sex)
    {

        switch (sex)
        {
            case 0: this.searchSex = ""; break;
            case 1: this.searchSex = "男"; break;
            case 2: this.searchSex = "女"; break;
        }
    }
    public void SetSearchJob(int job)
    {
       
        switch (job)
        {
            case 0: this.searchJob = User.UserJob.None;break;
            case 1: this.searchJob = User.UserJob.Member;break;
            case 2: this.searchJob = User.UserJob.Admin;break;
            case 3: this.searchJob = User.UserJob.SysAdmin;break;
        }
    }


    private List<User> users = new List<User>();

    public List<User> GetUsers()
    {
        return users;
    }

    

    public void Search()
    {
        users.Clear();
        User conditionUser = new User();
        conditionUser.userId = this.searchId;
        conditionUser.userName = this.searchUserName;
        conditionUser.sex = this.searchSex;
        conditionUser.userJob = this.searchJob;

        users = UserDatabaseMgr.Instance.GetUsersData(conditionUser);

        if (SearchUsersEvent != null)
            SearchUsersEvent();

        MessageBoxMgr.Instance.ShowInfo("查找成功");
    }
    #endregion

    #region 添加用户相关
    public void AddUser(string userId, string userName,string phone,string password, int sexId,int jobId)
    {

        if (string.IsNullOrEmpty(userId))
        {
            MessageBoxMgr.Instance.ShowWarnning("请输入新用户账号");
            return;
        }

        if (string.IsNullOrEmpty(userName))
        {
            MessageBoxMgr.Instance.ShowWarnning("请输入新用户名称");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBoxMgr.Instance.ShowWarnning("请输入新用户密码");
            return;
        }

        User addUser = new User();
        addUser.userId = userId;
        addUser.userName = userName;
        addUser.phone = phone;
        addUser.password = password;
        switch (sexId)
        {
            case 0: addUser.sex = "男";break;
            case 1: addUser.sex = "女";break;
        }
        switch (jobId)
        {
            case 0: addUser.userJob = User.UserJob.Member; break;
            case 1: addUser.userJob = User.UserJob.Admin; break;
            case 2: addUser.userJob = User.UserJob.SysAdmin; break;
          
        }

        UserDatabaseMgr.Instance.InsertUserData(addUser);
        MessageBoxMgr.Instance.ShowInfo("创建用户成功");
        UserControlMgr.Instance.ResetAddUserPanel();

    }
    #endregion

    #region 修改用户相关
    public void ModifyUser(string userId, string userName, string phone, string password, int sexId, int jobId)
    {

        if (string.IsNullOrEmpty(userId))
        {
            MessageBoxMgr.Instance.ShowWarnning("用户账号为空");
            return;
        }

        if (string.IsNullOrEmpty(userName))
        {
            MessageBoxMgr.Instance.ShowWarnning("请输入用户名称");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            MessageBoxMgr.Instance.ShowWarnning("请输入用户密码");
            return;
        }

        User addUser = new User();
        addUser.userId = userId;
        addUser.userName = userName;
        addUser.phone = phone;
        addUser.password = password;
        switch (sexId)
        {
            case 0: addUser.sex = "男"; break;
            case 1: addUser.sex = "女"; break;
        }
        switch (jobId)
        {
            case 0: addUser.userJob = User.UserJob.Member; break;
            case 1: addUser.userJob = User.UserJob.Admin; break;
            case 2: addUser.userJob = User.UserJob.SysAdmin; break;

        }

        UserDatabaseMgr.Instance.UpdateUserData(addUser);
        MessageBoxMgr.Instance.ShowInfo("修改用户信息成功");
    }
    #endregion
}
