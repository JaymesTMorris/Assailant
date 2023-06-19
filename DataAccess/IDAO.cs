using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
        DbConnection GetConnection();
        DbTransaction GetTransaction();
        void SetConnection(DbConnection conn, DbTransaction transaction = null);
        void SetTransaction(DbTransaction transaction = null);
    }
}
