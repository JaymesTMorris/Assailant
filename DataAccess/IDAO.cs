using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Assailant.DataAccess
{

    /// <summary>
    /// Base interface for models.
    /// </summary>
    public interface IModel
    {
        int PrimaryKey { get; set; }
    }


    public interface IDAO<T> : IDAO where T : IModel, new()
    {
        T Create(T model);
        int? Delete(int id);
        int? Delete(T model);
        List<T> FindAll(string where);
        T FindOne(string where);
        T ModelFromDataRow(DataRow dr);
        T Update(T model);
        T Save(T model);

        string PrimaryKeyColumn { get; set; }
        string TableName { get; set; }
    }

    public interface IDAO
    {
        /* I do not completely understand the purpose and differences of
         * GetConnection/GetTransaction/SetConnection/SetTransaction
         * so I do not know what to make them do.
         * I also do really know the difference of DbConnection and
         * MySqlConnection since I have never used the former. */

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        *    DbConnection GetConnection();                                                       *
        *    DbTransaction GetTransaction();                                                     *
        *    void SetConnection(DbConnection conn, DbTransaction transaction = null);            *
        *    void SetTransaction(DbTransaction transaction = null);                              *
        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        /* Okay now I think I understand a little more. 
         * I am assuming (as the name suggests) "SetConnection" is creating the connection.
         * GetConnection returns the created connection.
         * My function "CreateDBConnection" does both. */

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        *    MySqlConnection CreateDBConnection()                                *
        *    {                                                                   *
        *        MySqlConnection connection = new MySqlConnection(conStr);       *
        *        connection.Open();                                              *
        *        return connection;                                              *
        *    }                                                                   *
        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        /* On second thought I might not understand it.
         * I just made what I thought set connection should be: */

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
        *    void SetConnection(string conn, MySqlTransaction transaction = null)  *
        *    {                                                                     *
        *        MySqlConnection connection = new MySqlConnection(conn);           *
        *    }                                                                     *
        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        /* ...but realised that what you put in the arugements was "DbConnection conn"
         * meaning that since it requires a DbConnection (vs mine which required a string
         * to make the connection) you already made a connection. 
         * So now I'm thinking that GetConnection is more similar to my CreateDBConection
         * and I have no idea what the purpose of SetConnection is.*/

        // This is what I have come up with so far:
        MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection("database=assailantdb;server=fserver2;user=jtmorris;pwd=Lmjabc!23");
            connection.Open();
            return connection;
        }
        DbTransaction GetTransaction();
        void SetConnection(DbConnection conn, DbTransaction transaction = null);
        void SetTransaction(DbTransaction transaction = null);

        // Don't know if this is right.
        // I also don't fully understand what instances are so I what instances are so I have some learning to do.
    }
}
