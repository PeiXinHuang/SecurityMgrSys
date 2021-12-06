using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoControlView : MonoBehaviour
{
    [Header("接受信息相关")]
    public RectTransform receiveTran;
    public GameObject receiveItemPrefab;
    public Text receiveName;
    public Text receiveTitle;
    public Text receiveContent;
    public Image receiveSpace;
   
    [Header("发送信息相关")]
    public InputField sendTitleInput;
    public InputField sendContentInput;
    public InputField sendUserInput;
    public Dropdown sendDropdown;
    public Button sendButton;

    [Header("历史发送信息相关")]
    public RectTransform histroyTran;
    public GameObject histroyItemPrefab;
    public Text histroyName;
    public Text histroyTitle;
    public Text histroyContent;
    public Image histroySpace;

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
        receiveName.text = "";
        receiveSpace.gameObject.SetActive(false);
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
            string title = info.infoTitle;
            string sendId = info.sendId;
            string sendName = UserDatabaseMgr.Instance.GetUserDataById(sendId).userName;
            if (string.IsNullOrEmpty(sendName))
                sendName = "已注销";
            newItem.transform.GetChild(1).GetComponent<Text>().text = title;
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowReceiveInfos(info.infoTitle, info.infoContent,string.Format("{0}({1})", sendId,sendName)));
        }

        
    }

    public void ShowReceiveInfos(string title,string content,string sendName)
    {
        receiveName.text = "发件人:" + sendName;
        receiveTitle.text = title;
        receiveContent.text = content;
        receiveSpace.gameObject.SetActive(true);
    }

    public void ResetHistroyPanel()
    {
        histroyTitle.text = "";
        histroyContent.text = "";
        histroyName.text = "";
        histroySpace.gameObject.SetActive(false);
        int childCount = histroyTran.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(histroyTran.GetChild(i).gameObject);
        }

        string currentUserId = GameManager.Instance.GetCurrentUser().userId;
        List<Info> infos = InfoDatabaseMgr.Instance.GetInfosBySendId(currentUserId);

        foreach (var info in infos)
        {
            GameObject newItem = Instantiate(histroyItemPrefab, histroyTran);
            string title = info.infoTitle;
            string receiveId = info.receiveId;
            string receiveName = UserDatabaseMgr.Instance.GetUserDataById(receiveId).userName;
            if (string.IsNullOrEmpty(receiveName))
                receiveName = "已注销";
            newItem.transform.GetChild(1).GetComponent<Text>().text = title;
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowHistroyInfos(info.infoTitle, info.infoContent, string.Format("{0}({1})", receiveId, receiveName)));
        }



    }

    public void ShowHistroyInfos(string title, string content, string receiveName)
    {
        histroyName.text = "收件人:" + receiveName;
        histroyTitle.text = title;
        histroyContent.text = content;
        histroySpace.gameObject.SetActive(true);
    }
}
