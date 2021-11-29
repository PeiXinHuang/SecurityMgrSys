using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxView : MonoBehaviour
{
    public float showDuration = 1.5f;
    DateTime lastShowTime = DateTime.Now;
    public GameObject infoMessageBoxPrefab;
    public GameObject warnningMessageBoxPrefab;
    public GameObject errorMessageBoxPrefab;

    public RectTransform messageBoxContent;

    public void ShowInfo(string infoText)
    {
        DateTime curTime = DateTime.Now;
        if (GetSubSeconds(lastShowTime, curTime) < 1)
            return;
        GameObject newObj = GameObject.Instantiate(infoMessageBoxPrefab, messageBoxContent);
        newObj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = infoText;
        StartCoroutine(HideMessageBox(newObj));
        lastShowTime = curTime;

    }

    public void ShowWarnning(string warnningText)
    {
        DateTime curTime = DateTime.Now;
        if (GetSubSeconds(lastShowTime, curTime) < 1)
            return;
        GameObject newObj = GameObject.Instantiate(warnningMessageBoxPrefab, messageBoxContent);
        newObj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = warnningText;
        StartCoroutine(HideMessageBox(newObj));
        lastShowTime = curTime;
    }

    public void ShowError(string errorText)
    {
        DateTime curTime = DateTime.Now;
        if (GetSubSeconds(lastShowTime, curTime) < 1)
            return;
        GameObject newObj = GameObject.Instantiate(errorMessageBoxPrefab, messageBoxContent);
        newObj.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = errorText;
        StartCoroutine(HideMessageBox(newObj));
        lastShowTime = curTime;
    }

    IEnumerator HideMessageBox(GameObject messageBox)
    {
        yield return new WaitForSeconds(showDuration);
        DestroyImmediate(messageBox);
    }

    public int GetSubSeconds(DateTime startTimer, DateTime endTimer)
    {
        TimeSpan startSpan = new TimeSpan(startTimer.Ticks);

        TimeSpan nowSpan = new TimeSpan(endTimer.Ticks);

        TimeSpan subTimer = nowSpan.Subtract(startSpan).Duration();

        return (int)subTimer.TotalSeconds;
    }
}
