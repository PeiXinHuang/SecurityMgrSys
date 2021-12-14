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
        try
        {
            conn.Open();

            string sql = string.Format("select * from business"); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Business business = new Business();
                business.id = reader[0].ToString();
                business.title = reader[1].ToString();
                business.content = reader[2].ToString();
                business.adminUserId = reader[3].ToString();
                business.memberUserId = reader[4].ToString();
                business.tools = reader[5].ToString();
                business.pdfName = reader[6].ToString();
                switch (reader[7].ToString())
                {
                    case "0":
                        business.state = Business.State.Doing;
                        break;
                    case "1":
                        business.state = Business.State.Check;
                        break;
                    case "2":
                        business.state = Business.State.Back;
                        break;
                    case "3":
                        business.state = Business.State.Finish;
                        break;
                }

                businesses.Add(business);

            }



        }
        catch (System.Exception e)
        {

            Debug.LogError("GetBusiness all data fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return businesses;
    }

    public void DeleteBusinessById(string id)
    {
        try
        {
            conn.Open();

            //数据库删除语句
            string sql = string.Format("delete from business where id = '{0}'", id);

            //执行删除语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();


        }
        catch (System.Exception e)
        {
            Debug.LogError("删除业务数据失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }

    }

    public List<Business> GetBusinessesByMemberId(string memberId)
    {
        List<Business> businesses = new List<Business>();
        try
        {
            conn.Open();

            string sql = string.Format("select * from business where memberUserId = '{0}'", memberId); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Business business = new Business();
                business.id = reader[0].ToString();
                business.title = reader[1].ToString();
                business.content = reader[2].ToString();
                business.adminUserId = reader[3].ToString();
                business.memberUserId = reader[4].ToString();
                business.tools = reader[5].ToString();
                business.pdfName = reader[6].ToString();
                switch (reader[7].ToString())
                {
                    case "0":
                        business.state = Business.State.Doing;
                        break;
                    case "1":
                        business.state = Business.State.Check;
                        break;
                    case "2":
                        business.state = Business.State.Back;
                        break;
                    case "3":
                        business.state = Business.State.Finish;
                        break;
                }

                businesses.Add(business);

            }



        }
        catch (System.Exception e)
        {

            Debug.LogError("GetBusiness data fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return businesses;
    }


    public List<Business> GetBusinessesByAdminId(string adminId)
    {
        List<Business> businesses = new List<Business>();
        try
        {
            conn.Open();

            string sql = string.Format("select * from business where adminUserId = '{0}'",adminId); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Business business = new Business();
                business.id = reader[0].ToString();
                business.title = reader[1].ToString();
                business.content = reader[2].ToString();
                business.adminUserId = reader[3].ToString();
                business.memberUserId = reader[4].ToString();
                business.tools = reader[5].ToString();
                business.pdfName = reader[6].ToString();
                switch (reader[7].ToString())
                {
                    case "0":
                        business.state = Business.State.Doing;
                        break;
                    case "1":
                        business.state = Business.State.Check;
                        break;
                    case "2":
                        business.state = Business.State.Back;
                        break;
                    case "3":
                        business.state = Business.State.Finish;
                        break;
                }

                businesses.Add(business);

            }



        }
        catch (System.Exception e)
        {

            Debug.LogError("GetBusiness data fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }

        return businesses;
    }

    public Business.State GetBusinessStateById(string businessId)
    {
        Business.State state = Business.State.Doing;
        try
        {
            conn.Open();

            string sql = string.Format("select * from business where id = '{0}'", businessId); //查询语句

            //执行查询语句，并将查询到的数据返回到reader中
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            
            if (reader.Read())
            {
            
                switch (reader[7].ToString())
                {
                    case "0":
                        state = Business.State.Doing;
                        break;
                    case "1":
                        state = Business.State.Check;
                        break;
                    case "2":
                        state = Business.State.Back;
                        break;
                    case "3":
                        state = Business.State.Finish;
                        break;
                }

            }



        }
        catch (System.Exception e)
        {

            Debug.LogError("GetBusiness all data fail:" + e.ToString());
        }
        finally
        {
            conn.Close();
        }


        return state;
    }


    public void UpdateBusinessStateById(string businessId, Business.State state)
    {
        int stateId = 0;
        switch (state)
        {
            case Business.State.Doing:
                stateId = 0;
                break;
            case Business.State.Check:
                stateId = 1;
                break;
            case Business.State.Back:
                stateId = 2;
                break;
            case Business.State.Finish:
                stateId = 3;
                break;
            default:
                break;
        }


        try
        {
            conn.Open();

            //数据库更新语句
            string sql = string.Format(
                "Update business Set state = {0} where id = '{1}'",
                stateId,businessId);


            //执行更新语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            Debug.Log("Update Business Failed: " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    public void CreateNewBusinesses(string adminId,List<string> memberIds,string title, string content)
    {
        try
        {
            conn.Open();

            foreach (string memberId in memberIds)
            {
                //数据库插入语句
                string sql = string.Format("insert into business(adminUserId,memberUserId,title,content)" +
                    " values('{0}','{1}','{2}','{3}')", adminId, memberId, title, content);


                //执行插入语句
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }


        }
        catch (System.Exception e)
        {
            Debug.LogError("创建业务失败 " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    public void UpdatePdfName(string businessId, string pdfName)
    {
        try
        {
            conn.Open();

            //数据库更新语句
            string sql = string.Format(
                "Update business Set pdfName = '{0}' where id = '{1}'",
                pdfName, businessId);


            //执行更新语句
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
            Debug.Log("Update Business pdfName Failed: " + e.ToString());
        }
        finally
        {
            conn.Close();
        }
    }
}
