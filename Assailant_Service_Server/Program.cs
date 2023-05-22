using System.Data;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;


public class AssailantServer
{
    static string conStr = "database=assailantdb;server=fserver2;user=jtmorris;pwd=Lmjabc!23";

    public static void PrintAllCharaters()
    {
        MySqlConnection connection = CreateDBConnection();
        MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM assailantdb.character;", connection);
        DataTable table = new DataTable();
        adp.Fill(table);
        Console.WriteLine("----START OF CHARACTERS----");
        Console.WriteLine("CHARACTER_ID, NAME, PLAYER_ID, CHARACTER_JSON;");
        foreach (DataRow dataRow in table.Rows)
        {
            int i = 1;
            foreach (var item in dataRow.ItemArray)
            {
                Console.Write(item);
                if (i != 4)
                {
                    Console.Write(", ");
                }
                i++;
            }
            Console.WriteLine(";");
        }
        Console.WriteLine("----END OF CHARACTERS----");
    }

    private static MySqlConnection CreateDBConnection()
    {
        MySqlConnection connection = new MySqlConnection(conStr);
        connection.Open();
        return connection;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        AssailantServer.PrintAllCharaters();
    }
}
