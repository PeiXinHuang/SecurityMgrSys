using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDatabaseMgr : MonoBehaviour
{
    [Header("数据库配置")]
    public string serverIp = "localhost"; // 服务器地址
    public string userId = "root"; // 用户Id
    public string password = "root"; //用户密码
    public string databaseName = "sysDatabase"; // 数据库名称
    public string port = "3306"; // 端口号
    public string charSet = "utf8"; // 编码格式

    private MySqlConnection conn; //数据库连接对象

    // 实现单例模式访问数据库
    private static InfoDatabaseMgr instance;
    public static InfoDatabaseMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (InfoDatabaseMgr)FindObjectOfType(typeof(InfoDatabaseMgr));
                if (instance == null)
                {
                    GameObject InfoDatabaseMgrObj = new GameObject("InfoDatabaseMgr");
                    instance = (InfoDatabaseMgr)InfoDatabaseMgrObj.AddComponent(typeof(InfoDatabaseMgr));
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

    public List<Info> GetInfosBySendId(string id)
    {
        List<Info> infos = new List<Info>();
        try
        {
            conn.Open();

            string sql = string.Format("select * from info where sendId = '{0}'", id); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            Debug.Log("search sql: " + sql);

            while(reader.Read())
            {
                Info info = new Info();
                info.infoId = reader[0].ToString();
                info.sendId = reader[1].ToString();
                info.receiveId = reader[2].ToString();
                info.infoTitle = reader[3].ToString();
                info.infoContent = reader[4].ToString();
                infos.Add(info);
            }



        }
        catch (System.Exception e)
        {

            Debug.Log("Get Info fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return infos;
    }

    public List<Info> GetInfosByReveiveId(string id)
    {
        List<Info> infos = new List<Info>();
        try
        {
            conn.Open();

            string sql = string.Format("select * from info where receiveId = '{0}'", id); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            Debug.Log("search sql: " + sql);

            while (reader.Read())
            {
                Info info = new Info();
                info.infoId = reader[0].ToString();
                info.sendId = reader[1].ToString();
                info.receiveId = reader[2].ToString();
                info.infoTitle = reader[3].ToString();
                info.infoContent = reader[4].ToString();
                infos.Add(info);
            }



        }
        catch (System.Exception e)
        {

            Debug.Log("Get Info fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return infos;
    }

    public void CreateNewInfos(string sendId,List<string> receiveIds,string infoTitle,string infoContent)
    {
        try
        {
            conn.Open();

            foreach (string receiveId in receiveIds)
            {
                //数据库插入语句
                string sql = string.Format("insert into info(sendId,receiveId,infoTitle,infoContent)" +
                    " values('{0}','{1}','{2}','{3}')", sendId, receiveId, infoTitle, infoContent);

                Debug.Log("insert sql: " + sql);
                //执行插入语句
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            

        }
        catch (System.Exception e)
        {
            Debug.LogError("插入信息数据失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }


    public void DeleteInfoByInfoId(string id)
    {

        try
        {
            conn.Open();

            //数据库删除语句
            string sql = string.Format("delete from info where infoId = '{0}'", id);
            Debug.Log("delete sql is :" + sql);

            //执行删除语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();


        }
        catch (System.Exception e)
        {
            Debug.LogError("删除信息数据失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

}
