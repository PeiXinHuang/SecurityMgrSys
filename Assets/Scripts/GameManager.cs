using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  游戏控制器
/// </summary>
public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        InitGame();
    }

    /// <summary>
    /// 初始化游戏
    /// </summary>
    private void InitGame()
    {

        //创建基础对象
        BaseMgr baseMgr = BaseMgr.Instance; //基础界面管理对象
        SelfInfoMgr selfInfoMgr = SelfInfoMgr.Instance; //个人信息界面管理对象

        //刷新基础面板
        BaseMgr.Instance.UpdateListPanel(SelfInfoMgr.Instance.data.GetCurrentUser());
        BaseMgr.Instance.UpdateUserPanel(SelfInfoMgr.Instance.data.GetCurrentUser());
        BaseMgr.Instance.UpdateContentPanel(BaseMgr.Instance.data.GetCurrentSelectContent());
    }


    //测试代码
    private void TextCode()
    {
        //User user = new User();
        //user.InitUser("000001", "用户A", "********", UserType.Member);

        //User user = new User();
        //user.InitUser("00002", "李四", User.UserJob.Admin, "男", "12312212123", "888888");
        //UserDatabaseMgr.Instance.InsertUserData(user);
    }
}
