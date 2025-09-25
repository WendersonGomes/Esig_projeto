using MySql.Data.MySqlClient;
using System.Configuration;

public class DBConexao
{
    private static string connString =
        ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

    public static MySqlConnection GetConexao()
    {
        return new MySqlConnection(connString);
    }
}
