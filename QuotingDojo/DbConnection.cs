using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
 
namespace DbConnection	//you can leave as is, or change to your own namespace
{
    public class DbConnector
    {
        static string server = "localhost";
        static string db = "myDatabase"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }