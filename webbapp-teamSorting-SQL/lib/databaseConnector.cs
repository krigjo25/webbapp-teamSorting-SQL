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

    public void CreateTable(string table, List <string> columns)
    {
        //  Open the connection
        Conn.Open();
        
        //  Initialize the query
        string query = "";
        
        foreach (var element in columns)
        {
            query += element;
            if (element != columns.Last()  )
            {
                query += ", ";
                
            }
            else
            {
                query += ");";
            }
        }
        // Execute the query
        var cmd = new SqlCommand($"CREATE TABLE IF NOT EXISTS {table}({query})", Conn);
        
        cmd.ExecuteNonQuery();
        
        // Close the connection
        Conn.Close();

    }
}