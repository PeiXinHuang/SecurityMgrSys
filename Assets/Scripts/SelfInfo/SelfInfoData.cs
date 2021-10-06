using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelfInfoData:Object
{
    private User currentUser = new User(); //当前的用户对象,null表示未登录

    private event UnityAction<User> updateUser; //刷新用户事件

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
    /// 登录
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="password">用户密码</param>
    public void Login(string userId,string password)
    {
        if (string.IsNullOrEmpty(userId))
        {
            Debug.Log("用户名不能为空");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("密码不能为空");
            return;
        }
        

        if (!UserDatabaseMgr.Instance.ChargeUserExit(userId)) //用户不存在
        {

            Debug.Log("用户不存在");
            return;
        }
        else
        {
            User user = UserDatabaseMgr.Instance.GetUserData(userId);
            if(user.password != password)
            {
                Debug.Log("密码错误");
                return;
            }
            currentUser = user;
           
        }

        if (updateUser != null)
            updateUser(currentUser);

    }

    /// <summary>
    /// 注销账号
    /// </summary>
    public void Logout()
    {
        currentUser = new User();
        if (updateUser != null)
            updateUser(currentUser);
    }

    /// <summary>
    /// 获取当前用户
    /// </summary>
    /// <returns>当前用户</returns>
    public User GetCurrentUser()
    {
        return currentUser;
    }

    /// <summary>
    /// 修改个人信息
    /// </summary>
    public void Modify(string username,string password, string phone)
    {

        if (currentUser.isEmptyUser())
            Debug.LogError("Modify Fail, current user is null");

        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("用户名不可以为空");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("密码不能为空");
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
