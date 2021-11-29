using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoginData:Object
{

    private event UnityAction LoginSuccessEvent; //刷新用户事件

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
    /// 登录
    /// </summary>
    /// <param name="userId">用户id</param>
    /// <param name="password">用户密码</param>
    public void Login(string userId, string password)
    {
        if (string.IsNullOrEmpty(userId))
        {
            MessageBoxMgr.Instance.ShowWarnning("用户名不能为空");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            MessageBoxMgr.Instance.ShowWarnning("密码不能为空");
            return;
        }


        if (!UserDatabaseMgr.Instance.ChargeUserExit(userId)) //用户不存在
        {
            MessageBoxMgr.Instance.ShowError("用户不存在");
            return;
        }
        else
        {
            User user = UserDatabaseMgr.Instance.GetUserDataById(userId);
            if (user.password != password)
            {
                MessageBoxMgr.Instance.ShowError("密码错误");
                return;
            }
            GameManager.Instance.SetCurrentUser(user);

        }

        if (GameManager.Instance.HasSetUser())
            LoginSuccessEvent();

        MessageBoxMgr.Instance.ShowInfo("登录成功");
    }
}
