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
        InfoControl
    }

    private ContentType currentSelectContent = ContentType.SelfInfo;

    private event UnityAction<ContentType> updateContent;


    public void AddEventListener(string eventName, UnityAction<ContentType> function)
    {
        if (eventName == "updateContent")
            updateContent += function;
    }
    public void RemoveEventListener(string eventName, UnityAction<ContentType> function)
    {
        if (eventName == "updateContent")
            updateContent -= function;
    }


    public ContentType GetCurrentSelectContent()
    {
        return this.currentSelectContent;
    }

    public void SetCurrentSelectContent(ContentType contentType)
    {
        currentSelectContent = contentType;

        if (updateContent != null)
            updateContent(currentSelectContent);
    }
}
