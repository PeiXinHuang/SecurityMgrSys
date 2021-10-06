using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfInfoView : MonoBehaviour
{
    [Header("登录界面")]
    public Image loginPanel;
    public Button loginBtn;
    public InputField idInput;
    public InputField passwordInput;

    [Header("用户界面")]
    public Image userPanel;

    [Header("用户界面——查看信息")]
    public InputField idCheckInput;
    public InputField passwordCheckInput;
    public InputField sexCheckInput;
    public InputField phoneCheckInput;
    public InputField jobCheckInput;
    public InputField userNameCheckInput;
    public Button logoutBtn;


    [Header("用户界面——修改信息")]
    public InputField idModifyInput;
    public InputField passwordModifyInput;
    public InputField sexModifyInput;
    public InputField phoneModifyInput;
    public InputField jobModifyInput;
    public InputField userNameModifyInput;
    public Button modifyBtn;


    //刷新登录界面，如果已经登录，隐藏登录界面，没有登录，显示登录界面
    public void UpdateSelfInfoContent(User user)
    {
        if (user.isEmptyUser())
            loginPanel.rectTransform.SetAsLastSibling();
        else
            userPanel.rectTransform.SetAsLastSibling();
    }

    //刷新个人信息用户界面
    public void UpdateUserPanel(User user)
    {
        idCheckInput.text = user.userId;
        passwordCheckInput.text = user.password;
        sexCheckInput.text = user.sex;
        phoneCheckInput.text = user.phone;
        jobCheckInput.text = user.JobToString(user.userJob);
        userNameCheckInput.text = user.userName;

        idModifyInput.text = user.userId;
        passwordModifyInput.text = user.password;
        sexModifyInput.text = user.sex;
        phoneModifyInput.text = user.phone;
        jobModifyInput.text = user.JobToString(user.userJob);
        userNameModifyInput.text = user.userName;
    }
    
}
