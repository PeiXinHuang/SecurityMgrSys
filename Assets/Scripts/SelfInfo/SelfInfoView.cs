using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfInfoView : MonoBehaviour
{

    [Header("�û�����")]
    public Image userPanel;

    [Header("�û����桪���鿴��Ϣ")]
    public InputField idCheckInput;
    public InputField passwordCheckInput;
    public InputField sexCheckInput;
    public InputField phoneCheckInput;
    public InputField jobCheckInput;
    public InputField userNameCheckInput;
    public Button logoutBtn;


    [Header("�û����桪���޸���Ϣ")]
    public InputField idModifyInput;
    public InputField passwordModifyInput;
    public InputField sexModifyInput;
    public InputField phoneModifyInput;
    public InputField jobModifyInput;
    public InputField userNameModifyInput;
    public Button modifyBtn;



    //ˢ�¸�����Ϣ�û�����
    public void UpdateContent(User user)
    {
        if (user.isEmptyUser())
        {
            throw new System.Exception("Fail to set self info user Content , because user is null");
        }

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
