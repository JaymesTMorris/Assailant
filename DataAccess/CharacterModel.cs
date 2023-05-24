using Assailant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CharacterModel : IModel
    {
        public int PrimaryKey { get { return CharacterId; } set { CharacterId = value; } }
        public int CharacterId { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string JSON { get; set; }
    }
}
