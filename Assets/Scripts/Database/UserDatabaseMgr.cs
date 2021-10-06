using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


/// <summary>
/// 用户数据库控制器
/// </summary>
public class UserDatabaseMgr : MonoBehaviour
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
    private static UserDatabaseMgr instance;
    public static UserDatabaseMgr Instance {
        get
        {
            if(instance == null)
            {
                instance = (UserDatabaseMgr)FindObjectOfType(typeof(UserDatabaseMgr));
                if (instance == null){
                    GameObject userDatabaseMgr = new GameObject("UserDatabaseMgr");
                    instance = (UserDatabaseMgr)userDatabaseMgr.AddComponent(typeof(UserDatabaseMgr));
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
    /// 插入单个用户数据
    /// </summary>
    /// <param name="user">用户对象</param>
    public void InsertUserData(User user)
    {
        try
        {
            conn.Open();

            //数据库插入语句
            string sql = string.Format("insert into user(userId,job,userName,sex,password," +
                "phone) values('{0}','{1}','{2}','{3}','{4}','{5}')",user.userId,user.JobToString(user.userJob),
                user.userName,user.sex,user.password,user.phone);
           
            //执行插入语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
            
        }
        catch (System.Exception e)
        {
            Debug.LogError("插入用户数据失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id">用户id</param>
    public void DeleteUserData(int userId)
    {
        
    }

    /// <summary>
    /// 清空数据库
    /// </summary>
    public void ClearUserData()
    {

    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="user">用户信息</param>
    public void UpdateUserData(User user)
    {
        try
        {
            conn.Open();

            //数据库更新语句
            string sql = string.Format(
                "Update user Set username = '{0}' , password = '{1}', job = '{2}',sex = '{3}',phone = '{4}'" +
                "where userId = '{5}'",
                user.userName, user.password, user.JobToString(user.userJob),user.sex,user.phone,user.userId);


            //执行更新语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            Debug.Log("Update User Failed: " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="id">用户Id</param>
    /// <returns>用户</returns>
    public User GetUserData(string userId)
    {
        User user = new User();
        try
        {
            conn.Open();

            string sql = string.Format("select * from user where userId = '{0}'", userId); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                user.userId = reader[0].ToString();
                user.userJob = user.StringToJob(reader[1].ToString());
                user.userName = reader[2].ToString();
                user.sex = reader[3].ToString();
                user.password = reader[4].ToString();
                user.phone = reader[5].ToString();

              
            }



        }
        catch (System.Exception e)
        {

            Debug.Log("ChargeUserExit fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }
        
        return user;
    }

    public List<User> GetUsersData(List<string> userIds)
    {
        return new List<User>();
    }

    public List<User> GetUsersData()
    {
        return new List<User>();
    }

    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="userId">用户Id</param>
    /// <returns>是否存在</returns>
    public bool ChargeUserExit(string userId)
    {
        bool isExit = false;

        try
        {
            conn.Open();

            string sql = string.Format("select * from user where userId = '{0}'",userId); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isExit = true;
            }
            
          
      
        }
        catch (System.Exception e)
        {

            Debug.Log("ChargeUserExit fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }
   
        return isExit;
    }


}


