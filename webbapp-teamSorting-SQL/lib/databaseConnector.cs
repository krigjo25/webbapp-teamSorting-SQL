using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace webbapp_teamSorting_SQL.lib;

public class SQLConnector
{
    private SqlConnection Conn = new SqlConnection("Data Source=database.db;Version=3;");
    
    public void CreateDatabase()
    {
        //  Open the connection
        Conn.Open();
        
        //  Initialize the query
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

    public void InsertData(string table, List<string> column, List<string> Data)
    {
        //  Open the connection
        Conn.Open();
        
        //  Initialize the querys
        string columns = "(";
        string data = "(";

        //  Add columns into the query
        foreach (var elements in column)
        {
            columns += elements;
            
            if (elements != column.Last())
            {
                columns += ", ";
            }
            else
            {
                columns += ")";
            }
        }

        //  Add data into the query
        foreach (var element in Data)
        {
            //  Initialize the data
            data += element;

            if (element != Data.Last())
            {
                data += ", ";
            }
            else
            {
                data += ");";
            }
        }
        
        //  Initializing the query
        string query = $"INSERT INTO {table} {columns} VALUES {data}";
        
        //  Execute the query
        var cmd = new SqlCommand(query, Conn);
        cmd.ExecuteNonQuery();
        
        //  Close the connection
        Conn.Close();
    }


    public void CreateView()
    {
        
    }
}

public class FileParser
{

}

public class APIConnector
{

    public void GetTeams()
    {
        
    }
}