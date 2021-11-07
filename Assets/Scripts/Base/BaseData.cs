using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseData:Object
{
    /// <summary>
    /// ��ǰ��ʾ�����
    /// </summary>
    public enum ContentType
    {
        SelfInfo,
        BusinessControl,
        UserControl,
        InfoControl
        
    }

    //Ĭ����ʾ�û����
    private ContentType currentSelectContent = ContentType.SelfInfo;

    private event UnityAction UpdateContentEvent;


    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateContentEvent")
            UpdateContentEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateContentEvent")
            UpdateContentEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }


    public ContentType GetCurrentSelectContent()
    {
        return this.currentSelectContent;
    }

    public void SetCurrentSelectContent(ContentType contentType)
    {
        currentSelectContent = contentType;

        if (UpdateContentEvent != null)
            UpdateContentEvent();
    }
}
