using Assailant.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess
{
    public class CharacterDAO : IDAO<CharacterModel>
    {
        DbConnection Conn;
        DbTransaction Transaction;

        public string PrimaryKeyColumn { get;  set; } = "characterId";
        public string TableName { get;  set; } = "character";

        //public CharacterDAO(string tableName, string primaryKeyColumn)
        //: this()
        //{
        //    TableName = tableName;
        //    PrimaryKeyColumn = primaryKeyColumn;
        //}

        public CharacterDAO()
        {
        }

        public void SetConnection(DbConnection conn, DbTransaction transaction = null)
        {
            Conn = conn;
            Transaction = transaction;
        }

        public void SetTransaction(DbTransaction transaction = null)
        {
            Transaction = transaction;
        }

        public DbConnection GetConnection()
        {
            return Conn;
        }

        public DbTransaction GetTransaction()
        {
            return Transaction;
        }

        public CharacterModel Create(CharacterModel model)
        {
            using (DbConnection connection = GetConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO `character` (name, playerId, characterJSON) VALUES ('@name, @playerId, @JSON');";

                    DbParameter paramName = command.CreateParameter();
                    paramName.ParameterName = "@name";
                    paramName.Value = model.Name;
                    command.Parameters.Add(paramName);

                    DbParameter paramPlayerId = command.CreateParameter();
                    paramPlayerId.ParameterName = "@playerId";
                    paramPlayerId.Value = model.PlayerId;
                    command.Parameters.Add(paramPlayerId);

                    DbParameter paramJSON = command.CreateParameter();
                    paramJSON.ParameterName = "@JSON";
                    paramJSON.Value = model.JSON;
                    command.Parameters.Add(paramJSON);

                    command.Transaction = GetTransaction();
                    command.ExecuteNonQuery();
                }

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT LAST_INSERT_ID();";
                    command.Transaction = GetTransaction();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            model.CharacterId = (int)id;
                        }
                    }
                }
            }
            return model;
        }

        public int? Delete(int id)
        {
            int rowsDeleted = 0;

            using (DbConnection connection = GetConnection())
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM `character` WHERE characterId = @id";

                    DbParameter idParam = command.CreateParameter();
                    idParam.ParameterName = "@id";
                    idParam.DbType = DbType.Int32;
                    idParam.Value = id;
                    command.Parameters.Add(idParam);

                    rowsDeleted = command.ExecuteNonQuery();
                }
            }

            return rowsDeleted;
        }

        public int? Delete(CharacterModel model)
        {
            return Delete(model.CharacterId);
        }

        public List<CharacterModel> FindAll(string where)
        {
            List<CharacterModel>? retval = null;
            string columns = "col1,col2,col3";
            string sql = $"SELECT {columns} FROM  {TableName} WHERE {where}";
            using (DbCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Transaction = GetTransaction();
                DataTable dt = DoQuery(cmd);
                if (dt != null && dt.Rows.Count > 0)
                {
                    retval = ToList(dt);
                }
                
            }
            return retval;
        }

        private List<CharacterModel> ToList(DataTable dt)
        {
            throw new NotImplementedException();
        }

        private DataTable DoQuery(DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public CharacterModel FindOne(string where)
        {
            throw new NotImplementedException();
        }

        public CharacterModel ModelFromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public CharacterModel Save(CharacterModel model)
        {
            if (model == null)
            {
                throw new Exception("Model provided was null");
            }
            if (model.PrimaryKey == 0)
            {
                  return Create(model);
            }
            else
            {
                return Update(model);
            }
        }

        public CharacterModel Update(CharacterModel model)
        {
            using (DbCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = @"UPDATE `character` SET name = '@name', characterJSON = '@JSON' WHERE characterId = @characterId);";

                DbParameter paramName = cmd.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = model.Name;
                cmd.Parameters.Add(paramName);

                DbParameter paramJSON = cmd.CreateParameter();
                paramJSON.ParameterName = "@JSON";
                paramJSON.Value = model.JSON;
                cmd.Parameters.Add(paramJSON);

                DbParameter paramCharacterId = cmd.CreateParameter();
                paramCharacterId.ParameterName = "@characterId";
                paramCharacterId.Value = model.CharacterId;
                cmd.Parameters.Add(paramCharacterId);

                cmd.Transaction = GetTransaction();
                cmd.ExecuteNonQuery();
            }
            return model;
        }
    }
}
