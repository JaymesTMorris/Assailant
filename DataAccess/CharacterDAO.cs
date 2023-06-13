using Assailant.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CharacterDAO : IDAO<CharacterModel>
    {
        public string PrimaryKeyColumn { get;  set; } = "characterId";
        public string TableName { get;  set; } = "character";
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
            // MySqlConnection connection = IDAO.GetConnection();
            // MySqlConnection connection = new IDAO.GetConnection();
            // Okay... now I know that I definitely do not understand interfaces.
            throw new NotImplementedException();
        }

        public CharacterModel FindOne(string where)
        {
            throw new NotImplementedException();
        }

        //public DbConnection GetConnection()
        //{
        //    throw new NotImplementedException();
        //}

        public DbTransaction GetTransaction()
        {
            throw new NotImplementedException();
        }

        public CharacterModel ModelFromDataRow(DataRow dr)
        {
            throw new NotImplementedException();
        }

        public CharacterModel Save(CharacterModel model)
        {
            throw new NotImplementedException();
        }

        public void SetConnection(DbConnection conn, DbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public void SetTransaction(DbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public CharacterModel Update(CharacterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
