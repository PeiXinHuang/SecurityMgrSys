using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessDatabaseMgr : MonoBehaviour
{
    [Header("数据库配置")]
    public string serverIp = "localhost"; // 服务器地址
    public string userId = "root"; // 用户Id
    public string password = "root"; //用户密码
    public string databaseName = "sysDatabase"; // 数据库名称
    public string port = "3306"; // 端口号
    public string charSet = "utf8"; // 编码格式

    private MySqlConnection conn; //数据库连接对象 //数据库连接对象错误

    // 实现单例模式访问数据库
    private static BusinessDatabaseMgr instance;
    public static BusinessDatabaseMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BusinessDatabaseMgr)FindObjectOfType(typeof(BusinessDatabaseMgr));
                if (instance == null)
                {
                    GameObject BusinessDatabaseMgrObj = new GameObject("BusinessDatabaseMgr");
                    instance = (BusinessDatabaseMgr)BusinessDatabaseMgrObj.AddComponent(typeof(BusinessDatabaseMgr));
                }
                instance.InitDatabaseMgr();
            }
            return instance;
        }
    }


    /// <summary>
    /// 初始化数据库控制器
    /// </summary>
    private void InitDatabaseMgr()
    {
        //实例化数据库连接对象
        conn = new MySqlConnection(
            "Server = " + serverIp + ";" +
            "User Id = " + userId + ";" +
            "Password = " + password + ";" +
            "Database = " + databaseName + ";" +
            "Port = " + port + ";" +
            "CharSet = " + charSet + ";"
            );

    }


    /// <summary>
    /// 获取所有安检业务
    /// </summary>
    public List<Business> GetAllBusinesses()
    {
        List<Business> businesses = new List<Business>();
        return businesses;
    }
}
