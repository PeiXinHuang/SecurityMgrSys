using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoControlView : MonoBehaviour
{
    [Header("接受邮件相关")]
    public RectTransform receiveTran;
    public GameObject receiveItemPrefab;
    public Text receiveTitle;
    public Text receiveContent;

    [Header("发送邮件相关")]
    public InputField sendTitleInput;
    public InputField sendContentInput;
    public InputField sendUserInput;
    public Dropdown sendDropdown;
    public Button sendButton;



    public void UpdateSendDropDown(List<string> list)
    {
        sendDropdown.ClearOptions();
        sendDropdown.AddOptions(list);
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
        receiveTitle.text = "";
        receiveContent.text = "";
        int childCount = receiveTran.childCount;
        for (int i = childCount-1; i >= 0; i--)
        {
            DestroyImmediate(receiveTran.GetChild(i).gameObject);
        }

        string currentUserId = GameManager.Instance.GetCurrentUser().userId;
        List<Info> infos = InfoDatabaseMgr.Instance.GetInfosByReveiveId(currentUserId);

        foreach (var info in infos)
        {
            GameObject newItem = Instantiate(receiveItemPrefab, receiveTran);
            string sendId = info.sendId;
            string sendName = UserDatabaseMgr.Instance.GetUserDataById(sendId).userName;
            newItem.transform.GetChild(1).GetComponent<Text>().text = string.Format("{0}({1})", sendId, sendName);
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowReceiveInfos(info.infoTitle, info.infoContent));
        }
    }

    public void ShowReceiveInfos(string title,string content)
    {
        receiveTitle.text = title;
        receiveContent.text = content;
    }
}
