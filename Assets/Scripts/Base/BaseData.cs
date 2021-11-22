using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseData:Object
{
    /// <summary>
    /// 当前显示的面板
    /// </summary>
    public enum ContentType
    {
        SelfInfo,
        BusinessControl,
        UserControl,
        InfoControl,
        ToolControl
        
    }

    //默认显示用户面板
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
