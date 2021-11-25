using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class User : Object
{
    // 用户类型
    public enum UserJob
    {
        None, //未设置
        Member, // 安检员
        Admin, // 安检管理员
        SysAdmin //系统管理员
    }

    public string userId; //用户ID
    public string userName; //用户名
    public string password; //密码
    public UserJob userJob; // 用户类型
    public string sex; //性别
    public string phone; //电话号码

    /// <summary>
    /// 初始化用户
    /// </summary>
    public void InitUser(string _userId, string _userName, UserJob _userJob,
        string _sex, string _phone = null, string _password = "123456")
    {
        this.userId = _userId;
        this.userName = _userName;
        this.password = _password;
        this.userJob = _userJob;
        this.sex = _sex;
        this.phone = _phone;
    }


    public string JobToString(UserJob userJob)
    {
        switch (userJob)
        {
            case UserJob.Member:
                return "Member";
            case UserJob.Admin:
                return "Admin";
            case UserJob.SysAdmin:
                return "SysAdmin";
            default:
                return "";
        }

    }

    public string JobToChinese(UserJob userJob)
    {
        switch (userJob)
        {
            case UserJob.Member:
                return "安检员";
            case UserJob.Admin:
                return "安检管理员";
            case UserJob.SysAdmin:
                return "系统管理员";
            default:
                return "";
        }
    }

    public UserJob StringToJob(string userJob)
    {
        switch (userJob)
        {
            case "Member":
                return UserJob.Member;
            case "Admin":
                return UserJob.Admin;
            case "SysAdmin":
                return UserJob.SysAdmin;
            default:
                return UserJob.Member;
        }
    }

    public bool isEmptyUser()
    {
        return string.IsNullOrEmpty(userId);
    }

#if UNITY_EDITOR 
    public void DebugInfo()
    {
        Debug.Log(
            "userId: " + this.userId + "\t" +
            "userName: " + this.userName + "\t" +
            "userSex: " + this.sex + "\t" +
            "job" + this.JobToString(this.userJob) + "\t" +
            "userPhone: " + this.phone + "\t" +
            "password" + this.password
            );
    }
#endif
}
