using System.Data.SqlClient;

namespace webbapp_teamSorting_SQL.lib;

public class SQLConnector
{
    private SqlConnection Conn = new SqlConnection("Data Source=database.db;Version=3;");
    
    public void CreateDatabase()
    {
        //  Open the connection
        Conn.Open();
        
        //  Create the query
        string query = "CREATE DATABASE IF NOT EXISTS teamSorting";
        
        //  Execute the query
        var cmd = new SqlCommand(query, Conn);
        cmd.ExecuteNonQuery();
        
        //  Close the connection
        Conn.Close();
    }
}