using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour
{
  public Text tId,tType,tName,tState,bDate,rDate,uId,uName;

  public Image bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8;

  [Header ("被选中时的颜色（如#FFFFFF）")] 
  public string selectedColorStr;
  private Color selectedColor;
  //private bool ifSelected = false;
  public void ChangeText(string[] tool)
  {
    tId.text = tool[0];
    tName.text = tool[1];
    tType.text = tool[2];
    tState.text = tool[3];
    bDate.text = tool[4];
    rDate.text = tool[5];
    uId.text = tool[6];
    uName.text = tool[7];
  }

  public void ClickItem(){
    ToolControlMgr.Instance.GetSelected(int.Parse(name));
  }

  public void Selected(bool ifSelected)
  {
    if (ifSelected)
    {
      ColorUtility.TryParseHtmlString(selectedColorStr, out selectedColor);
    }
    else{
      ColorUtility.TryParseHtmlString("#FFFFFF", out selectedColor);
    }
    bg1.color = selectedColor;
    bg2.color = selectedColor;
    bg3.color = selectedColor;
    bg4.color = selectedColor;
    bg5.color = selectedColor;
    bg6.color = selectedColor;
    bg7.color = selectedColor;
    bg8.color = selectedColor;
  }



}
