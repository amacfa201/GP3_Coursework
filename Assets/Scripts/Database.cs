using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Database : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

    void Start()
    {

        
        string conn = "URI=file:" + Application.dataPath + "/test.db";
        print(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT value,name, " + "FROM first"; 
        //string sqlQuery = "SELECT a, b FROM first;";
        //dbcmd.CommandText = sqlQuery;
        dbcmd.CommandText = "create table testtable (playerX int, playerY int, playerZ int, enemyrX int, enemyY int, enemyZ int, );";
        SaveState(dbcmd);
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);

            Debug.Log("value= " + value + "  name =" + name);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


    void SaveState(IDbCommand cmd)
    {
        cmd.CommandText = "insert into testtable(playerX, playerY, playerZ, enemyX, enemyY, enemyZ) values(" + (int)player.transform.position.x + "," + (int)player.transform.position.y + "," + (int)player.transform.position.z + "," + (int)enemy.transform.position.x + "," + (int)enemy.transform.position.y + "," + (int)enemy.transform.position.z + ")";

    }

}
