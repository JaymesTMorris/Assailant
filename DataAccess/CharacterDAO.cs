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
            throw new NotImplementedException();
        }

        public int? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int? Delete(CharacterModel model)
        {
            throw new NotImplementedException();
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
                CreateCharacter(model);
                using (DbCommand cmd = GetConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    cmd.Transaction = GetTransaction();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            model.CharacterId = (int)id;
                        }
                    }
                }
                return model;
            }
            else
            {
                return Update(model);
            }
        }

        private void CreateCharacter(CharacterModel model)
        {
            using (DbCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO `character` (name, playerId, characterJSON) VALUES ('@name, @playerId, @JSON');";

                DbParameter paramName = cmd.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = model.Name;
                cmd.Parameters.Add(paramName);

                DbParameter paramPlayerId = cmd.CreateParameter();
                paramName.ParameterName = "@playerId";
                paramName.Value = model.PlayerId;
                cmd.Parameters.Add(paramPlayerId);

                DbParameter paramJSON = cmd.CreateParameter();
                paramName.ParameterName = "@JSON";
                paramName.Value = model.Name;
                cmd.Parameters.Add(paramJSON);

                cmd.Transaction = GetTransaction();
                cmd.ExecuteNonQuery();
            }
        }

        public CharacterModel Update(CharacterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
