using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfInfoView : MonoBehaviour
{

    

    
    public InputField idInput;
    public InputField passwordInput;
    public InputField sexInput;
    public InputField phoneInput;
    public InputField jobInput;
    public InputField userNameInput;
    public Button saveBtn;



    //刷新个人信息用户界面
    public void UpdateContent(User user)
    {
        if (user.isEmptyUser())
        {
            throw new System.Exception("Fail to set self info user Content , because user is null");
        }

        idInput.text = user.userId;
        passwordInput.text = user.password;
        sexInput.text = user.sex;
        phoneInput.text = user.phone;
        jobInput.text = user.JobToString(user.userJob);
        userNameInput.text = user.userName;

     
    }
    
}
