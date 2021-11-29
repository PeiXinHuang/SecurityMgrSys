using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxMgr : MonoBehaviour
{
    #region µ¥Àý
    private static MessageBoxMgr instance;
    public static MessageBoxMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MessageBoxMgr)FindObjectOfType(typeof(MessageBoxMgr));
                if (instance == null)
                {
                    GameObject MessageBoxMgrObj = new GameObject("MessageBoxMgr");
                    instance = (MessageBoxMgr)MessageBoxMgrObj.AddComponent(typeof(MessageBoxMgr));

                }
                instance.InitMessageBoxMgr();
            }

            return instance;
        }

    }
    #endregion

    private MessageBoxView view;
    public MessageBoxData data;
    public void InitMessageBoxMgr()
    {
        view = (MessageBoxView)FindObjectOfType(typeof(MessageBoxView));
        data = new MessageBoxData();
    }

    public void ShowInfo(string infoText)
    {
        view.ShowInfo(infoText);
    }

    public void ShowWarnning(string warnningText)
    {
        view.ShowWarnning(warnningText);
    }

    public void ShowError(string errorText)
    {
        view.ShowError(errorText);
    }
}
