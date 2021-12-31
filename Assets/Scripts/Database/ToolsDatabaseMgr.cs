using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsDatabaseMgr : MonoBehaviour
{
  [Header("数据库配置")]
  public string serverIp = "localhost"; // 服务器地址
  public string userId = "root"; // 用户Id
  public string password = "root"; //用户密码
  public string databaseName = "sysDatabase"; // 数据库名称
  public string port = "3306"; // 端口号
  public string charSet = "utf8"; // 编码格式
  [SerializeField] public Tool tool252555;

  private MySqlConnection conn; //数据库连接对象 //数据库连接对象错误

  // 实现单例模式访问数据库
  private static ToolsDatabaseMgr instance;
  public static ToolsDatabaseMgr Instance
  {
    get
    {
      if (instance == null)
      {
        instance = (ToolsDatabaseMgr)FindObjectOfType(typeof(ToolsDatabaseMgr));
        if (instance == null)
        {
          GameObject ToolsDatabaseMgrObj = new GameObject("ToolsDatabaseMgr");
          instance = (ToolsDatabaseMgr)ToolsDatabaseMgrObj.AddComponent(typeof(ToolsDatabaseMgr));
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

  // 增删改数据
  public void ChangeData(string _sql)
  {
    try
    {
      conn.Open();
      string sql = _sql;
      Debug.Log("insert sql: " + sql);
      //执行插入语句
      MySqlCommand command = conn.CreateCommand();
      command.CommandText = sql;
      command.ExecuteNonQuery();

    }
    catch (System.Exception e)
    {
      Debug.LogError("改变信息数据失败 " + e.ToString());
    }
    finally
    {
      conn.Close();
    }
  }

  public List<Tool> GetToolData(string type = "tId", bool asc = true)
  {
    string order = "ASC";
    if (!asc)
    {
      order = "DESC";
    }

    List<Tool> newTools = new List<Tool>();
    try
    {
      conn.Open();
      string sql = string.Format("select * from sysdatabase.tools order By {0} {1};", type, order);

      //执行查询语句，并将查询到的数据返回到reader中
      MySqlCommand command = new MySqlCommand(sql, conn);
      MySqlDataReader reader = command.ExecuteReader();
      Debug.Log("search sql: " + sql);

      while (reader.Read())
      {
        Tool newTool = new Tool();
        newTool.tId = (int)reader[0];
        newTool.tName = reader[1].ToString();
        newTool.tType = reader[2].ToString();
        newTool.tStatus = (int)reader[3];
        newTool.bDate = reader[4].ToString();
        newTool.rDate = reader[5].ToString();
        newTool.uName = reader[6].ToString();
        newTool.uId = reader[7].ToString();
        tool252555 = newTool;
        newTools.Add(newTool);
      }


    }
    catch (System.Exception e)
    {
      Debug.LogError("查询tools表失败" + e.ToString());
    }
    finally
    {
      conn.Close();
    }
    return newTools;
  }

  public void AddTool(string toolName, string toolType)
  {
    string sql = string.Format("insert into tools(tName,tType) values('{0}','{1}')", toolName, toolType);
    ChangeData(sql);
  }

  public void BorrowTool(string uId, string uName, int toolId)
  {
    string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
    Debug.Log(uId);
    //数据库更新语句
    string sql = string.Format("Update tools Set bDate='{0}',rDate=null,uId='{1}',uName='{2}',tStatus=1 where tId={3}; ",
      nowTime, uId, uName, toolId
    );
    ChangeData(sql);
  }

  public void ReturnTool(int toolId)
  {
    string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
    //数据库更新语句
    string sql = string.Format("Update tools Set rDate='{0}',tStatus=0,uId=null,uName=null where tId={1}; ",
      nowTime, toolId
    );
    ChangeData(sql);
  }

  public void LostTool(int toolId)
  {
    string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
    //数据库更新语句
    string sql = string.Format("Update tools Set tStatus=2,rDate='{0}' where tId={1};",nowTime,toolId);
    ChangeData(sql);
  }

  public int CheckToolStatus(int tId)
  {
    try
    {
      conn.Open();
      string sql = string.Format("select tStatus from sysdatabase.tools where tId={0}", tId);
      //执行查询语句，并将查询到的数据返回到reader中
      MySqlCommand command = new MySqlCommand(sql, conn);
      MySqlDataReader reader = command.ExecuteReader();
      Debug.Log("search sql: " + sql);

      int result = -1;
      while (reader.Read())
      {
        result = (int)reader[0];
      }

      return result;
    }
    catch (System.Exception e)
    {
      Debug.LogError("查询tools表失败" + e.ToString());
      return -1;
    }
    finally
    {
      conn.Close();
    }
  }
}
