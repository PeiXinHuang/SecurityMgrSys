using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  游戏控制器
/// </summary>
public class GameManager : MonoBehaviour
{


    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (instance == null)
                {
                    GameObject GameManagerObj = new GameObject("GameManager");
                    instance = (GameManager)GameManagerObj.AddComponent(typeof(GameManager));

                }

            }

            return instance;
        }

    }

    public Image loginView;
    public Image ListView;
    public Image DetailView;
    public List<Image> DetailContentViews;

    private User currentUser = null; 
    public void SetCurrentUser(User user)
    {
        currentUser = user;
    }
    public User GetCurrentUser()
    {
        return currentUser;
    }
    public bool HasSetUser()
    {
        return !string.IsNullOrEmpty(currentUser.userId);
    }


    private void Awake()
    {
        loginView.gameObject.SetActive(true);
        ListView.gameObject.SetActive(true);
        DetailView.gameObject.SetActive(true);
        foreach (Image image in DetailContentViews)
        {
            image.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 程序入口
    /// </summary>
    private void Start()
    {
        InitGame();
    }


    

    /// <summary>
    /// 初始化游戏
    /// </summary>
    private void InitGame()
    {

        //创建基础对象
        LoginMgr loginMgr = LoginMgr.Instance; //登录界面管理器
        BaseMgr baseMgr = BaseMgr.Instance; //基础界面管理器
        UserControlMgr userControlMgr = UserControlMgr.Instance; //用户管理管理器
        InfoControlMgr infoContriolMgr = InfoControlMgr.Instance; //信息管理管理器 
        BusinessControlMgr businessControlMgr = BusinessControlMgr.Instance; //安检业务管理管理器 


        //第一次打开，显示登录面板
        LoginMgr.Instance.ShowLoginPanel();
    }


 
}
