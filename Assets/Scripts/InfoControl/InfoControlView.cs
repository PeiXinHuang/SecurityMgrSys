using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoControlView : MonoBehaviour
{
    [Header("发送邮件相关")]
    public InputField sendTitleInput;
    public InputField sendContentInput;
    public InputField sendUserInput;
    public Dropdown sendDropdown;
    public Button sendButton;

    public void UpdateSendDropDown()
    {

    }

    public void UpdateSendUserInput(string str)
    {
        sendUserInput.text = str;
    }

    public void ResetSendPanel()
    {
        sendUserInput.text = "";
        sendContentInput.text = "";
        sendTitleInput.text = "";
        sendDropdown.value = 0;
    }

    public void ResetReceivePanel()
    {

    }
}
