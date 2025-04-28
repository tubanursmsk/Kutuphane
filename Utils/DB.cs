using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Kutuphane.Utils;

public class DB 
{
    static string _connectionString = "Server=.; Database=Kutuphane; Integrated Security=True; TrustServerCertificate=True;";
    SqlConnection _connection = new(_connectionString);

    public SqlConnection GetConnection()
    {
        try
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
                Console.WriteLine("Connection Opened.");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        return _connection;
    }

    public void CloseConnection()
    {
        try 
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                Console.WriteLine("Connection Closed.");
            }
        } 
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
