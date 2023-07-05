namespace Shared
{
    public class Character : ICharacter
    {
        public Attributes.Attributes Stats { get; set; }
        public SkillLoadout Skills { get; set; }
        public EquipmentSet EquipedItems { get; set; }
        public int Score { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
    }
}