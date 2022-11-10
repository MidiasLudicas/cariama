using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

class SQLiteManager
{
    private static IDbConnection Database;
    private static string Connection = $@"{Application.persistentDataPath}\Database\Database.sqlite";

    public static bool SetDatabase()
    {
        Connection = $@"{Application.persistentDataPath}\Database\Database.sqlite";
        Database = new SqliteConnection(new SqliteConnection("URI=file:" + Connection));
        SetDatabaseActive(true);

        bool databaseExist = int.Parse(ReturnValueAsString(CommonQuery.Select("COUNT(*)", "SQLITE_MASTER"))) > 0;

        if (!databaseExist) DatabaseSynchronizer.Synch();

        return databaseExist;
    }

    public static void RunQuery(string query)
    {
        IDbCommand cmd;

        cmd = Database.CreateCommand();
        cmd.CommandText = query;
        cmd.ExecuteReader();
    }

    public static string ReturnValueAsString(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        return reader[0].ToString();
    }

    public static List<LeaderboardDemo> ReturnValueAsListOfString(string query)
    {
        List<LeaderboardDemo> output = new List<LeaderboardDemo>();
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        for (int i = 0; i < 10; i++) 
        {
            if (reader[i] != null) 
            {
                output.Add(new LeaderboardDemo()
                {
                    Name = reader[0].ToString(),
                    Score = (int)reader[1]
                });
                reader.NextResult();
            }
            
        }

        return output;
    }

    public static int ReturnValueAsInt(string query)
    {
        IDbCommand cmd;
        IDataReader reader;

        cmd = Database.CreateCommand();

        cmd.CommandText = query;
        reader = cmd.ExecuteReader();

        return Convert.ToInt32(reader[0]);
    }

    public static void SetDatabaseActive(bool active)
    {
        if (active) Database.Open();
        else Database.Close();
    }
}
