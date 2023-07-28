using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace DataAccessUnitTest
{

    [TestClass]
    public class CharacterDAOTests
    {
        [TestMethod]
        public void TestCreateCharacter()
        {
            // Arrange
            CharacterModel characterToCreate = new CharacterModel
            {
                PrimaryKey = 1,
                PlayerId = 101,
                Name = "Test Character",
                JSON = "{\"Name\": \"Test Character\", \"Rank\": 0, \"Level\": 0, \"Score\": 0, \"Stats\": {\"HP\": {\"BaseValue\": 1000, \"FinalValue\": 2000, \"BaseMultiplier\": 0}, \"MP\": {\"BaseValue\": 10, \"FinalValue\": 1010, \"BaseMultiplier\": 0}, \"Wisdom\": {\"BaseValue\": 10, \"FinalValue\": 10, \"BaseMultiplier\": 0}, \"Agility\": {\"BaseValue\": 10, \"FinalValue\": 10, \"BaseMultiplier\": 0}, \"HPRegen\": {\"BaseValue\": 1000, \"FinalValue\": 1200, \"BaseMultiplier\": 0}, \"MPRegen\": {\"BaseValue\": 10, \"FinalValue\": 111, \"BaseMultiplier\": 0}, \"Strength\": {\"BaseValue\": 10, \"FinalValue\": 10, \"BaseMultiplier\": 0}, \"MagicArmor\": {\"BaseValue\": 100, \"FinalValue\": 101, \"BaseMultiplier\": 0}, \"SpellPower\": {\"BaseValue\": 0, \"FinalValue\": 1, \"BaseMultiplier\": 0}, \"AttackPower\": {\"BaseValue\": 0, \"FinalValue\": 1, \"BaseMultiplier\": 0}, \"RemainingHP\": 2000, \"RemainingMP\": 1010, \"Constitution\": {\"BaseValue\": 10, \"FinalValue\": 10, \"BaseMultiplier\": 0}, \"Intelligence\": {\"BaseValue\": 10, \"FinalValue\": 10, \"BaseMultiplier\": 0}, \"PhysicalArmor\": {\"BaseValue\": 100, \"FinalValue\": 101, \"BaseMultiplier\": 0}}, \"Skills\": null, \"Experience\": 0, \"EquipedItems\": null}"
            };
            CharacterDAO characterDAO = new CharacterDAO();
            DbConnection dbConnection = new MySqlConnection("database=assailantdb;server=sirrom.us;port=3306;user=jtmorris;pwd=Lmjabc!23");

            // Act
            characterDAO.SetConnection(dbConnection);
            CharacterModel createdCharacter = characterDAO.Create(characterToCreate);

            // Assert
            Assert.IsNotNull(createdCharacter, "Character was not created successfully.");
            Assert.AreEqual(characterToCreate.PrimaryKey, createdCharacter.PrimaryKey, "CharacterID mismatch.");
            Assert.AreEqual(characterToCreate.Name, createdCharacter.Name, "Name mismatch.");
            Assert.AreEqual(characterToCreate.PlayerId, createdCharacter.PlayerId, "PlayerID mismatch.");
            Assert.AreEqual(characterToCreate.JSON, createdCharacter.JSON, "JSON mismatch.");
        }
    }
}