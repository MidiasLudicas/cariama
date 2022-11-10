using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DatabaseSynchronizer
{
    private static readonly int Version = 1;
    public static void Synch()
    {
        //create tables
        SQLiteManager.RunQuery(CommonQuery.Create("VERSION", "DATABASE_VERSION INTEGER"));
        SQLiteManager.RunQuery(CommonQuery.Create("OPTIONS", "SOUND INTEGER"));
        SQLiteManager.RunQuery(CommonQuery.Create("LEADERBOARD", "NAME VARCHAR(10), SCORE INTEGER"));

        //save data on the tables
        SQLiteManager.RunQuery(CommonQuery.Add("VERSION", "DATABASE_VERSION", Version.ToString()));
        SQLiteManager.RunQuery(CommonQuery.Add("OPTIONS", "SOUND", "1"));
    }
}
