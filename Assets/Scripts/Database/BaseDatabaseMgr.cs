using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDatabaseMgr : MonoBehaviour
{
    [Header("���ݿ�����")]
    public string serverIp = "localhost"; // ��������ַ
    public string userId = "root"; // �û�Id
    public string password = "root"; //�û�����
    public string databaseName = "sysDatabase"; // ���ݿ�����
    public string port = "3306"; // �˿ں�
    public string charSet = "utf8"; // �����ʽ

    public static MySqlConnection conn; //���ݿ����Ӷ��� //���ݿ����Ӷ������

    /// <summary>
    /// ��ʼ�����ݿ������
    /// </summary>
    public void InitDatabaseMgr()
    {
        if (conn == null)
        {
            //ʵ�������ݿ����Ӷ���
            conn = new MySqlConnection(
                "Server = " + serverIp + ";" +
                "User Id = " + userId + ";" +
                "Password = " + password + ";" +
                "Database = " + databaseName + ";" +
                "Port = " + port + ";" +
                "CharSet = " + charSet + ";"
                );
        }
      

    }
}
