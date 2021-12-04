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

    public MySqlConnection conn; //数据库连接对象

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

            Debug.Log("insert sql: " + sql);
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
    public void DeleteUserData(string userId)
    {
       

        try
        {
            conn.Open();

            //数据库删除语句
            string sql = string.Format("delete from user where userId = '{0}'", userId);
            Debug.Log("delete sql is :" + sql);

            //执行删除语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();

            
        }
        catch (System.Exception e)
        {
            Debug.LogError("删除用户数据失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
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
    /// 根据Id获取用户
    /// </summary>
    /// <param name="id">用户Id</param>
    /// <returns>用户</returns>
    public User GetUserDataById(string userId)
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

            Debug.LogError("getUserById fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }
        
        return user;
    }




    /// <summary>
    /// 查询用户
    /// </summary>
    /// <param name="user">user内部包含查询条件</param>
    /// <returns></returns>
    public List<User> GetUsersData(User user)
    {
        List<User> users = new List<User>();

        string sql = "select * from user ";
        List<string> conditions = new List<string>();

        if (!string.IsNullOrEmpty(user.userId))
            conditions.Add(string.Format("userId = '{0}'", user.userId));
        if (!string.IsNullOrEmpty(user.userName))
            conditions.Add(string.Format("username = '{0}'", user.userName));
        if (!string.IsNullOrEmpty(user.sex))
            conditions.Add(string.Format("sex = '{0}'", user.sex));
        switch (user.userJob)
        {
            case User.UserJob.None: break;
            case User.UserJob.Member:
            case User.UserJob.Admin:
            case User.UserJob.SysAdmin:
                conditions.Add(string.Format("job = '{0}'", user.JobToString(user.userJob))); break;
        }

        if (conditions.Count != 0)
        {
            sql += "where ";
            for (int i = 0; i < conditions.Count - 1; i++)
            {

                sql += conditions[i];
                sql += " and ";
            }
            sql += conditions[conditions.Count - 1];
        }



        Debug.Log(" searchSql is " + sql);

        try
        {
            conn.Open();
            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();


            while(reader.Read())
            {
                User newUser = new User();
                newUser.userId = reader[0].ToString();
                newUser.userJob = user.StringToJob(reader[1].ToString());
                newUser.userName = reader[2].ToString();
                newUser.sex = reader[3].ToString();
                newUser.password = reader[4].ToString();
                newUser.phone = reader[5].ToString();

                users.Add(newUser);
            }

        }
        catch (System.Exception e)
        {
            Debug.LogError("GetUsersData fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return users;
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

            Debug.LogError("ChargeUserExit fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }
   
        return isExit;
    }


    /// <summary>
    /// 获取新用户ID
    /// </summary>
    /// <returns></returns>
    public string GetNewUserId()
    {


        List<User> allUsers = GetUsersData(new User());
        int newUserId = 0;
        foreach (User user in allUsers)
        {
            int num;
            bool hasGet = int.TryParse(user.userId, out num);
            if (hasGet)
            {
                if(newUserId <= num)
                {
                    newUserId = num+1;
                }
            }
        }

        if (newUserId <= 0 || newUserId > 99999)
        {
            Debug.LogError("Fail to get new userId :" + newUserId);
            return "";
        }

        string tempIdStr = newUserId.ToString();;

        string result = "";
        for (int i = 0; i < 5 - tempIdStr.Length; i++)
        {
            result += "0";
        }

        result += tempIdStr;
        return result;
    }
}


